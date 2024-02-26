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
    public class StudentsWithSelectionPageViewModel:ViewModelBase
    {

        StudentsService service;
        #region טיפול בסטודנטים
        private List<Student> fullList;//רשימת הסטודנטים המלאה
        private Student selectedStudent;
        public Student SelectedStudent { get => selectedStudent; set { selectedStudent = value;OnPropertyChanged(); ((Command)ShowStudentCommand).ChangeCanExecute(); } }//שם סטודנט להוספה
        public ObservableCollection<Student> Students { get; set; }//אוסף סטודנטים
        public ICommand ClearStudentsCommand { get; private set; }  //ריקון הרשימה
        public ICommand LoadStudentsCommand { get; private set; }//טעינה
        public ICommand ShowStudentCommand { get; private set; }//הוספת סטודנט

        public ICommand DeleteCommand { get; private set; }//מחיקת סטודנט
        #endregion

        #region רענון מסך
        private bool isRefreshing;

        public bool IsRefreshing { get => isRefreshing; set { isRefreshing = value; OnPropertyChanged(); } }
        #endregion
        public StudentsWithSelectionPageViewModel(StudentsService service)
        {
            this.service = service;
            fullList = new List<Student>();
            Students = new ObservableCollection<Student>();//רשימה ריקה



            DeleteCommand = new Command((object obj) => { Student st = (Student)obj; Students.Remove(st); fullList.Remove(st); });//מחיקת התלמיד מהרשימה
            LoadStudentsCommand = new Command(async () => await LoadStudents());//טעינת התלמידים
            ClearStudentsCommand = new Command(ClearStudents, () => Students.Count > 0);//ריקון הרשימה
            
            ShowStudentCommand = new Command(async () =>
            {
                bool result = await AppShell.Current.DisplayAlert("הצגת נתוני תלמיד", "האם אתה בטוח?","כן", "לא");
                if (result)
                {
                    Dictionary<string, object> data = new Dictionary<string, object>();
                    data.Add("Student", SelectedStudent);
                    await AppShell.Current.GoToAsync($"StudentDetails?Title={SelectedStudent.FullName} פרטים של", data);
                    SelectedStudent=null;
                }
            }
            , () => SelectedStudent!=null);

        }

        //טעינת התלמידים
        private async Task LoadStudents()
        {
            IsRefreshing = true;//נפעיל את אייקון הרענון
            
            fullList = await service.GetStudents();//נביא את אוסף התלמידים
            //נעדכן את אוסף התלמידים המוצג במסך מהרשימה המלאה
            Students.Clear();
            foreach (var student in fullList)
                Students.Add(student);
            ((Command)ClearStudentsCommand).ChangeCanExecute();





            IsRefreshing = false;//בסיום נבטל את אייקון הרענון
        }

        //ריקון רשימת התלמידים המוצגת במסך
        private void ClearStudents()
        {
            Students.Clear();
            ((Command)ClearStudentsCommand).ChangeCanExecute();

        }



    }
}

