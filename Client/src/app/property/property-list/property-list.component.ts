import { Component, OnInit } from '@angular/core';
import { HousingService } from 'src/app/services/housing.service';
import { IProperty } from '../IProperty';

@Component({
  selector: 'app-property-list',
  templateUrl: './property-list.component.html',
  styleUrls: ['./property-list.component.css']
})
export class PropertyListComponent implements OnInit {

  properties: Array<IProperty>= [];
  
  constructor(private housingService: HousingService) { }

  ngOnInit() {
    this.housingService.getAllProperties().subscribe(
      data => {
        this.properties = data;
      }, error => {
        console.log(error);
      }
    );
  }

}
