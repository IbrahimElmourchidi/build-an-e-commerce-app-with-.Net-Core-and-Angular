import { Injectable } from '@angular/core';

export interface IToast {
  id: string;
  type: 'error' | 'success' | 'info';
  text: string;
}

@Injectable({
  providedIn: 'root',
})
export class ToastService {
  notificationList: IToast[] = [];
  constructor() {}

  showError(text: string, time: number = 3000) {
    console.log(text, 'error');

    let id = Math.random().toString();
    this.notificationList.push({
      id,
      text,
      type: 'error',
    });
    setTimeout(() => {
      let index = this.notificationList.findIndex((el) => el.id == id);
      this.notificationList.splice(index, 1);
    }, time);
  }

  showSuccess(text: string, time: number = 3000) {
    let id = Math.random().toString();
    this.notificationList.push({
      id,
      text,
      type: 'success',
    });
    setTimeout(() => {
      let index = this.notificationList.findIndex((el) => el.id == id);
      this.notificationList.splice(index, 1);
    }, time);
  }

  showInfo(text: string, time: number = 3000) {
    let id = Math.random().toString();
    this.notificationList.push({
      id,
      text,
      type: 'info',
    });
    setTimeout(() => {
      let index = this.notificationList.findIndex((el) => el.id == id);
      this.notificationList.splice(index, 1);
    }, time);
  }
}
