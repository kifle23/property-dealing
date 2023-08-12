import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { Ipropertybase } from 'src/app/model/ipropertybase';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.css']
})
export class AddPropertyComponent implements OnInit {
  @ViewChild('Form') addPropertyForm!: NgForm;
  @ViewChild('tabSet') tabSet!: TabsetComponent;

  propertyTypes: Array<string> = ['House', 'Apartment', 'Duplex'];
  furnishTypes: Array<string> = ['Fully', 'Semi', 'Unfurnished'];

  propertyView: Ipropertybase = {
    Id: null,
    Name: '',
    Price: null,
    SellRent: null,
    PType: '',
    FType: '',
    BHK: null,
    BuiltArea: null,
    City: '',
    RTM: null
    };
  constructor(private router: Router) { }

  ngOnInit() {
  }

  onBack() {  
    this.router.navigate(['/']);
  }

  onSubmit() {
    console.log(this.addPropertyForm);
  }

  selectTab(tabId: number) {
    this.tabSet.tabs[tabId].active = true;
  }

}
