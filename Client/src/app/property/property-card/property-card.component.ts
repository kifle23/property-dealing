import { Component, OnInit, Input } from '@angular/core';
import { Ipropertybase } from 'src/app/model/ipropertybase';

@Component({
  selector: 'app-property-card',
  templateUrl: './property-card.component.html',
  styleUrls: ['./property-card.component.css'],
})
export class PropertyCardComponent {
  @Input() property!: Ipropertybase;
  @Input() hideIcons!: boolean;
}
