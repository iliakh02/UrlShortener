import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import axios from "axios";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public url?: any;

    async ngOnInit(): Promise<void> {
      console.log("--- Calling api get method!");

      let responce = await axios.get('/api/Urls/getShortLink');
      this.url = responce.data;
      console.log("-----x----" + this.url);

    }

  
  

  title = 'UrlShortener';
}


