import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public cards: Card[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Card[]>(baseUrl + 'cards').subscribe(result => {
      this.cards = result;
    }, error => console.error(error));
  }
}

interface Card {
  id: string;
  name: number;
  itemsCount: number;
}
