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
using System.Windows.Shapes;

namespace CarrWarehouseAppWPF
{
    /// <summary>
    /// Логика взаимодействия для AddCarWindow.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        private DatabaseManager dbManager;

        public AddCarWindow(DatabaseManager manager)
        {
            InitializeComponent();
            dbManager = manager;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Create a new Car object with the information from the text boxes
            Car newCar = new Car
            {
                Brand = brandTextBox.Text,
                Model = modelTextBox.Text,
                Year = int.Parse(yearTextBox.Text),
                // Add more properties as needed
            };

            // Add the new car to the database
            dbManager.AddCar(newCar);

            // Close the window after saving
            this.Close();
        }
    }
}
