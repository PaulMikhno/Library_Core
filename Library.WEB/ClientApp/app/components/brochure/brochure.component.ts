import { Component, Inject} from '@angular/core';
import { Http } from '@angular/http';
import { BrochureViewModel } from './brochure';

@Component({
    selector: 'brochure',
    templateUrl: './brochure.component.html'
})

export class BrochureComponent {
    magazine: BrochureViewModel = new BrochureViewModel();
    public forecasts: BrochureViewModel[];
    public url: string;
    tableMode: boolean = true;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
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
}

