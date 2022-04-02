import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Card from './models/card.model';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html'
})
export class CardsComponent {
  public cards: Card[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Card[]>(baseUrl + 'cards').subscribe(result => {
      this.cards = result;
    }, error => console.error(error));
  }
}
