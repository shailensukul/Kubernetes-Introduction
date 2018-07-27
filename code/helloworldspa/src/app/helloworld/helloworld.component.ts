import { Component, OnInit } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-helloworld',
  templateUrl: './helloworld.component.html',
  styleUrls: ['./helloworld.component.css']
})
export class HelloworldComponent implements OnInit {

  messages: any;
  //url = "http://helloworldapiazure.shailensukul.com/api/mongodb";
  url = "http://helloworldapigoogle.shailensukul.com/api/mongodb";
  //url = "http://localhost:8082/api/mongodb";
  headers = new HttpHeaders(
    {
    'Access-Control-Allow-Origin': '*',
    'Access-Control-Allow-Methods': 'GET, POST, OPTIONS, PUT, PATCH, DELETE',
    'Access-Control-Allow-Headers': 'X-Requested-With,content-type',
    'Access-Control-Allow-Credentials': 'true' 
}
);
  constructor(private http: HttpClient) 
  { 
    this.getMessages();
  }

  ngOnInit() {
  }

  createMessage(name, message, createdBy) {
    var mes = {
      "id": null,
      "name": name,
      "message": message,
      "createdBy" : createdBy,
      "createdDate" : new Date().toJSON()
    };

    

    this.http.post(this.url, mes, { headers: this.headers})
    .subscribe(
      (val) => {
          console.log("POST call successful value returned in body", 
                      val);
      },
      response => {
          console.log("POST call in error", response);
      },
      () => {
          console.log("The POST observable is now completed.");
          this.getMessages();
      });    
    
  }

  getMessages() {
    this.messages = this.http.get(this.url, {headers: this.headers});
  }

  deleteMessage(id) {
    this.http.delete(this.url + "/" + id, {headers: this.headers})
    .subscribe(
      (val) => {
          console.log("DELETE call successful value returned in body", 
                      val);
      },
      response => {
          console.log("DELETE call in error", response);
      },
      () => {
          console.log("The DELETE observable is now completed.");
          this.getMessages();
      });    
  }
}
