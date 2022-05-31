using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Navigation;
using ContactsApp.Models;

namespace ContactsApp.ViewModel;

public class ContactFormModelView : INotifyPropertyChanged, IDataErrorInfo
{
    private Contact _contact;

    public DateTime Birthday
    {
        get
        {
            return _contact.Birthday;
        }
        set
        {
            _contact.Birthday = value;
            OnPropertyChanged("Birthday");
        }
}

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }

    public string Error => string.Empty;
    public string this[string columnName] => throw new NotImplementedException();
    
}