import { Component, OnInit, Input} from '@angular/core';
import { Router } from '@angular/router';

//api_services.js function can be located at: src\assets\js\api_services.js
declare const getResponse: any;

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
  @Input() productPrice:number;
  
  products:any;
  
  constructor(private router: Router) {
    getResponse("product", (res) => this.handleResponseFromServer(res));
  }

  ngOnInit() {
    console.log(this.productId, this.products);
  }

  async onClick(id:string){
    this.saveDataOnLocalStorage();
    this.router.navigateByUrl('/checkout');
  }

  private saveDataOnLocalStorage() {
    localStorage.setItem("product_title", this.title);
    localStorage.setItem("product_id", this.productId);
    localStorage.setItem("product_price", this.productPrice.toString());
  }

  private handleResponseFromServer(res){
    this.products = res;
  }

}
