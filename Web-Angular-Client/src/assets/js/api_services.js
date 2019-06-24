const HOST_GET_API = 'http://localhost:60620/api/v1/';
const HOST_POST_API = 'http://localhost:55472/api/v1/';

async function getResponse(url, params, callback) {
  let res;
  if (params === null) {
    res = await $.get(HOST_GET_API + url, callback).catch(c => console.log(c));
  } else {
    res = await $.get(HOST_GET_API + url, params, callback).catch(c => console.log(c));
  }
  return res;
}

async function postResponse(url, dtr, callback) {
  $.ajax({
    type: 'POST',
    dataType: "json", // expected format for response
    contentType: "application/json",
    url: HOST_POST_API+url,
    data: JSON.stringify(dtr),
    success: function (dataResponse) {
      callback(dataResponse);
    },
    error: function () {
      console.log("Error", dtr);
    },
  });
}

//Using free api to get public ip
async function getIp(callback) {
  let res = await $.getJSON("https://api.ipify.org?format=json").done(callback);
  return res.ip;
}
