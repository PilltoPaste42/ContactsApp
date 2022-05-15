using Newtonsoft.Json;

namespace ContactsApp.Models;

using System;

/// <summary>
///   Объект для хранения номера телефона
/// </summary>
public class PhoneNumber
{
    private ulong _phone;

    [JsonConstructor]
    public PhoneNumber(ulong phone)
    {
        Phone = phone;
    }

    /// <summary>
    ///   Номер телефона
    /// </summary>
    public ulong Phone
    {
        get => _phone;
        set
        {
            if (value is > 79999999999 or < 70000000000)
                throw new ArgumentOutOfRangeException();

            _phone = value;
        }
    }

    /// <summary>
    ///   Получение номера в виде строки
    /// </summary>
    /// <returns> Строка с номером </returns>
    public string GetToString()
    {
        return "+" + _phone;
    }
}