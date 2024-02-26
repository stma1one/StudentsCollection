using StudentsCollection.ViewModels;

namespace StudentsCollection.Views;

public partial class MenuPage : ContentPage
{
	public MenuPage(MenuPageViewModel vm)
	{
		InitializeComponent();
		this.BindingContext = vm;
	}
}