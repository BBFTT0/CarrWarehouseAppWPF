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
    /// Логика взаимодействия для EditCarWindow.xaml
    /// </summary>
    public partial class EditCarWindow : Window
    {
        private DatabaseManager dbManager;
        private Car carToUpdate;

        public EditCarWindow(DatabaseManager manager, Car selectedCar)
        {
            InitializeComponent();
            dbManager = manager;
            carToUpdate = selectedCar;

            // Populate the text boxes with the selected car's information for editing
            brandTextBox.Text = carToUpdate.Brand;
            modelTextBox.Text = carToUpdate.Model;
            yearTextBox.Text = carToUpdate.Year.ToString();
            // Populate more text boxes as needed
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Update the properties of the selected car object with the information from the text boxes
            carToUpdate.Brand = brandTextBox.Text;
            carToUpdate.Model = modelTextBox.Text;
            carToUpdate.Year = int.Parse(yearTextBox.Text);
            // Update more properties as needed

            // Update the selected car's information in the database
            dbManager.UpdateCar(carToUpdate);

            // Close the window after updating
            this.Close();
        }
    }
}
