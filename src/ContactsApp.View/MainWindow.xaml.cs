namespace ContactsApp.View
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddContactButton_OnClick(object sender, RoutedEventArgs e)
        {
            CreateAddContactForm();
        }

        private Window CreateAddContactForm()
        {
            var window = new AddContactWindow
            {
                Owner = this
            };
            window.Show();

            return window;
        }

        private void MenuEditAdd_OnClick(object sender, RoutedEventArgs e)
        {
            CreateAddContactForm();
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
    }
}