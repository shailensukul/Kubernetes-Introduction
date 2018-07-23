import { Component, OnInit, Input, ElementRef  } from '@angular/core';

@Component({
  selector: 'app-hello-page',
  templateUrl: './hello-page.component.html',
  styleUrls: ['./hello-page.component.css']
})
export class HelloPageComponent implements OnInit {
  //@Input() 
  context: any;

  constructor(public elemRef:ElementRef) {
    this.context = this.elemRef.nativeElement.getAttribute("context"); 

   }

  ngOnInit() {
    this.writeContext();
  }

  writeContext() {
    var contextlocal = JSON.parse(localStorage.getItem(this.context));
    document.getElementById("divHello").innerHTML= "[Ng Element] Loading from " + contextlocal._title;
    //document.getElementById("divHello").innerText= "[Ng Element] Loading from " + this.mycontext;
  }
}
