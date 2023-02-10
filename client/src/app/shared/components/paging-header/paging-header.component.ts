import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-paging-header',
  templateUrl: './paging-header.component.html',
  styleUrls: ['./paging-header.component.scss'],
})
export class PagingHeaderComponent implements OnInit {
  @Input('pageIndex') pageIndex: number = 1;
  @Input('pageSize') pageSize: number = 6;
  @Input('totalCount') totalCount: number = 0;
  constructor() {}

  ngOnInit(): void {}

  getCurrentRange() {
    let from = (this.pageIndex - 1) * this.pageSize + 1;
    let to = from + this.pageSize - 1;
    return `${from} to ${to > this.totalCount ? this.totalCount : to}`;
  }
}
