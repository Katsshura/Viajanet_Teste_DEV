using RabbitMQ.Robot.Infrastructure;
using RabbitMQ.Robot.Infrastructure.Connections;
using RabbitMQ.Robot.Initializer.DataContexts;
using System;
using System.Runtime.InteropServices;

namespace RabbitMQ.Robot.Initializer
{
    class Program
    {
        #region Console Exit Handlers
        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        private enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        private delegate bool EventHandler(CtrlType sig);
        private static EventHandler _handler;


        private static bool Handler(CtrlType sig)
        {
            Console.WriteLine("Exiting system due to external CTRL-C, or process kill, or shutdown");

            //Closes Couchbase Connection
            CouchbaseConnector.CloseCouchbaseConnection();
            //shutdown right away so there are no lingering threads
            Environment.Exit(-1);
            return true;
        }
        #endregion

        static void Main(string[] args)
        {
            //Set up handler to be fired when console closes
            _handler += new EventHandler(Handler);
            SetConsoleCtrlHandler(_handler, true);

            Console.WriteLine("Initializing Robot...");

            SqlServerDataContext dataContext = new SqlServerDataContext();
            CouchbaseConnector.OpenCouchbaseConnection();

            RabbitListener listener = new RabbitListener(dataContext);

            listener.ReceiveMessageOnQueue("client_browser_info");
            listener.ReceiveMessageOnQueue("client_purchase_info");
            listener.ReceiveMessageOnQueue("client_user_info");
        }
    }
}
