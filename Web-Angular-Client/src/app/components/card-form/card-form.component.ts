import { Component, OnInit, Input} from '@angular/core';

//api_services.js functions! can be located at: src\assets\js\api_services.js
declare const getResponse: any;
declare const postResponse: any;
declare const getBrowserInformation: any;

@Component({
  selector: 'app-card-form',
  templateUrl: './card-form.component.html',
  styleUrls: ['./card-form.component.css']
})
export class CardFormComponent implements OnInit {

  @Input() title: string;
  @Input() subtitle: string;
  @Input() imgsrc: string;
  @Input() alt: string;
  @Input() desc: string;
  @Input() productId:string;

  constructor() {}

  ngOnInit() {
  }

  async onClick(id:string){
    console.log(id);
    console.log(await getBrowserInformation());
  }

}
