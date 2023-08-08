using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using Steamworks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PikeMod.Projectiles
{
	public class ardentProj : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.arrow = true;
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.aiStyle = 0; // or 1
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.timeLeft = 64;
            Projectile.penetrate = -1;
            Projectile.tileCollide = false;
			Projectile.alpha = 0;
        }
        public override void AI()
		{
			if (Projectile.alpha < 255)
			{
				Projectile.alpha = Projectile.alpha + 4;
			}	//fade out slowly

            Lighting.AddLight(Projectile.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
			//make light
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.MagicMirror);
			//make dust
        }
    }
}