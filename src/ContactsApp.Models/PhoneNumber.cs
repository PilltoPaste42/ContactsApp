namespace ContactsApp.Models;

using System;

/// <summary>
///     Объект для хранения номера телефона
/// </summary>
public class PhoneNumber
{
    /// <summary>
    ///     Номер телефона 
    /// </summary>
    public ulong Phone
    {
        get => Phone;
        set
        {
            if (value is > 79999999999 or < 70000000000)
                throw new ArgumentOutOfRangeException();
            Phone = value;
        }
    }
}