using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PikeMod.Projectiles
{
	public class meteorMalletProj : ModProjectile
	{
		public float maxDuration = 15;
		public override void SetDefaults()
		{
			Projectile.arrow = true;
			Projectile.width = 64;
			Projectile.height = 64;
			Projectile.aiStyle = 0;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ownerHitCheck = true;
			Projectile.penetrate = -1;
			Projectile.stopsDealingDamageAfterPenetrateHits = true;
		}

        public override void OnSpawn(IEntitySource source)
        {
			Projectile.velocity = Projectile.velocity.RotatedByRandom(0.2);
			Projectile.velocity = Projectile.velocity.RotatedBy(-0.1);
			Projectile.ai[0] = maxDuration;
			Projectile.localAI[0] = (float)Projectile.direction;
		}
        public override void AI()
        {
			Player player = Main.player[Projectile.owner];
			Projectile.ai[0]--;
			Vector2 backToPlayer = Vector2.Subtract(Projectile.position,player.position);
			if (Projectile.ai[0] > 0)
            {
				Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.ToRadians(45f) + MathHelper.PiOver2;
			}
			else if(Projectile.ai[0] > -60)
			{
				Projectile.velocity -= backToPlayer.SafeNormalize(Vector2.Zero);
				Projectile.rotation += 0.3f * Projectile.localAI[0];
			}
			else 
			{
				Projectile.velocity = -backToPlayer.SafeNormalize(Vector2.Zero) * 20f;
				Projectile.rotation += 0.6f * Projectile.localAI[0];
			}
			if (Math.Abs(backToPlayer.X) < 32 && Math.Abs(backToPlayer.Y) < 32 && Projectile.ai[0] < 0)
            {
				Projectile.Kill();
            }
		}
    }
}