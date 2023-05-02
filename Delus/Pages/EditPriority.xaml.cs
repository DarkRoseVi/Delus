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
    /// Логика взаимодействия для EditPriority.xaml
    /// </summary>
    public partial class EditPriority : Page
    {
        public static EditPriority Instance { get; private set; }
        public IEnumerable<Agent> ingrediebt
        {
            get { return (IEnumerable<Agent>)GetValue(ingrediebtProperty); }
            set { SetValue(ingrediebtProperty, value); }
        }

        public static readonly DependencyProperty ingrediebtProperty =
            DependencyProperty.Register("ingrediebt", typeof(IEnumerable<Agent>), typeof(EditPriority));



        //public IEnumerable<AgentPriorityHistory>   dadasd
        //{
        //    get { return (IEnumerable<AgentPriorityHistory>)GetValue(dadasdProperty); }
        //    set { SetValue(dadasdProperty, value); }
        //}

        // Using a DependencyProperty as the backing store for dadasd.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty dadasdProperty =
        //    DependencyProperty.Register("dadasd", typeof(IEnumerable<AgentPriorityHistory>), typeof(EditPriority));



        public AgentPriorityHistory asdas{get;set;}
        public EditPriority(AgentPriorityHistory  _asdasd)
        {
            asdas = _asdasd;
            ingrediebt = DBConnect.db.Agent.ToList();
            InitializeComponent();
            Instance = this;
            UpdateIngridientList(asdas);
        }
        public static void UpdateIngridientList(AgentPriorityHistory asdas)
        {
            Instance.ingrediebt = DBConnect.db.Agent.Where(x => x.ID == asdas.AgentID).ToList();
        }
        private void AddBtn_Click(object sender, RoutedEventArgs e)=>
             new AgentList(ingrediebt, asdas).ShowDialog();

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            asdas.ChangeDate = DateTime.Now;
            
            asdas.PriorityValue = int.Parse(ProrTB.Text);
            DBConnect.db.SaveChanges();


        }
    }
}
