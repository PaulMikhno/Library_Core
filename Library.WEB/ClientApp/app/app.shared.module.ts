import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
//import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { MagazineComponent } from './components/magazine/magazine.component';
import { BrochureComponent } from './components/brochure/brochure.component';
import { BookComponent } from './components/book/book.component';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        HomeComponent,
        MagazineComponent,
        BrochureComponent,
        BookComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'magazine', component: MagazineComponent },
            { path: 'brochure', component: BrochureComponent },
            { path: 'book', component: BookComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ]
})
export class AppModuleShared
{

}
