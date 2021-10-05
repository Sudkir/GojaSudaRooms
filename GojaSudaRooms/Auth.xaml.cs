using GojaSudaRooms.Admin;
using GojaSudaRooms.Helper;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GojaSudaRooms
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public static RoomInteriorsEntitiesLast DB = new RoomInteriorsEntitiesLast();


        public Auth()
        {
            InitializeComponent();


        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            var userModel = DB.User.FirstOrDefault
                (i => i.Login == txbLogin.Text && i.Password == psbPassword.Password);
            if (psbPassword.Password == psbPasswordRepeat.Password)
            {
                if (userModel == null)
                {
                    MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK);
                }
                else if (userModel.IdRole == 1)
                {
                    AdminMain aM = new AdminMain();
                    aM.Show();
                    Application.Current.MainWindow.Close();
                }
                else
                {
                    MessageBox.Show("Пароль не совпадает", "Ошибка", MessageBoxButton.OK);
                }
            }

        }

        private void btnEnter_Click1(object sender, RoutedEventArgs e)
        {
            AdminMain aM = new AdminMain();
            aM.Show();
            Application.Current.MainWindow.Close();
        }
    }
}
