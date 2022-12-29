import { Component, Input, EventEmitter, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { UrlService } from 'src/app/services/url.service';
import { firstValueFrom } from 'rxjs';

@Component({
  selector: 'app-create-new-url',
  templateUrl: './create-new-url.component.html',
  styleUrls: ['./create-new-url.component.css'],
})
export class CreateNewUrlComponent {
  @Input('dataFromParent') public modalRef: BsModalRef | undefined;
  @Output() onRefreshData = new EventEmitter();

  createNewUrlForm = this.formBuilder.group({
    fullUrl: ['', Validators.required],
  });

  constructor(
    private formBuilder: FormBuilder,
    private urlService: UrlService
  ) {}

  async onSubmit(): Promise<void> {
    const longUrl = this.createNewUrlForm.value.fullUrl;
    if (!!longUrl) await firstValueFrom(this.urlService.createNewUrl(longUrl));
    this.onRefreshData.emit();
    this.modalRef?.hide();
  }
}
