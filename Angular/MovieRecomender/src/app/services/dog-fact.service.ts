import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Dogfact } from '../interfaces/dogfact';

@Injectable({
  providedIn: 'root'
})
export class DogFactService {

  constructor(private http: HttpClient) { }

  facts: string[] = [];
  lastFact : string = "";
  getDogFact(){
  this.http.get("https://dog-api.kinduff.com/api/facts").subscribe(value => {
    this.lastFact = (value as Dogfact).facts[0];
    this.facts.push(this.lastFact);
  } )
  }
}
