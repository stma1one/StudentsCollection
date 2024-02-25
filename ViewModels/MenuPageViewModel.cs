using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StudentsCollection.ViewModels;

    public class MenuPageViewModel:ViewModelBase
    {
        public ICommand GotToPage { get; private set; }
    
        public MenuPageViewModel() 
        {
        GotToPage = new Command<string>(async (x) => { await NavigateToPage(x); });
        
        }

    private async Task NavigateToPage(string x)
    {
        await AppShell.Current.GoToAsync(x);
    }
}

