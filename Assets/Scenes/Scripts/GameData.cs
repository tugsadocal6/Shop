using System.Collections.Generic;
using System;
using Model;

namespace Persistance
{
    [Serializable]
    public class GameData
    {
        public List<Player> players;
        public List<Shop> shops;
    }
}
