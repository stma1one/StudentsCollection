using StudentsCollection.ViewModels;

namespace StudentsCollection.Views;

public partial class StudentDetailsPage : ContentPage
{
	public StudentDetailsPage()
	{
		InitializeComponent();
		this.BindingContext = new StudentDetailsPageViewModel();
	}
}