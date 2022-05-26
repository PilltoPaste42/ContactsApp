namespace ContactsApp.View;

using System;
using System.Windows;
using System.Windows.Controls;

using ContactsApp.Models;

/// <summary>
///   Логика главного окна.
/// </summary>
public partial class MainWindow : Window
{
    private readonly ProjectManager _pm = ProjectManager.Instance;
    private readonly Project _project;

    public MainWindow()
    {
        InitializeComponent();
        _project = _pm.LoadProject();
        UpdateContactsListBox();
    }

    /// <summary>
    ///   Обновление спика контактов.
    /// </summary>
    public void UpdateContactsListBox()
    {
        ContactsListBox.Items.Clear();
        foreach (var contact in _project.Contacts)
        {
            ContactsListBox.Items
                .Add(contact.LastName + " " + contact.FirstName);
        }
    }

    /// <summary>
    ///   Добавление контакта.
    /// </summary>
    private void AddContact(Contact contact)
    {
        _project.Contacts.Add(contact);
    }

    private void AddContactButton_OnClick(object sender, RoutedEventArgs e)
    {
        AddContactInForm();
        UpdateContactsListBox();
    }

    /// <summary>
    ///   Добавление контакта в справочник с помощью формы.
    /// </summary>
    private void AddContactInForm()
    {
        var window = new AddContactWindow(AddContact)
        {
            Owner = this
        };
        window.ShowDialog();
    }

    private void ContactsListBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var selectedIndex = ContactsListBox.SelectedIndex;
        if (selectedIndex == -1)
        {
            Form.Clear();
            return;
        }

        Form.SetContact(_project.Contacts[selectedIndex]);
    }

    /// <summary>
    ///   Удаление контакта.
    /// </summary>
    /// <param name="index"> Индекс контакта в списке </param>
    private void DeleteContact(int index)
    {
        _project.Contacts.RemoveAt(index);
    }

    private void DeleteContactButton_OnClick(object sender, RoutedEventArgs e)
    {
        DeleteSelectedElementInContactList();
    }

    /// <summary>
    ///   Удаление выбранного из списка контакта.
    /// </summary>
    private void DeleteSelectedElementInContactList()
    {
        var selectedIndex = ContactsListBox.SelectedIndex;
        if (selectedIndex == -1)
            return;

        var messageBoxText = "Удалить выбранный контакт?";
        var caption = "Удаление контакта";
        var button = MessageBoxButton.YesNo;
        var icon = MessageBoxImage.Question;
        var result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.Yes);

        if (result == MessageBoxResult.Yes)
        {
            DeleteContact(selectedIndex);
            UpdateContactsListBox();
            Form.Clear();
        }
    }

    private void EditContactButton_OnClick(object sender, RoutedEventArgs e)
    {
        UpdateSelectedElementInListBox();
    }

    private void MenuEditAdd_OnClick(object sender, RoutedEventArgs e)
    {
        AddContactInForm();
        UpdateContactsListBox();
    }

    private void MenuEditRemove_OnClick(object sender, RoutedEventArgs e)
    {
        DeleteSelectedElementInContactList();
    }

    private void MenuFileExit_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void MenuHelpAbout_OnClick(object sender, RoutedEventArgs e)
    {
        var window = new AboutAppWindow
        {
            Owner = this
        };
        window.Show();
    }

    private void MenuItem_OnClick(object sender, RoutedEventArgs e)
    {
        UpdateSelectedElementInListBox();
    }

    /// <summary>
    ///   Обновление выбранного контакта с помощью данных из формы.
    /// </summary>
    private void UpdateSelectedElementInListBox()
    {
        var selectedIndex = ContactsListBox.SelectedIndex;
        if (selectedIndex == -1)
            return;

        var messageBoxText = "Обновить выбранный контакт?";
        var caption = "Обновление контакта";
        var button = MessageBoxButton.YesNo;
        var icon = MessageBoxImage.Question;
        var result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.No);

        if (result == MessageBoxResult.No)
            return;

        var oldElement = _project.Contacts[selectedIndex];
        var newElement = Form.GetContact();

        oldElement.FirstName = newElement.FirstName;
        oldElement.LastName = newElement.LastName;
        oldElement.PhoneNumber = newElement.PhoneNumber;
        oldElement.Email = newElement.Email;
        oldElement.Birthday = newElement.Birthday;
        oldElement.VkId = newElement.VkId;

        UpdateContactsListBox();
        ContactsListBox.SelectedIndex = selectedIndex;
    }

    private void Window_Closed(object sender, EventArgs e)
    {
        _pm.SaveProject(_project);
    }
}