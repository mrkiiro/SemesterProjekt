using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App8
{
    class ComboBoxOptionsMangerger
    {
        

            void GetComboBoxList(ObservableCollection<ViewModelClerk.ComboBoxItem> ComboBoxItems)
            {
                var allItems = getComboBoxItems();
                ComboBoxItems.Clear();
                allItems.ForEach(p => ComboBoxItems.Add(p));
            }

            List<ViewModelClerk.ComboBoxItem> getComboBoxItems()
            {
                var items = new List<ViewModelClerk.ComboBoxItem>();

                items.Add(new ViewModelClerk.ComboBoxItem() { ComboBoxOption = "Option1", ComboBoxHumanReadableOption = "Option 1" });
                items.Add(new ViewModelClerk.ComboBoxItem() { ComboBoxOption = "Option2", ComboBoxHumanReadableOption = "Option 2" });
                items.Add(new ViewModelClerk.ComboBoxItem() { ComboBoxOption = "Option3", ComboBoxHumanReadableOption = "Option 3" });

                return items;
            }
    }
}

