using StudentsCollection.ViewModels;

namespace StudentsCollection.Views;

public partial class StudentsWithContextMenuPage : ContentPage
{
	public StudentsWithContextMenuPage()
	{
		InitializeComponent();
		this.BindingContext = new StudentsWithContextMenuPageViewModel();
	}
}