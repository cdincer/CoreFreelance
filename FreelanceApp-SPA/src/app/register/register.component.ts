import { AlertifyService } from './../_services/alertify.service';
import { AuthService } from './../_services/auth.service';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();

  model: any = {};

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
  }

  // tslint:disable-next-line: typedef
  register()
  {
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('registration succesful');
    }, error => {
      this.alertify.error(error);
    });
  }

  // tslint:disable-next-line: typedef
  cancel()
  {
    this.cancelRegister.emit(false);
    this.alertify.message('cancelled');
  }
}
