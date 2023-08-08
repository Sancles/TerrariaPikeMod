using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using PikeMod;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;

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

        //item in world glow draw thingie
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("PikeMod/Items/Weapons/shimmerTomeGlow", AssetRequestMode.ImmediateLoad).Value;
            spriteBatch.Draw
            (
                texture,
                new Vector2
                (
                    Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
                    Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f + 2f
                ),
                new Rectangle(0, 0, texture.Width, texture.Height),
                Color.White,
                rotation,
                texture.Size() * 0.5f,
                scale,
                SpriteEffects.None,
                0f
            );  //all of this stuff just handles the glow mask
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