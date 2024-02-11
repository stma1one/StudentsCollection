using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsCollection.Models;

public class Student
{
    public string FirstName { get; set; }
    public string LastName { get; set; }    
    public string FullName { get => $"{FirstName} {LastName}"; } 
    public string Image { get; set; }
    public DateTime BirthDate { get; set; }
    public double Age { get => (DateTime.Now - BirthDate).TotalDays / 365; }


}
