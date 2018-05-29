import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { MagazineViewModel } from './magazine';

@Component({
    selector: 'magazine',
    templateUrl: './magazine.component.html'
})

export class MagazineComponent
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

    save()
    {
        //debugger;

        if (this.magazine.id == null)
        {
           
            let  route = (this.url + "api/Magazine/Create/");
            (this.url + "api/Magazine/Create/")
           // this.http.post(this.url, this.magazine);
            return this.http.post(route, this.magazine);
        }
        if (this.magazine.id!=null)
        {
           this.http.post('api/Magazine/Update/' + this.magazine.id, this.magazine).subscribe(data => this.loadProducts(this.http));
        }
        this.cancel();
        //return this.http.post(this.url + 'api/Magazine/Create', magazine);
    }
    updateMagazine(magazineToUpdate: MagazineViewModel)
    {
       
        //return this.http.post(this.url + 'api/Magazine/Update', magazine);
        this.magazine = magazineToUpdate;

    }
    deleteMagazine(id: number)
    {
        debugger;
        return this.http.delete(this.url + 'api/Magazine/Delete/' + id);
    }
    cancel()
    {
        this.magazine = new MagazineViewModel();
        this.tableMode = true;
    }
    Add()
    {
        this.cancel();
        this.tableMode = false;
    }
}

