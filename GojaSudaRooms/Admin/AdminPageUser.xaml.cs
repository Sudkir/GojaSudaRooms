using GojaSudaRooms.Helper;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GojaSudaRooms.Admin
{
    /// <summary>
    /// Логика взаимодействия для AdminPageUser.xaml
    /// </summary>
    public partial class AdminPageUser : Page
    {
        public static RoomInteriorsEntitiesLast DB = new RoomInteriorsEntitiesLast();
        List<User> listUser = new List<User>();
       
        public AdminPageUser()
        {
            InitializeComponent();

            listUser = DB.User.ToList();
            LvUser.ItemsSource = listUser;
        }

        private void btnBackFrm_Click(object sender, RoutedEventArgs e)
        {
            Content = null;
        }

        private void LvUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
