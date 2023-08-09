using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace PikeMod.Projectiles
{
    public class goldfishProj : ModProjectile
	{
        public override string Texture => $"Terraria/Images/Item_{ItemID.Goldfish}";
		public override void SetDefaults()
		{
            Projectile.CloneDefaults(ProjectileID.WoodenArrowFriendly);
            Projectile.width = 20;
            Projectile.height = 20;
            DrawOffsetX = -4;
            AIType = ProjectileID.WoodenArrowFriendly;
        }

        public override void AI()
        {
            Projectile.spriteDirection = (Projectile.velocity.X < 0).ToDirectionInt();
            Projectile.rotation = Projectile.velocity.ToRotation() - MathHelper.Pi - (Projectile.spriteDirection == 1 ? 0f : MathHelper.Pi);
        }

        public override void Kill(int timeLeft)
        {
            IEntitySource source = Projectile.GetSource_FromThis();
            Terraria.Audio.SoundEngine.PlaySound(SoundID.NPCDeath1, Projectile.position);

            Gore.NewGore(source, Projectile.position, Projectile.velocity, 553);
            Gore.NewGore(source, Projectile.position, Projectile.velocity, 554);
        }
    }
}