using GojaSudaRooms.Helper;
using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GojaSudaRooms.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminAddProduct.xaml
    /// </summary>
    public partial class AdminAddProduct : Window
    {
        public static RoomInteriorsEntities DB = new RoomInteriorsEntities();
        Image imgImageProduct = new Image();
        public AdminAddProduct()
        {
            InitializeComponent();
        }

        private void txbName_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void cmbFiltrationCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void txbPrice_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txbDescription_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txbMaterial_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("", "", MessageBoxButton.YesNo);
            Product prodAdd = new Product();
            prodAdd.NameProduct = txbNameProduct.Text;
            prodAdd.IdCategory = cmbFiltrationCategory.SelectedIndex + 1;
            prodAdd.Price = Convert.ToDecimal(txbPrice.Text);

            DB.Product.Add(prodAdd);
            DB.SaveChanges();
            MessageBox.Show("","",MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void btnImageAdd_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFD = new OpenFileDialog();
            if (openFD.ShowDialog() == true)
            {
                string FileName = openFD.FileName;
                imgImageProduct.Source = new BitmapImage(new Uri(openFD.FileName));
                //А поля то нету для ссылки на ресурс
                string PathProduct = openFD.FileName;
            }
        }
    }
}
