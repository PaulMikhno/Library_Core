import { Component, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { BookViewModel } from './book';

@Component({
    selector: 'book',
    templateUrl: './book.component.html'
})

export class BookComponent
{
    book: BookViewModel = new BookViewModel();
    public forecasts: BookViewModel[];
    public url: string;
    tableMode: boolean = true;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.url = baseUrl;
        this.loadProducts(http);
    }

    loadProducts(http: Http)
    {
        //debugger;
        http.get(this.url + 'api/Book/Books').subscribe(result => {
            this.forecasts = result.json() as BookViewModel[];
        }, error => console.error(error));

    }

    save()
    {
        //debugger;

        if (this.book.id == null) {
            debugger;
            let route = (this.url + "api/Book/CreateBook");

            this.http.post(route, this.book).subscribe(data => this.loadProducts(this.http));
        }
        if (this.book.id != null) {
            this.http.post('api/Book/UpdateBook/' + this.book.id, this.book).subscribe(data => this.loadProducts(this.http));
        }

        this.cancel();
        //return this.http.post(this.url + 'api/Magazine/Create', magazine);
    }
    updateBook(bookToUpdate: BookViewModel)
    {

        //return this.http.post(this.url + 'api/Magazine/Update', magazine);
        this.book = bookToUpdate;
    }
    deleteBook(id: number)
    {
       // debugger;

        return this.http.delete(this.url + 'api/Book/DeleteBook/' + id).map((response: Response) => response.json()).subscribe((data) => {
            this.loadProducts(this.http);
        }, error => console.error(error));
    }
    cancel()
    {
        this.book = new BookViewModel();
        this.tableMode = true;
    }
    Add()
    {
        this.cancel();
        this.tableMode = false;
    }
}

