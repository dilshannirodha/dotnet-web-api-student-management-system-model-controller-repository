import { Routes } from '@angular/router';
import { StudentListComponent } from './components/student-List.component';
import { StudentFormComponent } from './components/student-form.component';
import { AddStudentFormComponent } from './components/new-student-form.component';

export const APP_ROUTES: Routes = [
  { path: '', component: StudentListComponent },
  { path: 'add', component: AddStudentFormComponent },
  { path: 'edit/:id', component: StudentFormComponent },
];