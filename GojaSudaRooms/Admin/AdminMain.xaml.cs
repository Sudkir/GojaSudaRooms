using System.Windows;

namespace GojaSudaRooms.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminMain.xaml
    /// </summary>
    public partial class AdminMain : Window
    {
        public AdminMain()
        {
            InitializeComponent();
        }

        private void btnListProduct_Click(object sender, RoutedEventArgs e)
        {
            frmMainAdmin.Navigate(new AdminPageProduct());
        }

        private void btnListUser_Click(object sender, RoutedEventArgs e)
        {
            frmMainAdmin.Navigate(new AdminPageUser());
        }

        private void btnListExitProfile_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mW = new MainWindow();
            mW.Show();
            this.Close();
        }

        private void btnListCloseApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
