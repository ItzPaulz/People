namespace People;

public partial class App : Application
{
    public static PersonRepository PersonRepo { get; private set; } = new PersonRepository("_dbPath");

    public App(PersonRepository repo)
    {
        InitializeComponent();
        MainPage = new AppShell();
        
    }
    
    
        

       
    

}
