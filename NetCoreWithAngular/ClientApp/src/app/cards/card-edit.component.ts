import { Component } from '@angular/core';
import Card from './models/card.model';
import CardsService from './services/cards-service';

@Component({
  selector: 'app-edit-card',
  templateUrl: './card-edit.component.html'
})
export class CardEditComponent {
  public card: any;
  private cardsService: CardsService;

  constructor(cardsService: CardsService) {
    this.cardsService = cardsService;
    this.card = { };
  }

  public save() {
    this.cardsService.updateCard(this.card).subscribe(result => {
        this.card = result;
      }, error => console.error(error));

    //TODO: add redirection to list
  }
}