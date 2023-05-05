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
using Delus.Pages;


namespace Delus.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditAgentPage.xaml
    /// </summary>
    public partial class EditAgentPage : Page
    {
        public static Agent agents { get; set; }
        public EditAgentPage(Agent _agent)
        {
            agents = _agent;
            InitializeComponent();
            TypeCb.ItemsSource = DBConnect.db.AgentType.ToList();
            TypeCb.DisplayMemberPath = "Title";
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var ahen = DBConnect.db.Agent.Where(x => x.Title == TitleTb.Text.Trim()).FirstOrDefault();
            if (ahen == null)
            {
                DBConnect.db.Agent.Add(agents);
            }
            MessageBox.Show("Сохранено");
            DBConnect.db.SaveChanges();
           
        }
    }
}
