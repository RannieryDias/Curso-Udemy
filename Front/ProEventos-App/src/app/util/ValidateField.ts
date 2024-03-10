import { AbstractControl, FormGroup, ValidationErrors, ValidatorFn } from "@angular/forms";

export class ValidatorField {

  static MustMatch(controlName: string, matchingControlName: string): any {
    return (group: AbstractControl) => {
      const formGroup = group as FormGroup;
      const control = formGroup.controls[controlName];
      const matchningControl = formGroup.controls[matchingControlName];

      if (matchningControl.errors && !matchningControl.errors["mustMatch"]) {
        return null;
      }

      if (control.value !== matchningControl.value) {
        matchningControl.setErrors({ mustMatch: true });
      }
      else {
        matchningControl.setErrors(null);
      }

      return null;
    }
  }

  static PasswordStrengthValidator(controlName: string): any {
    return (group: AbstractControl) => {
      const formGroup = group as FormGroup;
      const control = formGroup.controls[controlName];
      const value = control.value;

      if (control.errors && !control.errors["passwordNotStrong"]) {
        return null;
      }

      const hasUpperCase = /[A-Z]+/.test(value);
      const hasLowerCase = /[a-z]+/.test(value);
      const hasNumeric = /[0-9]+/.test(value);
      const hasSpecialChar = /[\W_]+/.test(value); // \W is non-word characters, _ is included separately

      if (hasUpperCase && hasLowerCase && hasNumeric && hasSpecialChar) {
        control.setErrors(null);
      }
      else {
        control.setErrors({ passwordNotStrong: true })
      }

      return null;
    };
  }

  static PhoneNumberValidator(controlName: string): any {
    return (group: AbstractControl) => {
      const formGroup = group as FormGroup;
      const control = formGroup.controls[controlName];
      const value = control.value;

      if (control.errors && !control.errors['phoneNumberInvalid']) {
        return null;
      }

      const phonePattern = /^(?:(?:\+?55)?\s?\(?\d{2}\)?\s?\d{4,5}\-?\d{4})$/;

      const isValid = phonePattern.test(value);

      if (isValid) {
        control.setErrors(null);
      } else {
        control.setErrors({ phoneNumberInvalid: true });
      }

      return null;
    };
  }
}
