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

namespace Poprygenok
{
    /// <summary>
    /// Логика взаимодействия для Agent.xaml
    /// </summary>
    public partial class Agent : Window
    {
        List<Agents> _agents;
        public Agent()
        {
            InitializeComponent();
            ПопрыженокEntities db = new ПопрыженокEntities();
            _agents = db.Agents.ToList();
            Agents.ItemsSource = _agents;
            ComboBoxSortAgents.ItemsSource = new List<string>
            {
                "Все",
                "По имени по возрастанию",
                "По имени по убыванию",
                "По приоритету по возрастанию",
                "По приоритету по убыванию",
                "По скидке по возрастанию",
                "По скидке по убыванию"
            };

            ComboBoxSortAgents.SelectedIndex = 0;
        }
        
        private void ComboBoxSortAgents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var sorted = _agents;

            sorted = SortAgents(sorted);

            Agents.ItemsSource = sorted;
        }

        private List<Agents> SortAgents(List<Agents> agents)
        {
            switch(ComboBoxSortAgents.SelectedIndex)
            {
                case 0:
                    {
                        break;
                    }
                case 1:
                    {
                        agents = agents.OrderBy(a => a.Name).ToList();
                        break;
                    }
                case 2:
                    {
                        agents = agents.OrderByDescending(a => a.Name).ToList();
                        break;
                    }
                case 3:
                    break;
            }

            return agents;
        }

        private void TextBoxSearchAgents_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searched = _agents;

            searched = SearchAgents(searched);

            Agents.ItemsSource = searched;
        }

        private List<Agents> SearchAgents(List<Agents> agents)
        {
            agents = agents.Where(
                a => a.Name.ToLower().Contains(TextBoxSearchAgents.Text.ToLower()))
                .ToList();

            return agents;
        }
    }
}
