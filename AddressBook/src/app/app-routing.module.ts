/// <reference path="pages/address-book/address-book.component.ts" />
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddressBookComponent } from './pages/address-book/address-book.component';

const appRoutes: Routes = [
    { path: 'addressBook', component: AddressBookComponent },
];

@NgModule({
    imports: [
        RouterModule.forRoot(
            appRoutes,
            { enableTracing: true } // <-- debugging purposes only
        )
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule { }