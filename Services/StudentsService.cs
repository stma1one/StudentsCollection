
using StudentsCollection.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentsCollection.Services;

public class StudentsService
{
        private List<Student> students;
        public StudentsService()
        {
            students = new List<Student>();

            InitStudents();
        }
        private void InitStudents()
        {
        this.students.Add(new Student
        {
            FirstName = "Gal",
            LastName = "Klug",
            Image = "gal.png",
                BirthDate = new DateTime(2006, 12, 3),

        }) ;

            this.students.Add(new Student
            {
                FirstName = "Shira",
                LastName = "Levy",
                Image="shira.png",
                BirthDate = new DateTime(2007, 2, 27),
                
            });

            this.students.Add(new Student
            {
                FirstName = "ofek",
                LastName = "Levy",
                Image="ofek.png",
                BirthDate = new DateTime(2007, 4, 20),
                
            });

            this.students.Add(new Student
            {
                FirstName = "ziv",
                LastName = "Porat",
                BirthDate = new DateTime(2007, 06, 13),
                Image="ziv.png"
            });

            this.students.Add(new Student
            {
                FirstName = "shahar",
                LastName = "Shalgi",
                BirthDate = new DateTime(2007, 2, 26),
                Image="shalgi.png"
            });

        }

        public async Task<List<Student>> GetStudents()
        {
             await Task.Delay(1000);
            return students;
            }
    public async Task AddStudent(Student student)
    {
        await Task.Delay(2000);
        students.Add(student);
    }
    public async Task RemoveStudent(Student student)
    {
        await Task.Delay(2000);
        students.Remove(students.Where(x=>x.FullName==student.FullName).FirstOrDefault());   
    }

    }


