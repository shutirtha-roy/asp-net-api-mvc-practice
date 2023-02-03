import { ICourse } from './ICourse';

export class Course implements ICourse {
    public name : string = "";
    public fees : number = 0;

    public constructor(init?:Partial<Course>) {
        Object.assign(this, init);
    }
}