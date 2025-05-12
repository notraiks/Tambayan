namespace Tambayan;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute("Login", typeof(Login));
        Routing.RegisterRoute("Register", typeof(Register));
        Routing.RegisterRoute("MainPage", typeof(MainPage));
        Routing.RegisterRoute("Threads", typeof(Threads));
        Routing.RegisterRoute("MyApplication", typeof(MyApplication));
    }
}