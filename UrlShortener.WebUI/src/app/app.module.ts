import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { ModalModule, BsModalService } from 'ngx-bootstrap/modal';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';

import { UrlsComponent } from './pages/urls/urls.component';
import { CreateNewUrlComponent } from './pages/urls/ng-materials/create-new-url/create-new-url.component';
import { UrlService } from './services/url.service';

@NgModule({
  declarations: [UrlsComponent, CreateNewUrlComponent],
  imports: [
    BrowserModule,
    HttpClientModule,
    FontAwesomeModule,
    FormsModule,
    // BsDropdownModule.forRoot(),
    ModalModule.forRoot(),
    BsDatepickerModule.forRoot(),
    ReactiveFormsModule,
    FormsModule,
  ],
  providers: [BsModalService, UrlService],
  bootstrap: [UrlsComponent],
})
export class AppModule {}
