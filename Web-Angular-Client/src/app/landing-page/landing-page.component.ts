import { Component, OnInit } from '@angular/core';
import { ParticlePropertiesService } from '../util/particle-properties.service';

@Component({
  selector: 'app-landing-page',
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css']
})
export class LandingPageComponent implements OnInit {
  myParams: object = {};
  tit: string;


  constructor(private params: ParticlePropertiesService) { }

  ngOnInit() {
    this.myParams = this.params.myParams;
    this.tit = "hello";
  }
}
