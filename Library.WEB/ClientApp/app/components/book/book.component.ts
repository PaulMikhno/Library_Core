import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { BookViewModel } from './book';

@Component({
    selector: 'book',
    templateUrl: './book.component.html'
})

export class BookComponent {
    magazine: BookViewModel = new BookViewModel();
    public forecasts: BookViewModel[];
    public url: string;
    tableMode: boolean = true;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.url = baseUrl;
        this.loadProducts(http);
    }

    loadProducts(http: Http) {
        //debugger;
        http.get(this.url + 'api/Book/Books').subscribe(result => {
            this.forecasts = result.json() as BookViewModel[];
        }, error => console.error(error));

    }

}

