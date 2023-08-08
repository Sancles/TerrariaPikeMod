using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PikeMod.Items.Weapons
{
	public class meteorMallet : ModItem
	{
		public override void SetDefaults()
		{
			Item.damage = 12;
			Item.DamageType = DamageClass.Melee;
			Item.width = 48;
			Item.height = 48;
			Item.useTime = 15;
			Item.useAnimation = 15;
			Item.noUseGraphic = true;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 4;
			Item.value = 100000;
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.meteorMalletProj>();
			Item.shootSpeed = 16f;
			Item.useTurn = true;
		}

        public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.MeteoriteBar, 10);
			recipe.AddIngredient(ModContent.ItemType<Materials.shimmerBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

        }
    }
}