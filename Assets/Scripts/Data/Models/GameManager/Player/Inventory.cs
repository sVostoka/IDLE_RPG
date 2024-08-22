using Newtonsoft.Json;
using System;
using System.Collections.Generic;

public class Inventory : IDatable
{
    [JsonIgnore]
    public dynamic Default => new Inventory();

    public event Action UpdateIventory;

    public List<Item> Items { get; set; } = new();

    public void AddItem(Item item)
    {
        if (item.isCombined)
        {
            int index = Items.FindLastIndex(el => el.icon == item.icon);

            if (index == -1 || Items[index].count == Items[index].maxCombination)
            {
                item.count = (item.count == 0) ? 1 : item.count;
                Items.Add(item);
            }
            else
            {
                int plusCount = (item.count == 0) ? 1 : item.count;

                if(Items[index].count + plusCount > Items[index].maxCombination)
                {
                    int excess = Items[index].count + plusCount - Items[index].maxCombination;

                    Items[index].count = Items[index].maxCombination;

                    if(excess != 0)
                    {
                        item.count = excess;
                        Items.Add(item);
                    }
                }
                else
                {
                    Items[index].count += plusCount;
                }
                
            }
        }
        else
        {
            Items.Add(item);
        }

        UpdateIventory?.Invoke();
    }

    public void DeleteItem(Item item, bool InEquip = false)
    {
        if (item.isCombined && InEquip == false)
        {
            int index = Items.FindLastIndex(el => el.icon == item.icon);

            if(index != -1)
            {
                if(Items[index].count > 1)
                {
                    Items[index].count--;
                }
                else
                {
                    Items.RemoveAt(index);
                }
            }
        }
        else
        {
            Items.Remove(item);
        }

        UpdateIventory?.Invoke();
    }

    public string GetKey()
    {
        return Constants.Inventory.PREFSKEY;
    }

    public string GetDefault()
    {
        return Constants.Inventory.PREFSDEFAULT;
    }    
}