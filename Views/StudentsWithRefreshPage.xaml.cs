using StudentsCollection.ViewModels;

namespace StudentsCollection.Views;

public partial class StudentsWithRefreshPage : ContentPage
{
	public StudentsWithRefreshPage(StudentsWithRefreshPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}