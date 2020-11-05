import { PaginatedResult, Pagination } from './../../_models/pagination';
import { ActivatedRoute } from '@angular/router';
import { AlertifyService } from './../../_services/alertify.service';
import { UserService } from './../../_services/user.service';
import { User } from './../../_models/user';
import { Component, OnInit } from '@angular/core';


@Component({
  selector: 'app-member-list',
  templateUrl: './member-list.component.html',
  styleUrls: ['./member-list.component.scss']
})
export class MemberListComponent implements OnInit {
  users: User[];
  user: User = JSON.parse(localStorage.getItem('user'));
  userParams: any = {};
  pagination: Pagination;

  constructor(private userService: UserService, private alertify: AlertifyService, private route: ActivatedRoute) { }



  ngOnInit()
  {
    this.route.data.subscribe(data => {
    this.users = data['users'].result;
    this.pagination = data['users'].pagination;
    });

    this.userParams.minExperience = 2;
    this.userParams.maxExperience = 25;
    this.userParams.orderBy = 'lastActive';
  }

  resetFilters(){
    this.userParams.minExperience = 1;
    this.userParams.maxExperience = 20;
    this.loadUsers();
  }




pageChanged(event: any): void {
  this.pagination.currentPage = event.page;
  this.loadUsers();
  console.log(this.pagination.currentPage);
}


   loadUsers() {
     // console.log('event fired');
     this.userService.getUsers(this.pagination.currentPage, this.pagination.itemsPerPage, this.userParams)
    .subscribe((res: PaginatedResult<User[]>) => {
      this.users = res.result;
      this.pagination = res.pagination;
    }, error => {
      this.alertify.error(error);
    });
  }

}
