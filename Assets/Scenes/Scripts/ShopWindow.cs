using UnityEngine;
using TMPro;
using Persistence;
using System;
using Model;

namespace UI
{
    [AddComponentMenu("Game/UI/Shop Window")]
    public class ShopWindow : MonoBehaviour
    {
        public string shopId;
        public string playerId;

        [Header("Dependencies")]
        public UnitOfWork unitOfWork;
        public GameObject itemViewPrefab;

        [Header("UI Elements")] public Transform itemGrid;
        public TMP_Text shopNameLabel;
        public TMP_Text shopGoldLabel;
        public TMP_Text playerGoldLabel;


        public void Refresh()
        {
            var shop = unitOfWork.Shops.GetById(shopId);
            var player = unitOfWork.Players.GetById(playerId);

            shopNameLabel.text = shop.name;
            shopGoldLabel.text = shop.gold.ToString();
            playerGoldLabel.text = player.gold.ToString();
            //ClearItemGrid();
            //PopulateItemGrid();
        }

        public void Buy(Item item)
        {
            var shop = unitOfWork.Shops.GetById(shopId);
            var player = unitOfWork.Players.GetById(playerId);

            if (!shop.products.Contains(item)) return;
            if (!(player.gold < item.price)) return;

            player.gold -= item.price;
            player.inventory.Add(item);
            unitOfWork.Players.Modify(player);

            UpdateAchievementSystem();

            shop.gold += item.price;
            shop.products.Remove(item);
            unitOfWork.Shops.Modify(shop);

            unitOfWork.Save();
        }

        private void UpdateAchievementSystem()
        {
            throw new NotImplementedException();
        }
    }

}

