import { HttpClient } from '@angular/common/http';
import {
  Component,
  EventEmitter,
  OnInit,
  Output,
  TemplateRef,
} from '@angular/core';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Url } from 'src/app/models/url';
import { UrlService } from 'src/app/services/url.service';
// import

@Component({
  selector: 'app-root',
  templateUrl: './urls.component.html',
  styleUrls: ['./urls.component.css'],
})
export class UrlsComponent implements OnInit {
  public urls?: Url[];
  private httpClient: HttpClient;
  public faTrash = faTrash;
  public modalRef?: BsModalRef;
  @Output() refreshingData = new EventEmitter<any>();

  constructor(
    httpClient: HttpClient,
    private modalService: BsModalService,
    private urlService: UrlService
  ) {
    this.httpClient = httpClient;
  }
  async ngOnInit(): Promise<void> {
    this.refreshData();
  }
  refreshData(): void {
    this.urlService.getAllUrls().subscribe((response) => {
      this.urls = response;
    });
  }
  dataRefresher(): any {
    return () => this.refreshData();
  }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template);
  }
}
