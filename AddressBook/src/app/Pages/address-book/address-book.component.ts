import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ContactService } from '../../service/contact';
import { IContact} from '../../model/icontact'
import { IPageStatus } from '../../model/ipagestatus'

@Component({
  selector: 'app-address-book',
  templateUrl: './address-book.component.html',
  styleUrls: ['./address-book.component.css'],
  encapsulation: ViewEncapsulation.None
})
export class AddressBookComponent implements OnInit {

    contacts: IContact[];
    errorMessage: string;
    contact: IContact;
    isUpdate: boolean;
    pageStatus: IPageStatus;
    serarchText: string = '';


    constructor(private contactservice: ContactService) {

        this.setUp();
        this.clearMsg();
    }

    ngOnInit(): void {
        this.populateList();
        this.isUpdate = false;
    }


    onSaveClicked(message: string): void {

        if (this.isUpdate) {
            this.contactservice.updateContact(this.contact)
                .subscribe(success => {
                    this.populateList();
                    this.showSuccessMsg();
                    this.setUp();
                }, error => {
                    this.showErrorMsg(error);
                })
        }
        else {
            this.contactservice.saveContact(this.contact)
                .subscribe(success => {
                    this.populateList();
                    this.showSuccessMsg();
                    this.setUp();
                }, error => {
                    this.showErrorMsg(error);
                })
        }
    }

    populateList() :void{
        this.contactservice.getContacts()
            .subscribe(result => {
                this.contacts = result;
            }, error => {
                this.errorMessage = error
                this.showErrorMsg(error);
            })
    }

    updateContact(Id:number):void {
        this.contact = this.contacts.find(f => f.Id == Id);
        this.isUpdate = true;
        this.clearMsg();
    }

    deleteContact(Id: number): void {

        this.contactservice.deleteContact(Id)
            .subscribe(success => {
                this.populateList();
                this.showSuccessMsg();
            }, error => {
                this.showErrorMsg(error);
            });
    }

    showSuccessMsg(): void {
        this.pageStatus = {
            cssClass: 'alert alert-success',
            msg: 'Recorecord updated successfully.',
            statusType: 'Success!',
        };
    }

    showErrorMsg(errorMsg :any): void {
        this.pageStatus = {
            cssClass: 'alert alert-warning',
            msg: errorMsg,
            statusType: 'Warning!',
        };
    }


    setUp(): void {
        this.contact = {
            Name: '',
            Address: '',
            Phone: '',
            Email: '',
            Id: 0
        };
    }

    clearMsg(): void {
        this.pageStatus = {
            cssClass: '',
            msg: '',
            statusType: '',
        };
    }

    onResetClicked(): void {
        this.setUp();
        this.clearMsg();
        this.isUpdate = false;
    }
}

