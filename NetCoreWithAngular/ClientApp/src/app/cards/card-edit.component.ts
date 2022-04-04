import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
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
  public cardForm: FormGroup = new FormGroup({
    name: new FormControl('', [
      Validators.required,
      Validators.maxLength(200)
    ]),
    itemsCount: new FormControl('', [
      Validators.required,
      Validators.pattern(/^[0-9]*$/)
    ])
  });
  
  get name(): FormControl { return this.cardForm.get('name') as FormControl; }
  get itemsCount(): FormControl { return this.cardForm.get('itemsCount') as FormControl; }

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
        this.name.setValue(result.name);
        this.itemsCount.setValue(result.itemsCount);
      }, error => console.error(error));
      
    }, error => console.error(error)
    );
  }

  ngOnDestroy() {
    this.routeSub.unsubscribe();
  }

  public save() {
    this.card.name = this.name.value;
    this.card.itemsCount = this.itemsCount.value;
    console.log("this.cardForm.value", this.cardForm.value);
    console.log("this.card", this.card);
    if (this.cardForm.invalid) {
      console.log("Form data is invalid");
      return;
    }

    if (this.isNewCard) {
      this.cardsService.createCard(this.card).subscribe(result => {
        this.card = result;
        this.goHome();
      }, error => console.error(error));
    } else {
      this.cardsService.updateCard(this.card).subscribe(result => {
        this.card = result;
        this.goHome();
      }, error => console.error(error));
    }    
  }

  private goHome() {
    this.router.navigate(['']);
  }
}