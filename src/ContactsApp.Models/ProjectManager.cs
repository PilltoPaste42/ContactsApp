namespace ContactsApp.Models;

using System.IO;

using Newtonsoft.Json;

/// <summary>
///     Класс для работы с данными приложения
/// </summary>
public sealed class ProjectManager
{
    /// <summary>
    ///     Путь к файлу для чтения/записи данных
    /// </summary>
    private const string PROJECT_FILE_PATH = "./ContactsApp.notes";

    /// <summary>
    ///     Экземпляр менеджера проекта (реализация паттерна Singleton)
    /// </summary>
    private static ProjectManager? _instance;

    private ProjectManager()
    {
        if (!File.Exists(PROJECT_FILE_PATH))
        {
            File.Create(PROJECT_FILE_PATH);
        }
    }

    /// <summary>
    ///     Метод получения экземпляра менеджера проекта
    /// </summary>
    public static ProjectManager? Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ProjectManager();

            return _instance;
        }
        private set { }
    }

    /// <summary>
    ///     Метод загрузки данных проекта из файла
    /// </summary>
    public static Project LoadProject()
    {
        var text = File.ReadAllText(PROJECT_FILE_PATH);

        return JsonConvert.DeserializeObject<Project>(text);
    }

    public static void SaveProject(Project project)
    {
        var text = JsonConvert.SerializeObject(project);
        File.WriteAllText(PROJECT_FILE_PATH, text);
    }
}