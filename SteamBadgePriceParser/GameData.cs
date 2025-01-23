using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamBadgePriceParser
{
    public class GameData
    {
        public string id { get; set; }
        public string name { get; set; }
        public float price { get; set; }

        public GameData() { }
        public GameData(string gameId = "", string gameName = "", float gamePrice = 0f) 
        {
            id = gameId;
            name = gameName;
            price = gamePrice;
        }

        public string GetMarketUrl(bool foil = false)
        {
            string foildbadge = foil ? "1" : "0";
            return $"https://steamcommunity.com/market/search?q=&category_753_Event%5B%5D=any&category_753_Game%5B%5D=tag_app_{id}&category_753_cardborder%5B%5D=tag_cardborder_{foildbadge}&appid=753";
        }

        public string GetExchangeUrl()
        {
            return $"https://www.steamcardexchange.net/index.php?gamepage-appid-{id}";
        }
    }
}
