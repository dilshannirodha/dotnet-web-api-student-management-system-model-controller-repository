import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { FormsModule } from '@angular/forms';
import { StudentService } from '../services/student.service';

@Component({
  selector: 'app-student-form',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './student-form.component.html', 
})
export class StudentFormComponent implements OnInit {
  student = { name: '', email: '', course: '' };
  isEdit = false;

  constructor(
    private studentService: StudentService,
    private route: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit() {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEdit = true;
      this.studentService.getStudent(+id).subscribe((data) => (this.student = data));
    }
  }

  submitForm() {
    if (this.isEdit) {
      this.studentService
        .updateStudent(+this.route.snapshot.paramMap.get('id')!, this.student)
        .subscribe(() => this.router.navigate(['/']));
    } else {
      this.studentService.addStudent(this.student).subscribe(() => this.router.navigate(['/']));
    }
  }
}
