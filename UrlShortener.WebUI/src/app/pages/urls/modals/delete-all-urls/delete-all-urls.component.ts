import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { UrlService } from 'src/app/services/url.service';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-delete-all-urls',
  templateUrl: './delete-all-urls.component.html',
  styleUrls: ['./delete-all-urls.component.css'],
})
export class DeleteAllUrlsComponent {
  @Input('dataFromParent') public modalRef: BsModalRef | undefined;
  @Output() onRefreshData = new EventEmitter();

  createNewUrlForm = this.formBuilder.group({
    fullUrl: ['', Validators.required],
  });

  constructor(
    private formBuilder: FormBuilder,
    private urlService: UrlService
  ) {}

  async approveDeleting(): Promise<void> {
    await firstValueFrom(this.urlService.deleteAllUrls());
    this.onRefreshData.emit();
    this.modalRef?.hide();
  }
}
