import { Injectable } from '@angular/core';

//api_services.js function can be located at: src\assets\js\api_services.js
declare const postResponse: any;
declare const getIp: any;

@Injectable({
  providedIn: 'root'
})
export class BrowserService {
  browserInformation: any;

  private key: string;

  constructor() {
  }

  sendBrowserInformationToApi() {
    getIp((res) => this.setBrowserInformation(res));
  }

  private verifyIfIpHasChanged() {
    let storedIp = localStorage.getItem(this.key);
    if(storedIp === null || storedIp === undefined){
      this.makePostRequest();
    }else{
      if(storedIp != this.browserInformation.ip){
        this.makePostRequest();
      }
    }
  }

  private makePostRequest() {
    this.saveIpOnLocalStorage(this.browserInformation.ip);
    postResponse('browser', this.browserInformation, (res) => console.log('Post successfully', res));
  }

  private saveIpOnLocalStorage(ip: string) {
    localStorage.setItem(this.key, ip);
  }

  private setBrowserInformation(responseIp: any) {
    this.browserInformation =
      {
        ip: responseIp.ip,
        pageName: location.pathname.substring(location.pathname.lastIndexOf("/") + 1).toLowerCase(),
        browserName: navigator.appCodeName.toLocaleLowerCase(),
      }
    this.key = "key_" + this.browserInformation.pageName;
    this.verifyIfIpHasChanged();
  }
}
