import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, AbstractControlOptions, Validators } from '@angular/forms';
import { ValidatorField } from '@app/util/ValidateField';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  form!: FormGroup;

  get f(): any {
    return this.form.controls;
  }

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit(): void { this.validation(); }

  private validation(): void {
    const formOptions: AbstractControlOptions = {
      validators: [ValidatorField.MustMatch('passwordField', 'passwordConfirmation'),
                   ValidatorField.PasswordStrengthValidator('passwordField'),
                   ValidatorField.PhoneNumberValidator('phone')]
    };

    this.form = this.formBuilder.group({
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', [Validators.email, Validators.required]],
      phone: ['', [Validators.required]],
      passwordField: ['', [Validators.minLength(8), Validators.required]],
      passwordConfirmation: ['', Validators.required],
    }, formOptions);
  }
}
