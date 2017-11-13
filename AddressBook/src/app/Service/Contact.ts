/// <reference path="../model/icontact.ts" />
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/do';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/map';
import { IContact } from '../Model/IContact';

@Injectable()
export class ContactService {
    private addressbookAPIUrl = 'http://localhost:59951/api/AddressBook';

    constructor(private _http: Http) { }

    getContacts(): Observable<IContact[]> {
        return this._http.get(this.addressbookAPIUrl)
            .map((response: Response) => <IContact[]>response.json())
            .do(data => console.log('All: ' + JSON.stringify(data)))
            .catch(this.handleError);
    }

    getContact(name: string): Observable<IContact> {
        return this._http.get(this.addressbookAPIUrl + `?name=${name}`)
            .map((response: Response) => <IContact>response.json())
            .catch(this.handleError);
    }

    updateContact(contact:IContact) {
        return this._http.put(this.addressbookAPIUrl , contact)
            .map((response: Response) => {
                this.successLog(response);
            })
            .catch(this.handleError)
    }

    saveContact(contact: IContact) {
        return this._http.post(this.addressbookAPIUrl, contact)
            .map((response: Response) => {
                this.successLog(response);
            })
            .catch(this.handleError)
    }

    deleteContact(id: number) {
        return this._http.delete(this.addressbookAPIUrl + "/" + id)
            .map((response: Response) => {
                this.successLog(response);
            })
            .catch(this.handleError)
    }

    private handleError(error: Response) {
        // in a real world app, we may send the server to some remote logging infrastructure
        // instead of just logging it to the console
        console.error(error);
        return Observable.throw(error.json().error || 'Server error');
    }

    private successLog (responce:any):void {
        var check = responce.status;
        console.log(check);
    }
}
