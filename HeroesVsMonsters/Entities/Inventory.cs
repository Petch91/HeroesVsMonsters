using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesVsMonsters.Entities
{
    public enum ItemType
    {
        Or,
        Cuir
    }
    public class Inventory
    {
        public Dictionary<ItemType, int> Items = new Dictionary<ItemType, int>();
        public int this[ItemType item]
        {
            get
            {
                if (!Items.ContainsKey(item))
                {
                    Items.Add(item, 0);
                }
                return Items[item];
            }
            set
            {
                if (!Items.ContainsKey(item))
                {
                    Items.Add(item, 0);
                }
                Items[item] = value;
            }
        }
        public static Inventory operator +(Inventory lhs, Inventory rhs)
        {
            foreach(ItemType item in rhs.Items.Keys) 
            {
                foreach(ItemType itemL in lhs.Items.Keys)
                {
                    if (item == itemL) 
                    {
                        lhs[item] += rhs[item];
                    }
                }
            }
            return lhs;
        }
    }
}
