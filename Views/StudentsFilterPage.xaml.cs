using StudentsCollection.ViewModels;

namespace StudentsCollection.Views;

public partial class StudentsFilterPage : ContentPage
{
	public StudentsFilterPage()
	{
		InitializeComponent();
		this.BindingContext = new StudentsBasicPageViewModel();
	}
}