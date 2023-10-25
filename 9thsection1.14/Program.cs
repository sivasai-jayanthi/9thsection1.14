using System;
using System.Collections.Generic;
using System.Linq;

namespace _9thsection1._14
{
	

	class Student
	{
		public string Name { get; set; }
		public string ClassAndSection { get; set; }
	}

	class Teacher
	{
		public string Name { get; set; }
		public string ClassAndSection { get; set; }
	}

	class Subject
	{
		public string Name { get; set; }
		public string SubjectCode { get; set; }
		public Teacher Teacher { get; set; }
	}

	class Program
	{
		static List<Student> students = new List<Student>();
		static List<Teacher> teachers = new List<Teacher>();
		static List<Subject> subjects = new List<Subject>();

		static void FillData()
		{
			Console.WriteLine("Adding data for students, teachers, and subjects...");

			// Add students
			Console.Write("Enter student name: ");
			string studentName = Console.ReadLine();
			Console.Write("Enter class and section: ");
			string studentClassAndSection = Console.ReadLine();
			students.Add(new Student { Name = studentName, ClassAndSection = studentClassAndSection });

			// Add teachers
			Console.Write("Enter teacher name: ");
			string teacherName = Console.ReadLine();
			Console.Write("Enter class and section: ");
			string teacherClassAndSection = Console.ReadLine();
			teachers.Add(new Teacher { Name = teacherName, ClassAndSection = teacherClassAndSection });

			// Add subjects
			Console.Write("Enter subject name: ");
			string subjectName = Console.ReadLine();
			Console.Write("Enter subject code: ");
			string subjectCode = Console.ReadLine();
			Console.Write("Enter the name of the teacher for this subject: ");
			string teacherNameForSubject = Console.ReadLine();
			Teacher subjectTeacher = teachers.Find(teacher => teacher.Name == teacherNameForSubject);
			subjects.Add(new Subject { Name = subjectName, SubjectCode = subjectCode, Teacher = subjectTeacher });

			Console.WriteLine("Data added successfully.");
		}

		static void DisplayStudentsInClass(string className)
		{
			Console.WriteLine($"Students in {className}:");
			var studentsInClass = students.Where(student => student.ClassAndSection == className);
			foreach (var student in studentsInClass)
			{
				Console.WriteLine($"Name: {student.Name}");
			}
		}

		static void DisplaySubjectsTaughtByTeacher(string teacherName)
		{
			Console.WriteLine($"Subjects taught by {teacherName}:");
			var subjectsTaughtByTeacher = subjects.Where(subject => subject.Teacher.Name == teacherName);
			foreach (var subject in subjectsTaughtByTeacher)
			{
				Console.WriteLine($"Subject: {subject.Name}, Subject Code: {subject.SubjectCode}");
			}
		}

		static void Main()
		{
			bool continueRunning = true;
			while (continueRunning)
			{
				Console.WriteLine("\nOptions:");
				Console.WriteLine("1. Add Data");
				Console.WriteLine("2. Display Students in a Class");
				Console.WriteLine("3. Display Subjects Taught by a Teacher");
				Console.WriteLine("4. Exit");
				Console.Write("Enter your choice: ");
				string choice = Console.ReadLine();

				switch (choice)
				{
					case "1":
						FillData();
						break;
					case "2":
						Console.Write("Enter the class name to display students: ");
						string desiredClass = Console.ReadLine();
						DisplayStudentsInClass(desiredClass);
						break;
					case "3":
						Console.Write("Enter the teacher name to display subjects taught: ");
						string desiredTeacherName = Console.ReadLine();
						DisplaySubjectsTaughtByTeacher(desiredTeacherName);
						break;
					case "4":
						continueRunning = false;
						break;
					default:
						Console.WriteLine("Invalid choice. Please try again.");
						break;
				}
			}
			Console.ReadLine();
		}
	}

}
