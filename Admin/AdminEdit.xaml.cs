using GojaSudaRooms.Helper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace GojaSudaRooms.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminEdit.xaml
    /// </summary>
    ///

    //getJPGFromImageControl

    public partial class AdminEdit : Window
    {
        private readonly int ID = 0;
        private byte[] oldPhoto = null;
        public AdminAddProduct adminAddProduct = new AdminAddProduct();
        public static RoomInteriorsEntitiesLast DB = new RoomInteriorsEntitiesLast();
        private Image imgImageProduct = new Image();
        private List<string> listFiltr = new List<string>();
        public string FileName;

        public AdminEdit()
        {
            InitializeComponent();
        }

        public AdminEdit(int idED, string NameED, decimal PriceED, string materialEd,
            string DiscriptionED, int catED, byte[] photoED)
        {
            InitializeComponent();
            ID = idED;
            txbNameProduct.Text = NameED;
            txbPrice.Text = PriceED.ToString();
            txbDescription.Text = DiscriptionED;
            txbMaterial.Text = materialEd;
            oldPhoto = photoED;
            List<Category> category = DB.Category.ToList();
            foreach (var i in category)
            {
                listFiltr.Add(i.NameCategory);
            }

            listFiltr.Insert(0, "Все категории");
            cmbFiltrationCategory.ItemsSource = listFiltr;
            cmbFiltrationCategory.SelectedIndex = catED;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (txbNameProduct.Text == "" || txbMaterial.Text == "" || txbPrice.Text == "")
            {
                MessageBox.Show("Товар не был обновлен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы хотите редактировать товар?", "Подтверждение", MessageBoxButton.YesNo);

                DB.Product.Remove(DB.Product.Find(ID));
                DB.Product.Add(new Product
                //DB.Product создание объекта
                {

                    NameProduct = txbNameProduct.Text,
                    IdCategory = cmbFiltrationCategory.SelectedIndex,
                    Material = txbMaterial.Text,
                    Description = txbDescription.Text,
                    Price = Convert.ToDecimal(txbPrice.Text),
                    //проверка на null путь к фото
                    PhotoProduct = FileName != null ?
                    adminAddProduct.GetJPGFromImageControl(imgImageProduct.Source as BitmapImage) : oldPhoto
                });
                DB.SaveChanges();
                MessageBox.Show("Товар успешно обновлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }

        private void btnCloseWindow_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnImageAdd_Click(object sender, RoutedEventArgs e)
        {
            //открытие диалогового окна расположения фото продукта
            OpenFileDialog openFD = new OpenFileDialog();
            if (openFD.ShowDialog() == true)
            {
                FileName = openFD.FileName;
                imgImageProduct.Source = new BitmapImage(new Uri(openFD.FileName));
            }
        }
    }
}