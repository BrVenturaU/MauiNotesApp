using FirstMauiApp.Views;

namespace FirstMauiApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(NotePage), typeof(NotePage));
        }
    }
}