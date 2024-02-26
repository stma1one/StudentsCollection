using StudentsCollection.ViewModels;

namespace StudentsCollection.Views;

public partial class StudentsWithContextMenuPage : ContentPage
{
	public StudentsWithContextMenuPage(StudentsWithContextMenuPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}