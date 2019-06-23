const HOST_GET_API = 'http://localhost:60620/api/v1/';
const HOST_POST_API = 'http://localhost:55472/api/v1/';

async function getResponse(url, params, callback) {
  let res;
  if (params === null) {
    res = await $.get(HOST_GET_API + url, callback);
  } else {
    res = await $.get(HOST_GET_API + url, params, callback).catch(c => {
      //verify if what was caught is an error
      if (c.status != 200) {
        //if it is, execute callback with res = null and status of failed
        callback(null, 'failed')
      }
    });
  }
  return res;
}

async function postResponse(url, data, callback) {
  let res;
  res = await $.post(HOST_POST_API + url, JSON.stringify(data), callback).catch(c => {
    if((c.status == 200 || c.status == 201) === false){
      callback(null, "failed");
      console.log(c);
    }
  });
  return res;
}

async function getIp() {
  let res = await $.getJSON("https://api.ipify.org?format=json");
  return res.ip;
}

async function getBrowserInformation() {
  BrowserInformation =
    {
      "ip": await getIp(),
      "pageName": location.pathname.substring(location.pathname.lastIndexOf("/") + 1).toLowerCase(),
      "name": navigator.appCodeName.toLocaleLowerCase(),
    }
  return await BrowserInformation;
}
