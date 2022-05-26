namespace ContactsApp.Models;

using System;
using System.IO;
using System.Linq;

/// <summary>
///   Класс фиктивного контакта для отладки.
/// </summary>
public static class ContactMock
{
    private const string RANDOM_NAMES_PATH = "DataForDebug/random_names.csv";

    private static readonly Random Generator = new();

    /// <summary>
    ///   Создание фиктивного контакта.
    /// </summary>
    public static Contact Get()
    {
        var fullName = GetRandomFullName().Split(' ');
        var firstName = fullName[1];
        var lastName = fullName[0];

        return new Contact
        {
            FirstName = firstName,
            LastName = lastName,
            Birthday = GetRandomDate(),
            PhoneNumber = GetRandomPhoneNumber(),
            Email = GetRandomEmail(),
            VkId = "None"
        };
    }

    /// <summary>
    ///   Получение случайной даты.
    /// </summary>
    private static DateTime GetRandomDate()
    {
        var startDate = new DateTime(1991, 1, 1);
        var endDate = DateTime.Now;
        var range = (endDate - startDate).Days;

        return startDate.AddDays(Generator.Next(range));
    }

    /// <summary>
    ///   Получение случайного email.
    /// </summary>
    private static string GetRandomEmail()
    {
        return "fake" + Generator.Next(100, 999) + "@mail.com";
    }

    /// <summary>
    ///   Получение случайного ФИО из файла.
    /// </summary>
    /// <returns> Строка с полным именем </returns>
    private static string GetRandomFullName()
    {
        var range = File.ReadAllLines(RANDOM_NAMES_PATH).Length;
        var fullName = File
            .ReadLines(RANDOM_NAMES_PATH)
            .Skip(Generator.Next(range))
            .First();

        return fullName;
    }

    /// <summary>
    ///   Получение случайного номера телефона.
    /// </summary>
    private static PhoneNumber GetRandomPhoneNumber()
    {
        var num = (ulong) Generator.NextInt64(70000000001, 79999999999);
        return new PhoneNumber(num);
    }
}