using System.Collections.Generic;

namespace Assets.Code.Scripts.Color
{
    public static class ColorManager
    {
        private static Queue<UnityEngine.Color> _availableColors;

        static ColorManager()
        {
            _availableColors = new Queue<UnityEngine.Color>();
            _availableColors.Enqueue(UnityEngine.Color.red);
            _availableColors.Enqueue(UnityEngine.Color.blue);
            _availableColors.Enqueue(UnityEngine.Color.green);
            _availableColors.Enqueue(UnityEngine.Color.white);
            _availableColors.Enqueue(UnityEngine.Color.yellow);
            _availableColors.Enqueue(UnityEngine.Color.cyan);
            _availableColors.Enqueue(UnityEngine.Color.magenta);
        }

        public static UnityEngine.Color GetNextColor()
        {
            return _availableColors.Dequeue();
        }
    }
}
