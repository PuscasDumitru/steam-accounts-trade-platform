import { Account } from "./account.model";

export class Announcement {
    id: number = 0;
    title: string = '';
    description: string = '';
    htmlContent: string = '';
    account: Account = null;
    // accId: number = 0;
    // screenshots: object = null;
}
