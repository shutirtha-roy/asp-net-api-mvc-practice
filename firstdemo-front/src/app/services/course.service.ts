import { Injectable } from '@angular/core';
import { ICourse } from '../data/ICourse';
import { Course } from '../data/Course';

@Injectable({
  providedIn: 'root'
})
export class CourseService {

  constructor() { }

  getCourses() : ICourse[] {
    return [
      new Course({ name: "C#", fees : 8000 }),
      new Course({ name: "Asp.Net", fees : 3000 })
    ];
  }
}
