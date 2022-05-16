namespace ContactsApp.View;

using System.Windows;

using ContactsApp.Models;

/// <summary>
///   Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public delegate void AddContactDelegate(Contact contact);
}