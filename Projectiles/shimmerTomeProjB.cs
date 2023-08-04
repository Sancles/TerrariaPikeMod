using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PikeMod.Projectiles
{
	public class shimmerTomeProjB : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.arrow = true;
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.aiStyle = 0; // or 1
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Magic;
		}

        public override void AI()
        {
			if (Projectile.ai[0] == 0f)
			{
				Vector2 refVelocity = Projectile.velocity;
				Projectile.ai[0] = refVelocity.X/30;
				Projectile.ai[1] = refVelocity.Y/30;

			}
			Projectile.ai[2]++;
			Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.ShimmerSplash);
			Projectile.velocity.X = Projectile.velocity.X - Projectile.ai[0];
			Projectile.velocity.Y = Projectile.velocity.Y - Projectile.ai[1];
			if (Projectile.ai[2] == 30f)
            {
				Projectile.Kill();
            }
			Lighting.AddLight(Projectile.Center, 0.2f, 0.1f, 0.6f);
		}
    }
}