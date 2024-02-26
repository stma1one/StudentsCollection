
using Microsoft.Extensions.Logging;
using StudentsCollection.Services;
using StudentsCollection.ViewModels;
using StudentsCollection.Views;

namespace StudentsCollection
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            //register services
            builder.Services.AddSingleton<StudentsService>();

            //register viewmodels
            builder.Services.AddTransient<StudentsBasicPageViewModel>(); 
            builder.Services.AddTransient<StudentsWithContextMenuPageViewModel>();
            builder.Services.AddTransient<StudentsWithRefreshPageViewModel>();
            builder.Services.AddTransient<StudentsFilterPageViewModel>();
            builder.Services.AddTransient<StudentsWithSelectionPageViewModel>();
            builder.Services.AddTransient<StudentDetailsPageViewModel>();
            builder.Services.AddTransient<MenuPageViewModel>();

            
            //register views
            builder.Services.AddTransient<StudentsBasicPage>();
            builder.Services.AddTransient<StudentsWithContextMenuPage>();
            builder.Services.AddTransient<StudentsWithRefreshPage>();
            builder.Services.AddTransient<StudentsFilterPage>();
            builder.Services.AddTransient<StudentsWithSelectionPage>();
            builder.Services.AddTransient<StudentDetailsPage>();
            builder.Services.AddSingleton<MenuPage>();








#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

       
    }
}