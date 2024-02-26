using StudentsCollection.ViewModels;

namespace StudentsCollection.Views;

public partial class StudentsFilterPage : ContentPage
{
	public StudentsFilterPage(StudentsFilterPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}