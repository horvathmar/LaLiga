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

namespace LaLiga
{
    public partial class TeamEditorWindow : Window
    {
        public Team Team { get; private set; }

        public TeamEditorWindow(Team team = null)
        {
            InitializeComponent();
            cmbLocation.ItemsSource = DataManager.LoadCities();

            if (team != null)
            {
                Team = team;
                txtName.Text = team.Name;
                cmbLocation.SelectedItem = team.Location;
                txtStadium.Text = team.Stadium;
                dpFoundation.SelectedDate = team.FoundationDate;
                txtTitles.Text = team.Titles.ToString();
                chkActive.IsChecked = team.IsActive;
                if (team.HasTitles) rbYes.IsChecked = true;
                else rbNo.IsChecked = true;
            }
            else
            {
                Team = new Team();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text) || cmbLocation.SelectedItem == null || dpFoundation.SelectedDate == null || string.IsNullOrEmpty(txtTitles.Text))
            {
                MessageBox.Show("Tölts ki minden mezőt!");
                return;
            }

            Team.Name = txtName.Text;
            Team.Location = cmbLocation.SelectedItem.ToString()!;
            Team.Stadium = txtStadium.Text;
            Team.FoundationDate = dpFoundation.SelectedDate.Value;
            Team.Titles = int.Parse(txtTitles.Text);
            Team.IsActive = chkActive.IsChecked ?? false;
            Team.HasTitles = rbYes.IsChecked ?? false;

            DialogResult = true;
            Close();
        }
    }
}
