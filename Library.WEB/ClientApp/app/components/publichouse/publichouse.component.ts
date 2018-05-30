import { Component, Inject } from '@angular/core';
import { Http, Response } from '@angular/http';
import { PublicHouseViewModel } from './publichouse';
import 'rxjs/add/operator/map';  

@Component({
    selector: 'publichouse',
    templateUrl: './publichouse.component.html'
})

export class PublicHouseComponent {
    publicHouse: PublicHouseViewModel = new PublicHouseViewModel();
    public forecasts: PublicHouseViewModel[];
    public url: string;
    tableMode: boolean = true;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string)
    {
        debugger;
        this.url = baseUrl;
        this.loadPublicHouses();
    }

    loadPublicHouses()
    {
        debugger;
        this.http.get(this.url + 'api/PublicHouse/PublicHouses').subscribe(result => {
            this.forecasts = result.json() as PublicHouseViewModel[];
        }, error => console.error(error));

    }    
    deletePublicHouse(Id: number)
    {
        return this.http.delete(this.url + "api/PublicHouse/DeletePublicHouse/" + Id).map((response: Response) => response.json()).subscribe((data) => {
            this.loadPublicHouses();
        }, error => console.error(error))  ;
    }
    cancel()
    {
        this.publicHouse = new PublicHouseViewModel();
        this.tableMode = true;
    }
    Add()
    {
        this.cancel();
        this.tableMode = false;
    }
    save()
    {

        if (this.publicHouse.id == null) {
            debugger;
            let route = (this.url + "api/PublicHouse/CreatePublicHouse");

            this.http.post(route, this.publicHouse).subscribe(data => this.loadPublicHouses());
        }
        if (this.publicHouse.id != null) {
            this.http.post('api/PublicHouse/UpdatePublicHouse/' + this.publicHouse.id, this.publicHouse).subscribe(data => this.loadPublicHouses());
        }

        this.cancel();
        
    }
    updatePublicHouse(publiHouseToUpdate: PublicHouseViewModel)
    {
        this.publicHouse = publiHouseToUpdate;
        debugger;
    }
}