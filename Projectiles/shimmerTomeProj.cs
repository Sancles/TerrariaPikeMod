using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace PikeMod.Projectiles
{
	public class shimmerTomeProj : ModProjectile
	{
        public override void SetStaticDefaults()
        {
			Main.projFrames[Projectile.type] = 4;
        }
        public override void SetDefaults()
		{
			Projectile.arrow = true;
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.aiStyle = 0; // or 1
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
		}

        public override void AI()
        {
			Lighting.AddLight(Projectile.Center, 0.4f, 0.1f, 0.9f);
			Projectile.rotation += 0.4f * (float)Projectile.direction;
			for (int i = 0; i < 4; i++)
            {
				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.ShimmerSplash);
			}

			if (++Projectile.frameCounter >= 5)
			{
				Projectile.frameCounter = 0;
				Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
			}
			Projectile.ai[0]++;
			if (Projectile.ai[0] % 15f == 0 && Projectile.owner == Main.myPlayer)
			{
				for (int i = -1; i <= 1; i += 2)
				{
					Vector2 projVelocity = Projectile.velocity.RotatedBy(PikeMod.degToRad(i * 90));

					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, projVelocity/2, ModContent.ProjectileType<Projectiles.shimmerTomeProjB>(), (int)(Projectile.damage * 0.5), 0f, Projectile.owner, 0f, 0f);
				}
			}
			Projectile.velocity.Y = Projectile.velocity.Y + 0.1f; // 0.1f for arrow gravity, 0.4f for knife gravity
			if (Projectile.velocity.Y > 16f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
			{
				Projectile.velocity.Y = 16f;
			}
		}
        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            base.OnHitNPC(target, hit, damageDone);
			int m = 9;
			SoundEngine.PlaySound(SoundID.NPCHit3,Projectile.Center);
			for (int i = 0; i <= m; i++)
			{
				Vector2 projVelocity = Projectile.velocity.RotatedBy(PikeMod.degToRad((360 * i)/m));

				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, projVelocity, ModContent.ProjectileType<Projectiles.shimmerTomeProjB>(), (int)(Projectile.damage * 0.5), 0f, Projectile.owner, 0f, 0f, 15f);
			}
		}

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
			int m = 3;
			SoundEngine.PlaySound(SoundID.NPCHit3, Projectile.Center);
			for (int i = 0; i <= m; i++)
			{
				Vector2 projVelocity = Projectile.velocity.RotatedBy(PikeMod.degToRad((360 * i) / m));

				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.position, projVelocity, ModContent.ProjectileType<Projectiles.shimmerTomeProjB>(), (int)(Projectile.damage * 0.5), 0f, Projectile.owner, 0f, 0f, 15f);
			}
			return true;
		}
    }
}