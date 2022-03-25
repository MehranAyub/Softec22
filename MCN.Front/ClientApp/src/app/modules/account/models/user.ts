import { Role } from "./role";

export interface User {
    id?: number;
    email?:string;
    username?: string;
    password?: string;
    firstName?: string;
    lastName?: string;
    gender?:string;
    role?: Role; 
    token?:string; 
}

export class UserToken{
    constructor(user:User,token:string){
        this.user=user;
        this.token=token;
    }
    user:User;
    token:string;
}