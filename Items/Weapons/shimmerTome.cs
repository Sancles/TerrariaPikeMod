using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using PikeMod;

namespace PikeMod.Items.Weapons
{
	public class shimmerTome : ModItem
	{

		public override void SetDefaults()
		{
			Item.damage = 54;
			Item.DamageType = DamageClass.Magic;
			Item.width = 32;
			Item.height = 34;
			Item.useTime = 34;
			Item.useAnimation = 34;
			Item.useStyle = ItemUseStyleID.Shoot;
			Item.knockBack = 8;
			Item.value = 125000;
			Item.rare = ItemRarityID.Pink;
			Item.UseSound = SoundID.Item8;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<Projectiles.shimmerTomeProj>();
			Item.shootSpeed = 16f;
			Item.mana = 12;
		}

        public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.SpellTome, 1);
			recipe.AddIngredient(ModContent.ItemType<Materials.shimmerBar>(), 20);
			recipe.AddIngredient(ItemID.SoulofLight, 8);
			recipe.AddIngredient(ItemID.SoulofNight, 8);
			recipe.AddTile(TileID.Bookcases);
			recipe.Register();
		}
	}
}