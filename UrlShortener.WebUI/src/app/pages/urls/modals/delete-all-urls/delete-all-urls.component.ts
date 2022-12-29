import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { UrlService } from 'src/app/services/url.service';

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

  approveDeleting(): void {
    this.urlService.deleteAllUrls().subscribe((data) => {
      console.log(data);
    });
    this.onRefreshData.emit();
  }
}
