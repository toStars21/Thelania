using System.Collections.Generic;

namespace Assets.Code.Scripts.Players
{
    public static class PlayersManager
    {
        public static PlayerInfo MainPlayer { get; private set; }
        public static List<PlayerInfo> Opponents { get; } = new List<PlayerInfo>();

        public static void AddMainPlayer(string name)
        {
            MainPlayer = BuildPlayer(name);
        }

        public static void InitializeOpponents(int count)
        {
            for (int oppCount = 0; oppCount < count; oppCount++)
            {
                string opponentName = $"Player{oppCount + 1}" == MainPlayer.name ? "Vitia" : $"Player{oppCount + 1}";
                Opponents.Add(BuildPlayer(opponentName));
            }
        }

        private static PlayerInfo BuildPlayer(string name)
        {
            return new PlayerInfo
            {
                money = 1000,
                name = name
            };
        }
    }
}
