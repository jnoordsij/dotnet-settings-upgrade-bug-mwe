using System.Configuration;

namespace dotnet_settings_mwe;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        var fooSettings = new FooSettings();
        try
        {
            fooSettings.Upgrade();
        }
        catch (Exception)
        {
            MessageBox.Show("failed");
        }
        
        Application.Run(new Form1());
    }    
}


//Application settings wrapper class
sealed class FooSettings : ApplicationSettingsBase
{
    [UserScopedSettingAttribute()]
    public String Foo
    {
        get { return (String)this["Foo"]; }
        set { this["Foo"] = value; }
    }
}