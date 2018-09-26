import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material.app';

import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

//3rd party
import { TagCloudModule } from 'angular-tag-cloud-module';
// end 3rd party

// global
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { TagService } from './Shared/tag.service';
// end global

// code
import { CodeComponent } from './code/code.component';
// end code

// sql
import { SqlComponent } from './sql/sql.component';
// end sql

// memory
import { MemoryComponent } from './memory/memory.component';
// end memory

// contact
import { ContactComponent } from './contact/contact.component';
// end contact


@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CodeComponent,
    SqlComponent,
    MemoryComponent,
    ContactComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    MaterialModule,
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
  providers: [TagService],
  bootstrap: [AppComponent]
})
export class AppModule { }
