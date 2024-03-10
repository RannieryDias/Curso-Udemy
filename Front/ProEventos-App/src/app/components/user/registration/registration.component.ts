import { Component, OnInit } from '@angular/core';
import { AbstractControlOptions, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidatorField } from '@app/util/ValidateField';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {
  form!: FormGroup;

  get f(): any {
    return this.form.controls;
  }

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void { this.validation(); }

  private validation(): void {

    const formOptions: AbstractControlOptions = {
      validators: [ValidatorField.MustMatch('passwordField', 'passwordConfirmation'), ValidatorField.PasswordStrengthValidator('passwordField')]
    };

    this.form = this.formBuilder.group({
      titleSelection: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.email, Validators.required]],
      user: ['', [Validators.minLength(6), Validators.maxLength(10), Validators.required]],
      passwordField: ['', [Validators.minLength(8), Validators.required]],
      passwordConfirmation: ['', Validators.required],
      agreeCheck: ['', Validators.requiredTrue],
    }, formOptions);

  }
}
