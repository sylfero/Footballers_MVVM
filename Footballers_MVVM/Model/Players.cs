using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Footballers_MVVM.Model
{
    class Players
    {
        public ObservableCollection<Player> ListOfPlayers { get; set; } = new ObservableCollection<Player>();

        public Players()
        {
            byte[] json = File.ReadAllBytes("Players.json");
            var readOnlySpan = new ReadOnlySpan<byte>(json);
            ListOfPlayers = JsonSerializer.Deserialize<ObservableCollection<Player>>(readOnlySpan);
        }

        public void AddPlayer(string firstName, string lastName, int age, int weight)
        {
            ListOfPlayers.Add(new Player(firstName, lastName, age, weight));
        }

        public void EditPlayer(string firstName, string lastName, int age, int weight, int id)
        {
            ListOfPlayers[id] = new Player(firstName, lastName, age, weight);
        }

        public void RemovePlayer(int id)
        {
            ListOfPlayers.RemoveAt(id);
        }

        public void Save()
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            byte[] json = JsonSerializer.SerializeToUtf8Bytes(ListOfPlayers, options);
            File.WriteAllBytes("Players.json", json);
        }
    }
}
