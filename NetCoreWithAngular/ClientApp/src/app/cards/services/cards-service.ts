import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import Card from '.././models/card.model';

@Injectable()
export default class CardsService {
    private http: HttpClient;
    private baseUrl: string;
    constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.http = http;
        this.baseUrl = baseUrl;
    }

    public getAllCards() {
        return this.http.get<Card[]>(this.baseUrl + 'cards');
    }

    public updateCard(cardData: Card) {
        return this.http.put<Card>(this.baseUrl + 'cards', cardData);
    }

    public createCard(cardData: Card) {
        return this.http.post<Card>(this.baseUrl + 'cards', cardData);
    }
}