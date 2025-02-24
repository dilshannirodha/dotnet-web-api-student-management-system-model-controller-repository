import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-student-form',
  standalone: true,
  imports: [FormsModule], // ✅ Import FormsModule for ngModel
  templateUrl: './student-form.component.html',
  styleUrls: ['./student-form.component.css']
})
export class StudentFormComponent {
  student = { name: '', email: '', course: '' }; // ✅ Student data model

  // ✅ Add saveStudent method
  saveStudent() {
    console.log('Saving student:', this.student);
    // TODO: Implement API call to save the student
    alert(`Student saved: ${this.student.name}, ${this.student.email}, ${this.student.course}`);

    // Optionally, reset the form after saving
    this.student = { name: '', email: '', course: '' };
  }
}
