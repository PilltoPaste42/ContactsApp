namespace ContactsApp.View;

using System.Windows;

using ContactsApp.Models;

/// <summary>
///   Логика взаимодействия для AddContactWindow.xaml
/// </summary>
public partial class AddContactWindow : Window
{
    private readonly App.AddContactDelegate _addContactDelegate;

    public AddContactWindow(App.AddContactDelegate sender)
    {
        InitializeComponent();
        SetRandomContact();
        _addContactDelegate = sender;
    }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void OkButton_OnClick(object sender, RoutedEventArgs e)
    {
        var contact = ContactForm.GetContact();
        _addContactDelegate(contact);

        Close();
    }

    /// <summary>
    ///   Создание заглушки контакта и установка значений в форму
    /// </summary>
    private void SetRandomContact()
    {
        var contact = ContactMock.Get();

        ContactForm.SetContact(contact);
    }
}