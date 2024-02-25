using StudentsCollection.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCollection.ViewModels
{

    [QueryProperty(nameof(Student),"Student")]
    [QueryProperty(nameof(Title),"Title")]
    public class StudentDetailsPageViewModel:ViewModelBase
    {
        private string title;
        private Student student;
        public Student Student { get => student; set { student = value;OnPropertyChanged(); } }
        

        public string Title { get => title; set { title = value; OnPropertyChanged(); } }
        
    }
}
