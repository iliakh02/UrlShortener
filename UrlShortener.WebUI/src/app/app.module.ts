import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { UrlsComponent } from './pages/urls/urls.component';

@NgModule({
  declarations: [UrlsComponent],
  imports: [BrowserModule, HttpClientModule, FontAwesomeModule],
  providers: [],
  bootstrap: [UrlsComponent],
})
export class AppModule {}
