using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PikeMod.Projectiles
{
	public class earthSwordProj : ModProjectile
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
				Projectile.velocity.X *= 1.4f;
				Projectile.velocity.Y *= 1.4f;
				Vector2 refVelocity = Projectile.velocity.SafeNormalize(Vector2.UnitX);
				Projectile.ai[0] = refVelocity.X/7;
				Projectile.ai[1] = refVelocity.Y/7;

			}
			if (Main.rand.NextBool(5))
			{
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.BlueFairy);
			}
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			Projectile.velocity.X = Projectile.velocity.X + Projectile.ai[0];
			Projectile.velocity.Y = Projectile.velocity.Y + Projectile.ai[1];
			Lighting.AddLight(Projectile.Center, 0.1f, 0.9f, 0.4f);
		}
    }
}