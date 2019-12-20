﻿using Assets.Code.Core;
using Assets.Code.Extensions;

namespace Thelania.Core.Aspects
{
    public class CanUpgradeAspect : IAspect, ICanUpgrade
    {
        public int Level { get; private set; }

        public CanUpgradeAspect(int level)
        {
            level.AssertGreaterThan(0);

            Level = level;
        }

        public void Upgrade()
        {
            Level++;
        }
    }
}