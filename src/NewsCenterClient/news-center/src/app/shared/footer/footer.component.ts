import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css']
})
export class FooterComponent implements OnInit {
  public year: number;

  constructor() {
    var currentTime = new Date();
    this.year = currentTime.getFullYear();
   }

  ngOnInit(): void {
  }

}
