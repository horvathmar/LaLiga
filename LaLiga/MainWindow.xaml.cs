using System;
using System.Text;
using System.Windows;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LaLiga
{
    public partial class MainWindow : Window
    {
        private List<Team> teams;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            teams = DataManager.LoadTeams();
            lstTeams.ItemsSource = teams;
        }

        private void lstTeams_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstTeams.SelectedItem is Team selected)
            {
                lblName.Content = $"Név: {selected.Name}";
                lblLocation.Content = $"Helyszín: {selected.Location}";
                lblStadium.Content = $"Stadion: {selected.Stadium}";
                lblFoundation.Content = $"Alapítás: {selected.FoundationDate.ToShortDateString()}";
                lblTitles.Content = $"Bajnoki címek: {selected.Titles}";
                lblActive.Content = $"Aktív: {(selected.IsActive ? "Igen" : "Nem")}";
                lblHasTitles.Content = $"Van címe: {(selected.HasTitles ? "Igen" : "Nem")}";
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            var editor = new TeamEditorWindow();
            if (editor.ShowDialog() == true)
            {
                teams.Add(editor.Team);
                DataManager.SaveTeams(teams);
                LoadData();
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (lstTeams.SelectedItem is Team selected)
            {
                var editor = new TeamEditorWindow(selected);
                if (editor.ShowDialog() == true)
                {
                    DataManager.SaveTeams(teams);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Válassz ki egy csapatot!");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (lstTeams.SelectedItem is Team selected)
            {
                teams.Remove(selected);
                DataManager.SaveTeams(teams);
                LoadData();
            }
            else
            {
                MessageBox.Show("Válassz ki egy csapatot!");
            }
        }
    }
}