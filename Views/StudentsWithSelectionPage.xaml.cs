using StudentsCollection.ViewModels;
namespace StudentsCollection.Views;


public partial class StudentsWithSelectionPage : ContentPage
{
	public StudentsWithSelectionPage(StudentsWithSelectionPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}