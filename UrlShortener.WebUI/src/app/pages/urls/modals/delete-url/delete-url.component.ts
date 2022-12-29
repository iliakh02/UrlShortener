import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-delete-url',
  templateUrl: './delete-url.component.html',
  styleUrls: ['./delete-url.component.css'],
})
export class DeleteUrlComponent {
  @Input('dataFromParent') public modalRef: BsModalRef | undefined;
  @Output() onDeleteUrl = new EventEmitter();

  createNewUrlForm = this.formBuilder.group({
    fullUrl: ['', Validators.required],
  });

  constructor(private formBuilder: FormBuilder) {}

  async approveDeleting(): Promise<void> {
    this.onDeleteUrl.emit();
    this.modalRef?.hide();
  }
}
