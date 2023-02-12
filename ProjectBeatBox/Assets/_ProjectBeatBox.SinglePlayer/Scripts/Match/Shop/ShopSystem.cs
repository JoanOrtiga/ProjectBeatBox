using System;
using UnityEngine;

namespace _ProjectBeatBox.SinglePlayer.Scripts.Match.Shop
{
    public class ShopSystem : MonoBehaviour
    {
        private ShopProvider _shopProvider;
        private ShopViewUI _shopViewUI;

        private void Awake()
        {
            _shopProvider = GetComponent<ShopProvider>();
            _shopViewUI = GetComponent<ShopViewUI>();
            
            ShowShop();
        }
        
        public void ShowShop()
        {
            var shopCards = _shopProvider.GetShopCards();
            _shopViewUI.Show(shopCards);
        }
    }
}
