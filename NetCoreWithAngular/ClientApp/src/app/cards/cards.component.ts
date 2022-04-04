import { Component } from '@angular/core';
import Card from './models/card.model';
import CardsService from './services/cards-service';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html'
})
export class CardsComponent {
  public cards: Card[] = [];

  constructor(cardsService: CardsService) {
    cardsService.getAllCards().subscribe(result => {
      this.cards = result;
    }, error => console.error(error));
  }
}
