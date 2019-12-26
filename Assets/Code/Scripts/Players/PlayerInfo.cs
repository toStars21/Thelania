using System;

namespace Assets.Code.Scripts.Players
{
    [Serializable]
    public class PlayerInfo
    {
        public string name;
        public double money;

        public static PlayerInfo Create(string playerName)
        {
            return new PlayerInfo
            {
                name = playerName,
                money = 1000
            };
        }
    }
}
