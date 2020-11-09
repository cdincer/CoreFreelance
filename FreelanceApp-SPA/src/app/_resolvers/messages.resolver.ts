import { AuthService } from './../_services/auth.service';
import { catchError } from 'rxjs/operators';
import { AlertifyService } from '../_services/alertify.service';
import { UserService } from '../_services/user.service';
import { Injectable } from '@angular/core';
import {ActivatedRouteSnapshot, Resolve, Router} from '@angular/router'
import { Observable, of } from 'rxjs';
import { Message } from '../_models/message';

@Injectable()
export class MessagesResolver implements Resolve<Message[]> {
    pageNumber = 1;
    pageSize = 5;
    messageContrainer = 'Unread';

    constructor(private userService: UserService, private router: Router, private alertify: AlertifyService, private authService: AuthService)
   {

   }

   resolve(route: ActivatedRouteSnapshot): Observable<Message[]>{

    return this.userService.getMessages(this.authService.decodedToken.nameid , this.pageNumber, this.pageSize, this.messageContrainer).pipe(
        catchError(error => {
            this.alertify.error('Problem retrieving messages');
            this.router.navigate(['/home']);
            return of(null);
        })
    );
   }


}