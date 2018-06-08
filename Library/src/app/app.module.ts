import { BrowserModule } from '@angular/platform-browser';

import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';

import { FormsModule } from '@angular/forms';

import { HttpModule } from '@angular/http';

import { GridModule } from '@progress/kendo-angular-grid';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { RouterModule } from '@angular/router';

import { NavMenuComponent } from './components/navmenu/navmenu.component';

import { MagazineComponent } from './components/magazine/magazine.component';

import { BrochureComponent } from './components/brochure/brochure.component';

import { BookComponent } from './components/book/book.component';

import { PublicHouseComponent } from './components/public-house/publichouse.component';

import { HttpClient, HttpClientModule, HttpClientJsonpModule } from '@angular/common/http';


import { PublicHouseService } from './services/public-house.service';
import { MagazineService } from './services/magazine.service';
import { BrochureService } from './services/brochure.service';
import { BookService } from './services/book.service';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    NavMenuComponent,
    AppComponent,
    MagazineComponent,
    BrochureComponent,
    BookComponent,
    PublicHouseComponent,
  ],
  imports: [
    ReactiveFormsModule,
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    BrowserAnimationsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'magazine', pathMatch: 'full' },
      { path: 'magazine', component: MagazineComponent },
      { path: 'brochure', component: BrochureComponent },
      { path: 'book', component: BookComponent },
      { path: 'publichouse', component: PublicHouseComponent },
      { path: '**', redirectTo: 'magazine' }
    ]),
    GridModule
  ],
  providers: [
    {
      deps: [HttpClient],
      provide: PublicHouseService,
      useFactory: (jsonp: HttpClient) => () => new PublicHouseService(jsonp)
    },
    {
      deps: [HttpClient],
      provide: MagazineService,
      useFactory: (jsonp: HttpClient) => () => new MagazineService(jsonp)
    },
    {
      deps: [HttpClient],
      provide: BrochureService,
      useFactory: (jsonp: HttpClient) => () => new BrochureService(jsonp)
    },
    {
      deps: [HttpClient],
      provide:BookService,
      useFactory: (jsonp: HttpClient) => () => new BookService(jsonp)
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
