import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import axios from 'axios';

@Component({
  selector: 'app-root',
  templateUrl: './urls.component.html',
  styleUrls: ['./urls.component.css'],
})
export class UrlsComponent implements OnInit {
  public urls?: Url[];
  private httpClient: HttpClient;
  constructor(httpClient: HttpClient) {
    this.httpClient = httpClient;
  }
  async ngOnInit(): Promise<void> {
    console.log('--- Calling api get method!');

    // let response = await axios.get('/api/Urls/allUrls');
    // this.url = response.data;
    // console.log('-----x----' + this.url);

    this.httpClient.get<Url[]>('/api/Urls/allUrls').subscribe((response) => {
      this.urls = response;
    });
  }

  title = 'UrlShortener';
}

interface Url {
  id: number;
  shortUrl: string;
  fullUrl: string;
  createdBy: string;
  createdDate: Date;
}
