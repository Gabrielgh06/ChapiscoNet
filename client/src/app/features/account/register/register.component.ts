import { Component, inject } from '@angular/core';
import { FormBuilder, ReactiveFormsModule, Validators } from '@angular/forms';
import { MatButton } from '@angular/material/button';
import { MatCard } from '@angular/material/card';
import { MatFormField, MatLabel, MatError } from '@angular/material/form-field';
import { MatInput } from '@angular/material/input';
import { AccountService } from '../../../core/services/account.service';
import { Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { JsonPipe } from '@angular/common';
import { TextInputComponent } from "../../../shared/components/text-input/text-input.component";

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [
    ReactiveFormsModule,
    MatCard,
    MatFormField,
    MatLabel,
    MatInput,
    MatButton,
    JsonPipe,
    MatError,
    TextInputComponent
],
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss',
})
export class RegisterComponent {
  private fb = inject(FormBuilder);
  private accountService = inject(AccountService);
  private route = inject(Router);
  private snack = inject(MatSnackBar);
  validationErrors?: string[];

  registerForm = this.fb.group({
    firstName: ['', Validators.required],
    lastName: ['', Validators.required],
    email: ['',[, Validators.required, Validators.email]],
    password: ['', Validators.required],
    // password: ['', Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')],
  });

  onSubmit() {
    this.accountService.register(this.registerForm.value).subscribe({
      next: () => {
        this.snack.open('Registro Completo! Agora você pode logar', 'Fechar', { duration: 3000 });
        this.route.navigateByUrl('/account/login');
      },
      error: errors => this.validationErrors = errors
    });
  }
}
