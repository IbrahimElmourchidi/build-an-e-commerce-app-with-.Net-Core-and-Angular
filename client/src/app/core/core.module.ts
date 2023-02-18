import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { RouterModule } from '@angular/router';
import { TestErrorComponent } from './test-error/test-error.component';
import { NotfoundComponent } from './notfound/notfound.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { ToastComponent } from './toast/toast.component';
import { SectionHeaderComponent } from './section-header/section-header.component';
import { BreadcrumbModule } from 'xng-breadcrumb';
import { SpinnerComponent } from './spinner/spinner.component';

@NgModule({
  declarations: [
    NavBarComponent,
    TestErrorComponent,
    NotfoundComponent,
    ServerErrorComponent,
    ToastComponent,
    SectionHeaderComponent,
    SpinnerComponent,
  ],
  imports: [CommonModule, RouterModule, BreadcrumbModule],
  exports: [
    NavBarComponent,
    ToastComponent,
    SectionHeaderComponent,
    SpinnerComponent,
  ],
})
export class CoreModule {}
