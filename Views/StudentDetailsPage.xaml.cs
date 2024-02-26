using StudentsCollection.ViewModels;

namespace StudentsCollection.Views;

public partial class StudentDetailsPage : ContentPage
{
	public StudentDetailsPage(StudentDetailsPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}