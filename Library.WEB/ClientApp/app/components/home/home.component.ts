import { Component, Inject} from '@angular/core';
import { Http } from '@angular/http';
import { MagazineViewModel } from '../fetchdata/magazine';

@Component({
    selector: 'home',
    templateUrl: './home.component.html'
})

export class HomeComponent
{
    magazine: MagazineViewModel = new MagazineViewModel();
    public forecasts: MagazineViewModel[];
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
        http.get(this.url + 'api/Magazine/Magazines').subscribe(result => {
            this.forecasts = result.json() as MagazineViewModel[];
        }, error => console.error(error));

    }    

}
