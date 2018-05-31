import { Component, Inject} from '@angular/core';
import { Http, Response } from '@angular/http';
import { BrochureViewModel } from './brochure';

@Component({
    selector: 'brochure',
    templateUrl: './brochure.component.html'
})

export class BrochureComponent {
    brochure: BrochureViewModel = new BrochureViewModel();
    public forecasts: BrochureViewModel[];
    public url: string;
    tableMode: boolean = true;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string)
    {

        this.url = baseUrl;
        this.loadProducts(http);

    }

    loadProducts(http: Http)
    {
        //debugger;
        http.get(this.url + 'api/Brochure/Brochures').subscribe(result => {
            this.forecasts = result.json() as BrochureViewModel[];
        }, error => console.error(error));

    }

    save()
    {
       // debugger;

        if (this.brochure.id == null) {
            debugger;
            let route = (this.url + "api/Brochure/CreateBrochure");

            this.http.post(route, this.brochure).subscribe(data => this.loadProducts(this.http));
        }
        if (this.brochure.id != null) {
            this.http.post('api/Brochure/UpdateBrochure/' + this.brochure.id, this.brochure).subscribe(data => this.loadProducts(this.http));
        }

        this.cancel();
        //return this.http.post(this.url + 'api/Magazine/Create', magazine);
    }
    updateBrochure(magazineToUpdate: BrochureViewModel) {

        //return this.http.post(this.url + 'api/Magazine/Update', magazine);
        this.brochure = magazineToUpdate;
    }
    deleteBrochure(id: number)
    {
       // debugger;
       
        return this.http.delete(this.url + 'api/Brochure/DeleteBrochure/' + id).map((response: Response) => response.json()).subscribe((data) => {
            this.loadProducts(this.http);
        }, error => console.error(error));
    }
    cancel() {
        this.brochure = new BrochureViewModel();
        this.tableMode = true;
    }
    Add() {
        this.cancel();
        this.tableMode = false;
    }
}

