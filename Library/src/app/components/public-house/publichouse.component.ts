import { Component, OnInit, Inject } from '@angular/core';
import { PublicHouseViewModel } from '../../models/public-house';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

import { FormGroup, FormControl, Validators } from '@angular/forms';
import { GridDataResult } from '@progress/kendo-angular-grid';
import { State, process } from '@progress/kendo-data-query';

import { tap } from 'rxjs/operators/tap';
import { map } from 'rxjs/operators/map';
import { PublicHouseService } from '../../services/public-house.service';

@Component({
  selector: 'publichouse',
  templateUrl: './publichouse.component.html'
})


export class PublicHouseComponent implements OnInit {
  public view: Observable<GridDataResult>;

  public gridState: State = {
    sort: [],
    skip: 0,
    take: 10
  };
  public formGroup: FormGroup;
  editedPublicHouse: PublicHouseViewModel;
  private editService: PublicHouseService;
  private editedRowIndex: number;

  constructor( @Inject(PublicHouseService) editServiceFactory: any)
  {

    this.editService = editServiceFactory();

  }

  public ngOnInit(): void
  {

    this.view = this.editService.pipe(map(data => process(data, this.gridState)));

    this.editService.read();
  }

  public onStateChange(state: State) {
    this.gridState = state;
    console.log(this.gridState);
    this.editService.read();
  }

  public addHandler({ sender }, formInstance) {

    formInstance.reset();
    this.closeEditor(sender);
    var newPublicHouse = new PublicHouseViewModel();
    sender.addRow(newPublicHouse);
  }

  public editHandler({ sender, rowIndex, dataItem }) {

    this.closeEditor(sender);
    this.editedRowIndex = rowIndex;
    this.editedPublicHouse = Object.assign({}, dataItem);
    console.log(sender);
    sender.editRow(rowIndex);

  }

  public cancelHandler({ sender, rowIndex })
  {
    this.closeEditor(sender, rowIndex);
  }

  public saveHandler({ sender, rowIndex, dataItem, isNew })
  {

    this.editService.save(dataItem, isNew);

    sender.closeRow(rowIndex);

    this.editedRowIndex = undefined;
    this.editedPublicHouse = undefined;
  }

  public removeHandler({ dataItem })
  {

    this.editService.remove(dataItem);
  }

  private closeEditor(grid, rowIndex = this.editedRowIndex) {

    grid.closeRow(rowIndex);
    this.editService.resetItem(this.editedPublicHouse);
    this.editedRowIndex = undefined;
    this.editedPublicHouse = undefined;
  }
}

