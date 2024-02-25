
using StudentsCollection.Views;

namespace StudentsCollection
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            RoutingPages();
        }

        private void RoutingPages()
        {
            Routing.RegisterRoute("BasicStudent", typeof(StudentsBasicPage));
            Routing.RegisterRoute("StudentDetails", typeof(StudentDetailsPage));
            Routing.RegisterRoute("StudentFilter",typeof(StudentsFilterPage));
            Routing.RegisterRoute("StudentContext", typeof(StudentsWithContextMenuPage));
            Routing.RegisterRoute("StudentRefresh",typeof(StudentsWithRefreshPage));
            Routing.RegisterRoute("StudentSelection", typeof(StudentsWithSelectionPage));

        }
    }
}