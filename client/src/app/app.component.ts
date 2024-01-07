import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Sysmcltd app';
  users: any;

  constructor(private http: HttpClient, private toastr: ToastrService) {}

  ngOnInit(): void {
     this.http.get('http://localhost:5159/api/users').subscribe({
       next: response => this.users = response,
       error: error => this.toastr.error(error.error),
       complete: () => console.log('Request has completed')
     })
   }
  
}
