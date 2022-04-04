import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import Card from './models/card.model';
import CardsService from './services/cards-service';

@Component({
  selector: 'app-edit-card',
  templateUrl: './card-edit.component.html'
})
export class CardEditComponent {
  private isNewCard: boolean = false;
  private routeSub: Subscription;
  public card: Card = {
    id: '',
    name: '',
    itemsCount: 0
  };
  
  constructor(private cardsService: CardsService, private router: Router, private activeRoute: ActivatedRoute) {    
  }

  ngOnInit() {
    this.routeSub = this.activeRoute.params.subscribe(params => {
      let cardId = params['id'];
      if (!cardId) {
        this.isNewCard = true;
        return;
      }

      this.cardsService.get(cardId).subscribe(result => {
        this.card = result;
      }, error => console.error(error));
      
    }, error => console.error(error)
    );
  }

  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

  public save() {
    if (this.isNewCard) {
      this.cardsService.createCard(this.card).subscribe(result => {
        this.card = result;
      }, error => console.error(error));
    } else {
      this.cardsService.updateCard(this.card).subscribe(result => {
        this.card = result;
      }, error => console.error(error));
    }

    

    this.router.navigate(['']);
  }
}