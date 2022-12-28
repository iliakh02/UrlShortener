import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { UrlsComponent } from './pages/urls/urls.component';

@NgModule({
  declarations: [UrlsComponent],
  imports: [BrowserModule, HttpClientModule],
  providers: [],
  bootstrap: [UrlsComponent],
})
export class AppModule {}
