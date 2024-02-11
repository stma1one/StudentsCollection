using StudentsCollection.ViewModels;

namespace StudentsCollection.Views;

public partial class StudentsWithRefreshPage : ContentPage
{
	public StudentsWithRefreshPage()
	{
		InitializeComponent();
		this.BindingContext = new StudentsWithRefreshPageViewModel();
	}
}