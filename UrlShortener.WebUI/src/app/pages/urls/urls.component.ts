import { Component, OnInit, TemplateRef } from '@angular/core';
import { faTrash } from '@fortawesome/free-solid-svg-icons';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { Url } from 'src/app/models/url';
import { UrlService } from 'src/app/services/url.service';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './urls.component.html',
  styleUrls: ['./urls.component.css'],
})
export class UrlsComponent implements OnInit {
  public urls?: Url[];
  public faTrash = faTrash;
  public createNewUrlModalRef?: BsModalRef;
  public deleteAllUrlsModalRef?: BsModalRef;
  public deleteUrlModalRef?: BsModalRef;
  private deleteUrlId: number | undefined;

  constructor(
    private modalService: BsModalService,
    private urlService: UrlService,
  ) {}

  async ngOnInit(): Promise<void> {
    this.refreshData();
  }

  refreshData(): void {
    this.urlService.getAllUrls().subscribe((response) => {
      this.urls = response;
    });
  }

  async deleteUrlById() : Promise<void> {
    if(this.deleteUrlId !== undefined) {
      await firstValueFrom(this.urlService.deleteUrl(this.deleteUrlId));
      this.refreshData();
    }
  }

  openCreateNewUrlModal(template: TemplateRef<any>) {
    this.createNewUrlModalRef = this.modalService.show(template);
  }

  openDeleteAllUrlsModal(template: TemplateRef<any>) {
    this.deleteAllUrlsModalRef = this.modalService.show(template);
  }

  openDeleteUrlModal(template: TemplateRef<any>, deleteUrlId: number) {
    this.deleteUrlId = deleteUrlId;
    this.deleteUrlModalRef = this.modalService.show(template);
  }
}
