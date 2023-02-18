import { Component, OnInit } from '@angular/core';
import { BusyService } from '../services/busy.service';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.scss'],
})
export class SpinnerComponent implements OnInit {
  constructor(private busyService: BusyService) {}

  get isBusy() {
    return this.busyService.busyRequestCount > 0;
  }

  ngOnInit(): void {}
}
