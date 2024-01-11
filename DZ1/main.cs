
using System;
using System.Collections.Generic;

public abstract class Person {
    public string Name { get; set; }
    public string Surname { get; set; }
    public int ID;
    
    public Person(string name, string surname, int id) {
        Name = name;
        Surname = surname;
        ID = id;
    }
}

public class Student : Person {
    public List<int> Grades { get; set; }
    public string SpecificClass { get; set; }
    
    public Student(string name, string surname, int id, string specificClass) : base(name, surname, id) {
        Grades = new List<int>();
        SpecificClass = specificClass;
    }
    
    public void AddGrade(int grade) {
        Grades.Add(grade);
    }
    
    public void ShowGrades() {
        Console.WriteLine($"Grades for student {Name} {Surname}: {string.Join(", ", Grades)}");
    }
}

public class Teacher : Person {
    public List<string> Subjects { get; set; }
    
    public Teacher(string name, string surname, int id, List<string> subjects) : base(name, surname, id) {
        Subjects = subjects;
    }
    
    public void AddStudentGrade(Student student, int grade) {
        student.AddGrade(grade);
    }
    
    public void ReviewStudentGrades(Student student) {
        student.ShowGrades();
    }
    
    public void ReviewClassGrades(List<Student> classRoom) {
        foreach(var student in classRoom) {
            ReviewStudentGrades(student);
        }
    }
}

public class Director : Person {
    public List<Teacher> Teachers { get; set; }
    public List<Student> Students { get; set; }
    
    public Director(string name, string surname, int id) : base(name, surname, id) {
        Teachers = new List<Teacher>();
        Students = new List<Student>();
    }
    
    public void AddTeacher(Teacher teacher) {
        Teachers.Add(teacher);
    }
    
    public void AddStudent(Student student) {
        Students.Add(student);
    }
    
    public void RemoveTeacher(Teacher teacher) {
        Teachers.Remove(teacher);
    }
    
    public void RemoveStudent(Student student) {
        Students.Remove(student);
    }
    
    public void ReviewSchoolGrades() {
        foreach(var student in Students) {
            student.ShowGrades();
        }
    }
}

public class Classroom {
    public string ClassroomName { get; set; }
    public List<Student> Students { get; set; }
    
    public Classroom(string classroomName) {
        ClassroomName = classroomName;
        Students = new List<Student>();
    }
    
    public void AddStudent(Student student) {
        Students.Add(student);
    }
    
    public void RemoveStudent(Student student) {
        Students.Remove(student);
    }
    
    public void DisplayClassGrades() {
        foreach(var student in Students) {
            student.ShowGrades();
        }
    }
}

class program {
  static void Main() {
        Director director = new Director("Jerko","Jerkovic",1048);
        Teacher scienceTeacher = new Teacher("Marko","Markovic",1047,new List<string>{"Math","Chemistry","Physics"});
        Student student = new Student("Josip","Ostovic",23,"7C");
        
        director.AddTeacher(scienceTeacher);
        director.AddStudent(student);
        
        Classroom class7C = new Classroom("7C");
        class7C.AddStudent(student);
        
        scienceTeacher.AddStudentGrade(student, 5);
        director.ReviewSchoolGrades();
        scienceTeacher.ReviewClassGrades(class7C.Students);
  }
}
