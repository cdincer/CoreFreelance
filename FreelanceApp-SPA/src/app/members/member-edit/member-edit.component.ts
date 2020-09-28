import { AlertifyService } from './../../_services/alertify.service';
import { User } from './../../_models/user';
import { ActivatedRoute } from '@angular/router';
import { Component, HostListener, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-member-edit',
  templateUrl: './member-edit.component.html',
  styleUrls: ['./member-edit.component.css']
})
export class MemberEditComponent implements OnInit {
  @ViewChild('editForm', {static: true}) editForm: NgForm;
  @HostListener('window:beforeunload',['$event'])
  unloadNotification($event:any)
  {
    if(this.editForm.dirty)
    {
      $event.returnValue = true;
    }
  }
  
  user: User;

  constructor(private route: ActivatedRoute, private alertify: AlertifyService) { }

  ngOnInit() {
    this.route.data.subscribe(data => {
    this.user = data['user'];
    });
  }

  updateUser()
  {
    console.log(this.user);
    this.alertify.success('Profile updated succesfully');
    this.editForm.reset(this.user);
  }

}