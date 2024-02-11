using StudentsCollection.ViewModels;

namespace StudentsCollection.Views;

public partial class StudentsBasicPage : ContentPage
{
	public StudentsBasicPage()
	{
		InitializeComponent();
		this.BindingContext = new StudentsBasicPageViewModel();
	}
}