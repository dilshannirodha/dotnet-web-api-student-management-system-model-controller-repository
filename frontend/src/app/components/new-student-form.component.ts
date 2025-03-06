import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { StudentService } from '../services/student.service';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-student-form',
  imports: [CommonModule,  FormsModule],
  templateUrl: './new-student-form.component.html',
  
})
export class AddStudentFormComponent {
  student = { name: '', email: '', course: '' };

  constructor(
    private studentService: StudentService,
    private router: Router
  ) {}

  submitForm() {
    this.studentService.addStudent(this.student).subscribe(() => {
      this.router.navigate(['/']);
    });
  }
}
