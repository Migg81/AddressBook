

import { NgModule }      from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AddressBookComponent } from './pages/address-book/address-book.component';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './app-routing.module';
import { ContactService } from './service/contact';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { FilterPipe } from './Pipes/filter';

@NgModule({
    imports: [BrowserModule, AppRoutingModule, FormsModule, HttpModule],
    declarations: [AppComponent, AddressBookComponent, FilterPipe],
    bootstrap: [AppComponent],
    providers: [ContactService],
})
export class AppModule { }
