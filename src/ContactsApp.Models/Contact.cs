namespace ContactsApp.Models;

using System;

/// <summary>
///   Класс для хранения контакта.
/// </summary>
public class Contact : ICloneable
{
    private DateTime _birthday;
    private string? _email;
    private string? _firstName;
    private string? _lastName;
    private string? _vkId;

    /// <summary>
    ///   Дата рождения.
    /// </summary>
    public DateTime Birthday
    {
        get => _birthday;
        set
        {
            if (value > DateTime.Now || value.Year < 1900)
                throw new ArgumentOutOfRangeException();

            _birthday = value;
        }
    }

    /// <summary>
    ///   Эл. почта.
    /// </summary>
    public string? Email
    {
        get => _email;
        set
        {
            ValidateStringLength(value!, 0, 50);
            _email = value;
        }
    }

    /// <summary>
    ///   Имя контакта.
    /// </summary>
    public string? FirstName
    {
        get => _firstName;
        set
        {
            ValidateStringLength(value!, 0, 50);
            _firstName = value;
        }
    }

    /// <summary>
    ///   Фамилия контакта.
    /// </summary>
    public string? LastName
    {
        get => _lastName;
        set
        {
            ValidateStringLength(value!, 0, 50);
            _lastName = value;
        }
    }

    /// <summary>
    ///   Телефонный номер.
    /// </summary>
    public PhoneNumber? PhoneNumber { get; set; }

    /// <summary>
    ///   Идентификатор контакта в соц. сети vk.com.
    /// </summary>
    public string? VkId
    {
        get => _vkId;
        set
        {
            ValidateStringLength(value!, 0, 15);
            _vkId = value;
        }
    }

    /// <summary>
    ///   Метод клонирования контакта.
    /// </summary>
    /// <returns> Копия контакта </returns>
    public object Clone()
    {
        var contact = new Contact
        {
            FirstName = FirstName,
            LastName = LastName,
            Birthday = Birthday,
            VkId = VkId,
            Email = Email,
            PhoneNumber = PhoneNumber
        };

        return contact;
    }

    /// <summary>
    ///   Метод проверки валидации строки по ее длине.
    /// </summary>
    /// <param name="str"> Проверяемая строка </param>
    /// <param name="minLen"> Минимально допустимая длина </param>
    /// <param name="maxLen"> Максимально допустимая длина </param>
    /// <exception cref="ArgumentOutOfRangeException"></exception>
    private static void ValidateStringLength(string str, int minLen, int maxLen)
    {
        if (str.Length > maxLen || str.Length < minLen)
            throw new ArgumentOutOfRangeException();
    }
}