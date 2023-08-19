import { Component, OnInit } from '@angular/core';
import { HousingService } from 'src/app/services/housing.service';
import { ActivatedRoute } from '@angular/router';
import { Ipropertybase } from 'src/app/model/ipropertybase';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {
  SellRent = 1;

  properties: Array<Ipropertybase>= [];
  
  constructor(private route: ActivatedRoute, private housingService: HousingService) { }

  ngOnInit() {
    if(this.route.snapshot.url.toString()){
      this.SellRent=2;
    }
    this.housingService.getAllProperties(this.SellRent).subscribe(
      data => {
        this.properties = data;

        const storedValue = localStorage.getItem('newProp');
        const newProperty = storedValue !== null ? JSON.parse(storedValue) : null;

        if (newProperty.SellRent === this.SellRent) {
          this.properties = [newProperty, ...this.properties];
        }

      }, error => {
        console.log(error);
      }
    );
  }

}
