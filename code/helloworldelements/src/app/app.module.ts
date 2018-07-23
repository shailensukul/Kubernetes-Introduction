import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';


import { AppComponent } from './app.component';
import { HelloPageComponent } from './hello-page/hello-page.component';


@NgModule({
  declarations: [
    AppComponent,
    HelloPageComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
 // bootstrap: [AppComponent]
  bootstrap: [HelloPageComponent]
})
export class AppModule { }
