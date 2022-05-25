namespace ContactsApp.View;

using System.Windows.Controls;

using ContactsApp.Models;

/// <summary>
///   Логика взаимодействия для ContactForm.xaml
/// </summary>
public partial class ContactForm : UserControl
{
    public ContactForm()
    {
        InitializeComponent();
    }

    /// <summary>
    ///   Очистка полей формы
    /// </summary>
    public void Clear()
    {
        FirstName.Clear();
        LastName.Clear();
        PhoneNumber.Clear();
        Email.Clear();
        VkId.Clear();
        BirthdayDate.SelectedDate = null;
    }

    /// <summary>
    ///   Получение экземпляра контакта из формы
    /// </summary>
    public Contact GetContact()
    {
        return new Contact
        {
            FirstName = FirstName.Text,
            LastName = LastName.Text,
            PhoneNumber = new PhoneNumber(ulong.Parse(PhoneNumber.Text)),
            Email = Email.Text,
            VkId = VkId.Text,
            Birthday = BirthdayDate.SelectedDate.Value
        };
    }

    /// <summary>
    ///   Установка данных контакта в поля формы
    /// </summary>
    public void SetContact(Contact contact)
    {
        FirstName.Text = contact.FirstName;
        LastName.Text = contact.LastName;
        PhoneNumber.Text = contact.PhoneNumber?.GetToString();
        Email.Text = contact.Email;
        VkId.Text = contact.VkId;
        BirthdayDate.SelectedDate = contact.Birthday;
    }
}