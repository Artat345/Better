using System.Windows;

namespace GreetingApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void GreetButton_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string lastName = LastNameTextBox.Text;

            // Формируем приветствие
            string greeting = $"Привет, {firstName} {lastName}!";
            GreetingTextBlock.Text = greeting;
        }
    }
}