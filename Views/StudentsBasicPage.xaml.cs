using StudentsCollection.ViewModels;

namespace StudentsCollection.Views;

public partial class StudentsBasicPage : ContentPage
{
	public StudentsBasicPage( StudentsBasicPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}