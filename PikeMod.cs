using Terraria.ModLoader;
using System;

namespace PikeMod
{
    public class PikeMod : Mod
    {
        public static float degToRad(float deg)
        {
            double rad = (deg * Math.PI) / 180;
            float radf = (float)rad;
            return radf;
        }
    }
}