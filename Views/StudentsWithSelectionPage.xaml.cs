using StudentsCollection.ViewModels;
namespace StudentsCollection.Views;


public partial class StudentsWithSelectionPage : ContentPage
{
	public StudentsWithSelectionPage()
	{
		InitializeComponent();
		this.BindingContext = new StudentsWithSelectionPageViewModel();
	}
}