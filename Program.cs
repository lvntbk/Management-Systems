using System;
using System.Collections.Generic;

namespace SchoolManagement
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Class AssignedClass { get; set; }
    }

    class Teacher
    {
        public string Name { get; set; }
    }

    class Class
    {
        public string Name { get; set; }
    }

    class StudentManager
    {
        private List<Student> students = new();
        private int idCounter = 1;

        public void AddStudent(List<Class> classes)
        {
            Console.Write("Öğrenci adı: ");
            string name = Console.ReadLine();

            Console.WriteLine("Sınıflar:");
            for (int i = 0; i < classes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {classes[i].Name}");
            }

            Console.Write("Sınıf seç (numara): ");
            int classIndex = int.Parse(Console.ReadLine()) - 1;

            if (classIndex >= 0 && classIndex < classes.Count)
            {
                Student student = new()
                {
                    Id = idCounter++,
                    Name = name,
                    AssignedClass = classes[classIndex]
                };

                students.Add(student);
                Console.WriteLine("Öğrenci eklendi.");
            }
            else
            {
                Console.WriteLine("Geçersiz sınıf seçimi.");
            }
        }

        public void ListStudents()
        {
            if (students.Count == 0)
            {
                Console.WriteLine("Hiç öğrenci yok.");
                return;
            }

            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.Id}, İsim: {s.Name}, Sınıf: {s.AssignedClass.Name}");
            }
        }

        public void RemoveStudent()
        {
            Console.Write("Silmek istediğin öğrenci ID'si: ");
            int id = int.Parse(Console.ReadLine());

            var student = students.Find(s => s.Id == id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine("Öğrenci silindi.");
            }
            else
            {
                Console.WriteLine("Öğrenci bulunamadı.");
            }
        }
    }

    class TeacherManager
    {
        private List<Teacher> teachers = new();

        public void AddTeacher()
        {
            Console.Write("Öğretmen adı: ");
            string name = Console.ReadLine();

            teachers.Add(new Teacher { Name = name });
            Console.WriteLine("Öğretmen eklendi.");
        }

        public void ListTeachers()
        {
            if (teachers.Count == 0)
            {
                Console.WriteLine("Hiç öğretmen yok.");
                return;
            }

            foreach (var t in teachers)
            {
                Console.WriteLine($"İsim: {t.Name}");
            }
        }

        public void RemoveTeacher()
        {
            Console.Write("Silmek istediğin öğretmen adı: ");
            string name = Console.ReadLine();

            var teacher = teachers.Find(t => t.Name == name);
            if (teacher != null)
            {
                teachers.Remove(teacher);
                Console.WriteLine("Öğretmen silindi.");
            }
            else
            {
                Console.WriteLine("Öğretmen bulunamadı.");
            }
        }
    }

    class ClassManager
    {
        private List<Class> classes = new();

        public List<Class> GetClasses() => classes;

        public void AddClass()
        {
            Console.Write("Sınıf adı: ");
            string name = Console.ReadLine();
            classes.Add(new Class { Name = name });
            Console.WriteLine("Sınıf eklendi.");
        }

        public void ListClasses()
        {
            if (classes.Count == 0)
            {
                Console.WriteLine("Hiç sınıf yok.");
                return;
            }

            for (int i = 0; i < classes.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {classes[i].Name}");
            }
        }

        public void RemoveClass()
        {
            Console.Write("Silmek istediğin sınıf adı: ");
            string name = Console.ReadLine();
            var c = classes.Find(x => x.Name == name);
            if (c != null)
            {
                classes.Remove(c);
                Console.WriteLine("Sınıf silindi.");
            }
            else
            {
                Console.WriteLine("Sınıf bulunamadı.");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var studentManager = new StudentManager();
            var teacherManager = new TeacherManager();
            var classManager = new ClassManager();

            while (true)
            {
                Console.WriteLine("\n--- Yönetim Paneli ---");
                Console.WriteLine("1. Öğrenci Yönetimi");
                Console.WriteLine("2. Öğretmen Yönetimi");
                Console.WriteLine("3. Sınıf Yönetimi");
                Console.WriteLine("0. Çıkış");
                Console.Write("Seçim: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        StudentMenu(studentManager, classManager);
                        break;
                    case "2":
                        TeacherMenu(teacherManager);
                        break;
                    case "3":
                        ClassMenu(classManager);
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Geçersiz seçim.");
                        break;
                }
            }
        }

        static void StudentMenu(StudentManager sm, ClassManager cm)
        {
            while (true)
            {
                Console.WriteLine("\n--- Öğrenci Menüsü ---");
                Console.WriteLine("1. Öğrenci Ekle");
                Console.WriteLine("2. Öğrencileri Listele");
                Console.WriteLine("3. Öğrenci Sil");
                Console.WriteLine("0. Geri");
                Console.Write("Seçim: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": sm.AddStudent(cm.GetClasses()); break;
                    case "2": sm.ListStudents(); break;
                    case "3": sm.RemoveStudent(); break;
                    case "0": return;
                    default: Console.WriteLine("Geçersiz seçim."); break;
                }
            }
        }

        static void TeacherMenu(TeacherManager tm)
        {
            while (true)
            {
                Console.WriteLine("\n--- Öğretmen Menüsü ---");
                Console.WriteLine("1. Öğretmen Ekle");
                Console.WriteLine("2. Öğretmenleri Listele");
                Console.WriteLine("3. Öğretmen Sil");
                Console.WriteLine("0. Geri");
                Console.Write("Seçim: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": tm.AddTeacher(); break;
                    case "2": tm.ListTeachers(); break;
                    case "3": tm.RemoveTeacher(); break;
                    case "0": return;
                    default: Console.WriteLine("Geçersiz seçim."); break;
                }
            }
        }

        static void ClassMenu(ClassManager cm)
        {
            while (true)
            {
                Console.WriteLine("\n--- Sınıf Menüsü ---");
                Console.WriteLine("1. Sınıf Ekle");
                Console.WriteLine("2. Sınıfları Listele");
                Console.WriteLine("3. Sınıf Sil");
                Console.WriteLine("0. Geri");
                Console.Write("Seçim: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": cm.AddClass(); break;
                    case "2": cm.ListClasses(); break;
                    case "3": cm.RemoveClass(); break;
                    case "0": return;
                    default: Console.WriteLine("Geçersiz seçim."); break;
                }
            }
        }
    }
}
