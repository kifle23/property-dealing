import { Ipropertybase } from "./ipropertybase";

export class Property implements Ipropertybase {
  Id: number | null;
  SellRent: number | null;
  Name: string;
  PType: string;
  BHK: number | null;
  FType: string;
  Price: number | null;
  BuiltArea: number | null;
  CarpetArea?: number;
  Address: string;
  Address2?: string;
  City: string;
  FloorNo?: string;
  TotalFloor?: string;
  RTM: boolean | null;
  AOP?: string;
  MainEntrance?: string;
  Security?: number | null;
  Gated?: number;
  Maintenance?: number;
  Possession?: string;
  Image?: string;
  Description?: string;
  PostedOn: string;
  PostedBy: number | null;

    constructor() {
        this.Id = null;
        this.SellRent = null;
        this.PType = '';
        this.FType = '';
        this.Name = '';
        this.Price = null;
        this.BHK = null;
        this.BuiltArea = null;
        this.City = '';
        this.RTM = null;
        this.Image = '';
        this.Address = '';
        this.PostedBy = null;
        this.PostedOn = '';
        }
}