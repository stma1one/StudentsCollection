using StudentsCollection.ViewModels;

namespace StudentsCollection.Views;

public partial class MenuPage : ContentPage
{
	public MenuPage()
	{
		InitializeComponent();
		this.BindingContext = new MenuPageViewModel();
	}
}