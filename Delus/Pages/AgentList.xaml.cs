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
using Delus.Pages;
using Delus.Components;

namespace Delus.Pages
{
    /// <summary>
    /// Логика взаимодействия для AgentList.xaml
    /// </summary>
    public partial class AgentList : Window
    {
        public List< Agent> agents { get; set; }
        public AgentPriorityHistory gkhgchjf { get; set; }

        public AgentList(IEnumerable<Agent> _agent, AgentPriorityHistory agentshistoru)
        {
            gkhgchjf = agentshistoru;
            List<int> ingredientIds = _agent.Select(s => s.ID).ToList();

            agents = DBConnect.db.Agent.ToList();
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DBConnect.db.AgentPriorityHistory.Add(new AgentPriorityHistory
            {
                Agent = IngridientList.SelectedItem as Agent,
                ID = gkhgchjf.ID,
                ChangeDate = DateTime.Now,
            });
            DBConnect.db.SaveChanges();
        EditPriority.UpdateIngridientList(gkhgchjf);

            Close();
        }
    }
}
