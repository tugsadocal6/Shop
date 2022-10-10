using Model;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class Items: MonoBehaviour
    {
        [SerializeField] private List<Item> items;

        public bool CanAfford(Player player, string itemId) =>
            items.FirstOrDefault(i => i.id == itemId)?.price < player.gold;

        public IEnumerable<Item> MoreExpensiveThan(int amount) => items.Where(x => x.price> amount);
        public IEnumerable<Item> CheaperThan(int amount) => items.Where(x => x.price< amount);

    }
}