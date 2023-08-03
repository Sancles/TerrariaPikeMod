using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PikeMod.Projectiles
{
	public class earthSwordProjB : ModProjectile
	{
		public override void SetDefaults()
		{
			Projectile.arrow = true;
			Projectile.width = 2;
			Projectile.height = 42;
			Projectile.aiStyle = 0; // or 1
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
		}

        public override void AI()
        {
			if (Projectile.ai[0] == 0f)
			{
				Vector2 refVelocity = Projectile.velocity.SafeNormalize(Vector2.UnitX);
				Projectile.ai[0] = refVelocity.X/3;
				Projectile.ai[1] = refVelocity.Y/3;

			}
			if (Main.rand.NextBool(5))
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.GreenFairy);
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Projectile.velocity.X = Projectile.velocity.X + Projectile.ai[0];
			Projectile.velocity.Y = Projectile.velocity.Y + Projectile.ai[1];
			Lighting.AddLight(Projectile.Center, 0.1f, 0.4f, 0.9f);
		}
    }
}