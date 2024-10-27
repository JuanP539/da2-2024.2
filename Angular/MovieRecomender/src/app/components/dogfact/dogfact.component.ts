import { Component } from '@angular/core';
import { DogFactService } from '../../services/dog-fact.service';

@Component({
  selector: 'app-dogfact',
  standalone: true,
  imports: [],
  templateUrl: './dogfact.component.html',
  styleUrl: './dogfact.component.scss'
})
export class DogfactComponent {

  constructor(public dogFactService: DogFactService){ }

  getDogFact(){
    this.dogFactService.getDogFact();
  }

}
