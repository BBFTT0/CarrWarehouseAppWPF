using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarrWarehouseAppWPF
{
    public partial class MainWindow : Window
    {

        private DatabaseManager dbManager;


        public MainWindow()
        {
            InitializeComponent();

            string server = "NOUT";
            string database = "CarWarehouseAppWPF";
            string username = "NAMI";
            string password = "namissms";
            string connectionString = $"Server={server};Database={database};User Id={username};Password={password};";
            dbManager = new DatabaseManager(server, database, username, password);
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordBox.Password;

            if (dbManager.ValidateUser(username, password))
            {
                CarStorageWindow carStorageWindow = new CarStorageWindow();
                carStorageWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль");
            }
        }

    }
}
