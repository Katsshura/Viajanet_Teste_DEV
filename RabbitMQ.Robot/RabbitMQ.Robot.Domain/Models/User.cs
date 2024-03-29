﻿using Newtonsoft.Json;
using System;

namespace RabbitMQ.Robot.Domain
{
    public class User
    {
        [JsonProperty("id")]
        public Guid? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("lastName")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("phoneNumber")]
        public long PhoneNumber { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }

        public static User FromJson(string json)
        {
            return JsonConvert.DeserializeObject<User>(json, JsonSettings.Settings);
        }

        public static string ToJson(User self)
        {
            return JsonConvert.SerializeObject(self, JsonSettings.Settings);
        }

        public override string ToString()
        {
            string temp = Name + " " + LastName;
            return temp;
        }

        public override bool Equals(object obj)
        {
            var item = obj as User;

            if (item == null)
            {
                return false;
            }

            return this.Email.Equals(item.Email);
        }

        public override int GetHashCode()
        {
            return this.Email.GetHashCode();
        }
    }
}
