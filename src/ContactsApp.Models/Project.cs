namespace ContactsApp.Models;

using System.Collections.Generic;

/// <summary>
///     Класс проекта телефонного справочника
/// </summary>
public class Project
{
    /// <summary>
    ///     Список контактов справочника
    /// </summary>
    public List<Contact>? Contacts { get; set; }
}