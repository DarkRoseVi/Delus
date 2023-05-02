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
using Delus.Components;
namespace Delus.Pages
{
    /// <summary>
    /// Логика взаимодействия для AgentPage.xaml
    /// </summary>
    public partial class AgentPage : Page
    {
        public AgentPage()
        {
            AgentDelusEntities conetext = new AgentDelusEntities();
            InitializeComponent();
            ListProduct.ItemsSource = DBConnect.db.Agent.ToList();

         
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void TypeSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Addbtn_Click(object sender, RoutedEventArgs e)
        {
            Navigation.NextPage(new Nav("", new EditPriority(new AgentPriorityHistory())));
        }
    }
}
