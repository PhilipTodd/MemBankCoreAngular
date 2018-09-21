import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

//3rd party
import { TagCloudModule } from 'angular-tag-cloud-module';
// end 3rd party

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CodeComponent } from './code/code.component';
import { SqlComponent } from './sql/sql.component';
import { MemoryComponent } from './memory/memory.component';
import { ContactComponent } from './contact/contact.component';
//import { CounterComponent } from './counter/counter.component';
//import { FetchDataComponent } from './fetch-data/fetch-data.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CodeComponent,
    SqlComponent,
    MemoryComponent,
    ContactComponent,
    //CounterComponent,
    //FetchDataComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'CODE', component: CodeComponent },
      { path: 'SQL', component: SqlComponent },
      { path: 'MEMORY', component: MemoryComponent },
      { path: 'CONTACT', component: ContactComponent },
    ]),
    TagCloudModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
