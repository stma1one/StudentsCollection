using StudentsCollection.Models;
using StudentsCollection.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentsCollection.ViewModels
{
    public class StudentsBasicPageViewModel : ViewModelBase
    {
        private StudentsService service;


        private string studentName;
        public string StudentName { get => studentName; set { studentName = value; ((Command)AddStudentCommand).ChangeCanExecute(); } }
        public ObservableCollection<Student> Students { get; set; }

        public ICommand ClearStudentsCommand { get; private set; }  
        public ICommand LoadStudentsCommand { get; private set; }//טעינה
        public ICommand AddStudentCommand { get;private set; }  
        public StudentsBasicPageViewModel(StudentsService s)
        {
            service = s; 
            Students = new ObservableCollection<Student>();
            Students.Clear();
            
            

            LoadStudentsCommand = new Command(async () => await LoadStudents());
            ClearStudentsCommand = new Command(ClearStudents , () => Students.Count > 0) ;
            AddStudentCommand = new Command( () => { Students.Add(new Student() { FirstName = StudentName, LastName = StudentName, BirthDate = DateTime.Now, Image = $"{StudentName}.png" }); }, ()=>StudentName=="tami"||StudentName=="shahar" || StudentName=="shai"||StudentName=="itamar");
        }

        private void ClearStudents()
        {
            Students.Clear();
            ((Command)ClearStudentsCommand).ChangeCanExecute();

        }

        private async Task LoadStudents()
        {
            
            var list = await service.GetStudents();
            Students.Clear();
            foreach(var student in list)
                Students.Add(student);
            ((Command)ClearStudentsCommand).ChangeCanExecute();
        }

    }
}
