using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using System;
using Terraria.Audio;
using Terraria;
using Terraria.ID;
using PikeMod.Items.Materials;

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

        public static void EmitMaxManaEffect(Player player)
        {
            SoundEngine.PlaySound(SoundID.MaxMana);
            for (int index1 = 0; index1 < 5; ++index1)
            {
                int index2 = Dust.NewDust(player.position, player.width, player.height, DustID.ManaRegeneration, 0.0f, 0.0f, (int)byte.MaxValue, new Color(), (float)Main.rand.Next(20, 26) * 0.1f);
                Main.dust[index2].noLight = true;
                Main.dust[index2].noGravity = true;
                Main.dust[index2].velocity *= 0.5f;
            }
        }
    }
}