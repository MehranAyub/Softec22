import { Role } from "./role";

export interface User {
    id?: number;
    email?:string;
    username?: string;
    password?: string;
    firstName?: string;
    lastName?: string;
    phone?:string;
    loginType?:LoginType
    gender?:string;
    role?: Role; 
    token?:string; 
    latitude?:number;
    longitude?:number;
    address?:string;
}

export enum LoginType{
    Patient=1,
    Doctor=2
}
export class UserToken{
    constructor(user:User,token:string){
        this.user=user;
        this.token=token;
    }
    user:User;
    token:string;
}