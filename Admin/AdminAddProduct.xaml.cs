using GojaSudaRooms.Helper;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
        public static RoomInteriorsEntitiesLast DB = new RoomInteriorsEntitiesLast();

        private Image imgImageProduct = new Image();
        private List<string> listFiltr = new List<string>();
        public string FileName;

        public AdminAddProduct()
        {
            InitializeComponent();
            CatList();
        }

        public void CatList()
        //Вывод списка категорий
        {
            List<Category> category = DB.Category.ToList();
            foreach (var i in category)
            {
                listFiltr.Add(i.NameCategory);
            }

            listFiltr.Insert(0, "Все категории");
            cmbFiltrationCategory.ItemsSource = listFiltr;
            cmbFiltrationCategory.SelectedIndex = 0;
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
            //Application.Current.Shutdown();
            Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        //добавление нового продукта в БД
        {
            if (txbNameProduct.Text == "" || txbMaterial.Text == "" || txbPrice.Text == "")
            {
                MessageBox.Show("Товар не добавлен", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult result = MessageBox.Show("Вы хотите добавить материал?", "Подтверждение", MessageBoxButton.YesNo);
                Product prodAdd = new Product
                //DB.Product создание объекта
                {
                    NameProduct = txbNameProduct.Text,
                    IdCategory = cmbFiltrationCategory.SelectedIndex,
                    Material = txbMaterial.Text,
                    Description = txbDescription.Text,
                    //проверка на null путь к фото
                    PhotoProduct = FileName != null ?
                    GetJPGFromImageControl(imgImageProduct.Source as BitmapImage) : null,
                    Price = Convert.ToDecimal(txbPrice.Text)
                };

                DB.Product.Add(prodAdd);
                DB.SaveChanges();
                MessageBox.Show("Товар успешно добавлен", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                Close();
            }
        }

        public byte[] GetJPGFromImageControl(BitmapImage imageC)
        // перевод изображения в byte[] для хранения в БД
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
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