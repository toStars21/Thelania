using System.Collections.Generic;

namespace Assets.Code.Scripts.Players
{
    public static class PlayersManager
    {
        public static Player MainPlayer { get; set; }
        public static List<Player> Opponents { get; set; } = new List<Player>();
    }
}
