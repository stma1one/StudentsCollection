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
    public class StudentsFilterPageViewModel : ViewModelBase
    {
        private StudentsService service;
        #region סינון חודשים
        public ObservableCollection<int> Months { get; set; }   //רשימת החודשים לסינון
        public object SelectedMonth { get; set; }//חודש נבחר
        private int selectedIndex;//מיקום של החודש הנבחר ברשימה
        public int SelectedIndex { get => selectedIndex; set { selectedIndex = value; OnPropertyChanged(); } }
        public ICommand FilterCommand { get; private set; }//סינון
        public ICommand ClearFilterCommand { get; private set; }    //ניקוי סינון
        #endregion

        #region טיפול בסטודנטים
        private List<Student> fullList;//רשימת הסטודנטים המלאה
      
        public ObservableCollection<Student> Students { get; set; }//אוסף סטודנטים
        public ICommand ClearStudentsCommand { get; private set; }  //ריקון הרשימה
        public ICommand LoadStudentsCommand { get; private set; }//טעינה
       

     
        #endregion

        
        public StudentsFilterPageViewModel(StudentsService s) 
        {
            this.service = s;
            fullList = new List<Student>();
            Students = new ObservableCollection<Student>();//רשימה ריקה
            Months = new ObservableCollection<int>();//רשימת החודשים שתוצג במסך



            LoadStudentsCommand = new Command(async () => await LoadStudents()) ;//טעינת התלמידים
            ClearStudentsCommand = new Command(ClearStudents, () => Students.Count > 0);//ריקון הרשימה
            

            //פעולת הסינון
            FilterCommand = new Command(() =>
            {
                try
                {
                    var bornOnSelectedMonth = fullList.Where(x => x.BirthDate.Month == (int)SelectedMonth).ToList(); //נמצא את כל מי שנולד בחודש שנבחר

                    Students.Clear(); //נרוקן את הרשימה הקיימת

                    foreach (var student in bornOnSelectedMonth)
                        Students.Add(student);//נאכלס את הרשימה מאלו שנולדו באותו חודש
                }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

            }, () => fullList != null && fullList.Count > 0
            );

            //ניקוי סינון מבטל את הבחירה בחודר וטוען מחדש את הנתונים המקוריים
            ClearFilterCommand = new Command(async () => {await LoadStudents(); }, () => fullList != null && fullList.Count > 0);
        }

        //טעינת התלמידים
        private async Task LoadStudents()
        {
          
            
            fullList = await service.GetStudents();//נביא את אוסף התלמידים
            //נעדכן את אוסף התלמידים המוצג במסך מהרשימה המלאה
            Students.Clear();
            //טעינת התלמידים
            foreach (var student in fullList)
                Students.Add(student);
            
            UpdateMonths();//נאפשר לסנן בהתאם לחודשים של התלמידים שנשלפו

            //בדיקה אלו פעולות ניתן לבצע/לנטרל
            ((Command)ClearStudentsCommand).ChangeCanExecute();
            ((Command)FilterCommand).ChangeCanExecute();
            ((Command)ClearFilterCommand).ChangeCanExecute();


            
        }

        //ריקון רשימת התלמידים המוצגת במסך
        private void ClearStudents()
        {
            Students.Clear();//ניקוי רשימת תלמידים
            Months.Clear();//ניקוי חודשים 
            fullList.Clear();//ניקוי רשימת התלמידים המשתמשת לסינון/אחזור
          
            //בדיקה אלו פעולות ניתן להפעיל/לנטרל
            ((Command)ClearStudentsCommand).ChangeCanExecute();
            ((Command)FilterCommand).ChangeCanExecute();
            ((Command)ClearFilterCommand).ChangeCanExecute();

        }

        //לוגיקת עדכון החודשים
        private void UpdateMonths()
        {
            Months.Clear();
            var m = fullList.Select(x => x.BirthDate.Month).Distinct().OrderBy(x => x);//נשלוף את רשימת החודשים של רשימת התלמידים המלאה. נמיין לפי הסדר
            foreach (var x in m)//נוסיף לרשימת החודשים המוצגת.
                Months.Add(x);
            SelectedIndex = -1;
        }

    }
}
