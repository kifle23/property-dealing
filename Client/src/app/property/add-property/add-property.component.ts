import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TabsetComponent } from 'ngx-bootstrap/tabs';
import { Ipropertybase } from 'src/app/model/ipropertybase';

@Component({
  selector: 'app-add-property',
  templateUrl: './add-property.component.html',
  styleUrls: ['./add-property.component.css'],
})
export class AddPropertyComponent implements OnInit {
  @ViewChild('tabSet') tabSet!: TabsetComponent;
  addPropertyForm!: FormGroup;

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
    RTM: null,
  };
  constructor(private fb: FormBuilder, private router: Router) {}

  ngOnInit() {
    this.CreateAddPropertyForm();
  }

  CreateAddPropertyForm() {
    this.addPropertyForm = this.fb.group({
      SellRent: [null, Validators.required],
      Name: [null, Validators.required],
      Price: [null, Validators.required],
      BuiltArea: [null, Validators.required],
    });
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
