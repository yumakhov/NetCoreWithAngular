import { Component } from '@angular/core';
import Card from './models/card.model';
import CardsService from './services/cards-service';

@Component({
  selector: 'app-edit-card',
  templateUrl: './card-edit.component.html'
})
export class CardEditComponent {
  public card: Card;
  private cardsService: CardsService;

  constructor(cardData: Card, cardsService: CardsService) {
    this.card = cardData;
    this.cardsService = cardsService;
  }

  public save() {
    this.cardsService.updateCard(this.card).subscribe(result => {
        this.card = result;
      }, error => console.error(error));

    //TODO: add redirection to list
  }
}