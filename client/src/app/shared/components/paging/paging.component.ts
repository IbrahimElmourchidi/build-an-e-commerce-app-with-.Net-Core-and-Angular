import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-paging',
  templateUrl: './paging.component.html',
  styleUrls: ['./paging.component.scss'],
})
export class PagingComponent implements OnInit {
  @Input('pageIndex') pageIndex: number = 1;
  @Input('pageSize') pageSize: number = 6;
  @Input('totalCount') totalCount: number = 0;
  @Output('currentPage') currentPage: EventEmitter<number> =
    new EventEmitter<number>();
  constructor() {}

  ngOnInit(): void {}

  emitCurrentPage(val: number) {
    this.currentPage.emit(val);
  }
}
