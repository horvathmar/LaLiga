using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LaLiga
{
    public static class DataManager
    {
        private const string TeamsFile = "teams.json";
        private const string CitiesFile = "cities.json";

        public static List<Team> LoadTeams()
        {
            if (File.Exists(TeamsFile))
            {
                string json = File.ReadAllText(TeamsFile);
                return JsonSerializer.Deserialize<List<Team>>(json);
            }
            return new List<Team>();
        }

        public static void SaveTeams(List<Team> teams)
        {
            string json = JsonSerializer.Serialize(teams, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(TeamsFile, json);
        }

        public static List<string> LoadCities()
        {
            if (File.Exists(CitiesFile))
            {
                string json = File.ReadAllText(CitiesFile);
                return JsonSerializer.Deserialize<List<string>>(json);
            }
            return new List<string>();
        }
    }
}
