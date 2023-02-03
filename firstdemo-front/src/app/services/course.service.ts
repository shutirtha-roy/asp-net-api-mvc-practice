import { Injectable } from '@angular/core';
import { ICourse } from '../data/ICourse';
import { Course } from '../data/Course';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})

export class CourseService {

  constructor() { }

  getCourses() : Observable<ICourse[]>{
    return of([
      new Course({ name: "C#", fees : 8000 }),
      new Course({ name: "Asp.Net", fees : 3000 })
    ]);
  }
}
