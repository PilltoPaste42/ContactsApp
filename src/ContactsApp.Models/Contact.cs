namespace ContactsApp.Models;

using System;

/// <summary>
///     Класс для хранения контакта
/// </summary>
public class Contact : ICloneable
{
    /// <summary>
    ///     Дата рождения
    /// </summary>
    public DateTime Birthday
    {
        get => Birthday;
        set
        {
            if (value > DateTime.Now || value.Year < 1900)
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    ///     Эл. почта
    /// </summary>
    public string Email
    {
        get => Email;
        set
        {
            ValidateStringLength(value, 0, 50);
            Email = value;
        }
    }

    /// <summary>
    ///     Имя контакта
    /// </summary>
    public string FirstName
    {
        get => FirstName;
        set
        {
            ValidateStringLength(value, 0, 50);
            FirstName =
                value[..1].ToUpper() +
                value[1..].ToLower();
        }
    }

    /// <summary>
    ///     Фамилия контакта
    /// </summary>
    public string LastName
    {
        get => LastName;
        set
        {
            ValidateStringLength(value, 0, 50);
            LastName =
                value[..1].ToUpper() +
                value[1..].ToLower();
        }
    }

    /// <summary>
    ///     Телефонный номер
    /// </summary>
    public PhoneNumber PhoneNumber { get; set; }

    /// <summary>
    ///     Идентификатор контакта в соц. сети vk.com
    /// </summary>
    public string VkId
    {
        get => VkId;
        set
        {
            ValidateStringLength(value, 0, 15);
            VkId = value;
        }
    }

    /// <summary>
    ///     Метод клонирования контакта
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
    ///     Метод проверки валидации строки по ее длине
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