using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using PikeMod;

namespace PikeMod.Items
{
	public class EarthSword : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.PikeMod.hjson file.

		public override void SetDefaults()
		{
			Item.damage = 64;
			Item.DamageType = DamageClass.Melee;
			Item.width = 106;
			Item.height = 106;
			Item.useTime = 14;
			Item.useAnimation = 14;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 125000;
			Item.rare = ItemRarityID.Lime;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.useTurn = true;

			Item.shoot = ModContent.ProjectileType<Projectiles.earthSwordProj>();
			Item.shootSpeed = 8f;
		}
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			Vector2 defaultVelocity = velocity;
			// Loop these functions 3 times.
				for (int i = -1; i <= 1; i++)
			{
				if (Main.rand.NextBool(2))
				{
					type = ModContent.ProjectileType<Projectiles.earthSwordProjB>();
					damage += 6;
				}
				velocity = defaultVelocity.RotatedBy(PikeMod.degToRad(i * 4 + Main.rand.NextFloat(-2,2)));
				Projectile.NewProjectile(source, position, velocity, type, damage - 3, knockback / 2, player.whoAmI);
			}
			return false;   
        }

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 25);
			recipe.AddIngredient(ItemID.WaterBucket, 1);
			recipe.AddIngredient(ItemID.GrassSeeds, 5);
			recipe.AddIngredient(ModContent.ItemType<shimmerBar>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				// Emit dusts when the sword is swung
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.GreenFairy);
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.BlueFairy);
			}
		}
	}
}