using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
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
using WolcenMod.Models;
using WolcenMod.Models.playerchest;
using Panel = WolcenMod.Models.playerchest.Panel;

namespace WolcenMod
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string path = string.Empty;
        Chest chest;

        public MainWindow()
        {
            InitializeComponent();

            GetPath();
            CheckBackupExists();

            combobox_type.ItemsSource = Enum.GetValues(typeof(Types)).Cast<Types>();
            combobox_type.SelectedIndex = 0;
            combobox_tier.ItemsSource = Enum.GetValues(typeof(GemTier)).Cast<GemTier>();
            combobox_tier.SelectedIndex = 0;
        }

        private void GetPath()
        {
            if(File.Exists(Directory.GetCurrentDirectory() + "\\settings.txt"))
            {
                path = new StreamReader(Directory.GetCurrentDirectory() + "\\settings.txt").ReadToEnd();
            }
            else
            {
                MessageBox.Show("Select the path to your playerchest.json \n\n C:/Users/UserName/Saved Games/wolcen/savegames/playerchest.json");
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if(openFileDialog.ShowDialog() == true)
                {
                    File.WriteAllText(Directory.GetCurrentDirectory() + "\\settings.txt", openFileDialog.FileName);
                    path = openFileDialog.FileName;
                }
            }

            if (path == string.Empty)
                GetPath();
        }

        private void CheckBackupExists()
        {
            if(!File.Exists(Directory.GetCurrentDirectory() + "\\playerchest_backup.json"))
            {
                label_last_backup.Content = $"Last backup: none";
                button_restore_backup.IsEnabled = false;
            }
            else
            {
                label_last_backup.Content = $"Last backup: {File.GetLastWriteTime(Directory.GetCurrentDirectory() + "\\playerchest_backup.json")}";
            }
        }

        private void button_path_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(Directory.GetCurrentDirectory() + "\\settings.txt", openFileDialog.FileName);
                path = openFileDialog.FileName;
            }
        }

        private void button_save_Click(object sender, RoutedEventArgs e)
        {
            if(IsProcessOpen() == true)
            {
                MessageBox.Show("Please close your game, before adding items");
                return;
            }

            Dispatcher.Invoke(() => button_save.IsEnabled = false);

            // Load current chest data
            string json = File.ReadAllText(path);
            chest = JsonConvert.DeserializeObject<Chest>(json);

            KeyValuePair<int, int> chosen_item_slot = new KeyValuePair<int, int>(-1, -1);
            Panel chosen_Panel = null;

            foreach (var panel in chest.Panels)
            {
                // Check if panel is locked
                if (panel.Locked)
                    continue;

                // Base check
                if (chosen_item_slot.Key != -1 && chosen_item_slot.Value != -1)
                    break;

                List<KeyValuePair<int, int>> occupiedSlots = chest.GetOccupiedSlots(panel);

                for (int y = 0; y < 9; y++)
                {
                    // Base check
                    if (chosen_item_slot.Key != -1 && chosen_item_slot.Value != -1)
                        break;

                    for (int x = 0; x < 9; x++)
                    {
                        KeyValuePair<int, int> currentSlot = new KeyValuePair<int, int>(x, y);
                        if (!occupiedSlots.Contains(currentSlot))
                        {
                            chosen_item_slot = new KeyValuePair<int, int>(x, y);
                            chosen_Panel = panel;
                            break;
                        }
                    }
                }
            }

            // Check if did not find a free slot
            if(chosen_item_slot.Key == -1 && chosen_item_slot.Value == -1)
            {
                MessageBox.Show("Your bank is full");
                return;
            }

            Item item = new Item();
            item.InventoryX = chosen_item_slot.Key;
            item.InventoryY = chosen_item_slot.Value;

            switch ((Types)combobox_type.SelectedItem)
            {
                case Types.Gem:
                    var gem_item = (ItemGem)combobox_item.SelectedItem;
                    var gem_name = gem_item.GetStringValue();
                    var gem_rarity = gem_item.GetRarityValue();
                    var gem_quality = gem_item.GetQualityValue();
                    var gem_type = gem_item.GetTypeValue();

                    var tier = (GemTier)combobox_tier.SelectedItem;
                    var gem_tier = tier.GetStringValue();

                    item.Gem = new Gem()
                    {
                        Name = gem_name + gem_tier,
                        StackSize = 20
                    };

                    item.Rarity = gem_rarity;
                    item.Quality = gem_quality;
                    item.Type = gem_type;
                    item.ItemType = "Gem";
                    item.Value = "1";
                    item.Level = 90;
                    break;

                case Types.Reagent:
                    var reagent_item = (ItemReagent)combobox_item.SelectedItem;
                    var reagent_name = reagent_item.GetStringValue();
                    var reagent_rarity = reagent_item.GetRarityValue();
                    var reagent_quality = reagent_item.GetQualityValue();
                    var reagent_type = reagent_item.GetTypeValue();

                    item.Reagent = new Reagent()
                    {
                        Name = reagent_name,
                        StackSize = 20
                    };

                    item.Rarity = reagent_rarity;
                    item.Quality = reagent_quality;
                    item.Type = reagent_type;
                    item.Value = "1";
                    item.Level = 90;
                    break;

                case Types.Map:
                    var map_item = (ItemMap)combobox_item.SelectedItem;
                    var map_name = map_item.GetStringValue();
                    var map_rarity = map_item.GetRarityValue();
                    var map_quality = map_item.GetQualityValue();
                    var map_type = map_item.GetTypeValue();

                    item.NPC2Consumable = new NPC2Consumable()
                    {
                        Name = map_name
                    };

                    item.Rarity = map_rarity;
                    item.Quality = map_quality;
                    item.Type = map_type;
                    item.Value = "1";
                    item.Level = 90;
                    break;
            }

            chest.Panels.Find((p) => p.Id == chosen_Panel.Id).InventoryGrid.Add(item);

            // Save updated chest data
            File.WriteAllText(path, JsonConvert.SerializeObject(chest, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore }));

            Dispatcher.Invoke(() => button_save.IsEnabled = true);
        }

        private void combobox_type_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            combobox_tier.Visibility = Visibility.Hidden;

            var type = (Types)combobox_type.SelectedItem;

            switch(type)
            {
                case Types.Gem:
                    combobox_item.ItemsSource = Enum.GetValues(typeof(ItemGem)).Cast<ItemGem>();
                    combobox_tier.Visibility = Visibility.Visible;
                    break;

                case Types.Reagent:
                    combobox_item.ItemsSource = Enum.GetValues(typeof(ItemReagent)).Cast<ItemReagent>();
                    break;

                case Types.Map:
                    combobox_item.ItemsSource = Enum.GetValues(typeof(ItemMap)).Cast<ItemMap>();
                    break;
            }

            combobox_item.SelectedIndex = 0;
        }


        private void button_save_backup_Click(object sender, RoutedEventArgs e)
        {
            var json_backup = File.ReadAllText(path);
            File.WriteAllText(Directory.GetCurrentDirectory() + "\\playerchest_backup.json", json_backup);
            label_last_backup.Content = $"Last backup: {File.GetLastWriteTime(Directory.GetCurrentDirectory() + "\\playerchest_backup.json")}";
            button_restore_backup.IsEnabled = true;
        }

        private void button_backup_Click(object sender, RoutedEventArgs e)
        {
            if (IsProcessOpen() == true)
            {
                MessageBox.Show("Please close your game, before restoring the backup");
                return;
            }

            var json_backup = File.ReadAllText(Directory.GetCurrentDirectory() + "\\playerchest_backup.json");
            File.WriteAllText(path, json_backup);
            MessageBox.Show("Backup file has been restored");
        }

        
        private bool IsProcessOpen()
        {
            Process exe = Process.GetProcesses().ToList().Find((p) => p.ProcessName == "Wolcen");
            if (exe != null)
                return true;

            return false;
        }
    }
}
