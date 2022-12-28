import { Component, OnInit, Input, EventEmitter, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { UrlService } from 'src/app/services/url.service';

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

  onSubmit(): void {
    const longUrl = this.createNewUrlForm.value.fullUrl;
    if (!!longUrl)
      this.urlService.createNewUrl(longUrl).subscribe((data) => {
        console.log(data);
      });
    this.onRefreshData.emit();
    console.warn('Your order has been submitted', this.createNewUrlForm.value);
    this.createNewUrlForm.reset();
  }
}
