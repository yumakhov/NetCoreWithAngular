import { Component } from '@angular/core';
import Card from './models/card.model';
import CardsService from './services/cards-service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html'
})
export class CardsComponent {
  public cards: Card[] = [];
  private router: Router;

  constructor(cardsService: CardsService, router: Router) {
    this.router = router;
    cardsService.getAllCards().subscribe(result => {
      this.cards = result;
    }, error => console.error(error));
  }

  public edit(card: Card) {
    this.router.navigate(['/card', card.id ]);
  }

  public create() {
    this.router.navigate(['/card']);
  }
}
