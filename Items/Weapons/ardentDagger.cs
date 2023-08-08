using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ReLogic.Content;
using System;
using System.Drawing.Printing;
using System.Reflection.Metadata;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace PikeMod.Items.Weapons
{
	public class ardentDagger : ModItem
	{
        public override void SetDefaults()
        {
            Item.damage = 20;
            Item.DamageType = DamageClass.Melee;
            Item.width = 32;
            Item.height = 32;
            Item.useTime = 80;
            Item.useAnimation = 20;
            Item.useStyle = ItemUseStyleID.Swing;
            Item.knockBack = 4;
            Item.value = 100000;
            Item.rare = ItemRarityID.Green;
            Item.UseSound = SoundID.Item1;
            Item.autoReuse = true;
            Item.useTurn = true;
            Item.shoot = ModContent.ProjectileType<Projectiles.ardentProj>();
            Item.shootSpeed = 2;
        }

        //item in world glow draw thingie
        public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
        {
            Texture2D texture = ModContent.Request<Texture2D>("PikeMod/Items/Weapons/ardentDagger", AssetRequestMode.ImmediateLoad).Value;
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

        //when shooting the shit
        public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
        {
            
            Vector2 newvelocity = velocity * Main.rand.NextFloat(0, 1);
            Vector2 newposition = Main.MouseWorld;
            Projectile.NewProjectile(source, newposition, newvelocity, type, (int)(damage * 0.5), knockback / 2, player.whoAmI);
            return false;
        }   //spawn projectile at cursor

        //when holding the shit
        public override void HoldItem(Player player)
        {
            if (player.itemTime == 1)
            {
                PikeMod.EmitMaxManaEffect(player);
            }  //do the bleep when item use run out
        }

        //when the shit in the world as item
        public override void PostUpdate()
        {
            Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale);
        }   //make the item glow oooo

        //when shit is swung
        public override void MeleeEffects(Player player, Rectangle hitbox)
        {
            Lighting.AddLight(player.Center, Color.WhiteSmoke.ToVector3() * 1f * Main.essScale);
            //make light

            if (Main.rand.NextBool(3))
            {
            Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, DustID.MagicMirror);
            }   //make dust at random
        }

        //shit recipes
        public override void AddRecipes()
		{
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Glass, 5);
            recipe.AddIngredient(ItemID.CrimtaneBar, 12);      //one for crimson enjoyers
			recipe.AddIngredient(ModContent.ItemType<Materials.shimmerBar>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();

            recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.Glass, 5);
            recipe.AddIngredient(ItemID.DemoniteBar, 12);       //one for corruption enjoyers
            recipe.AddIngredient(ModContent.ItemType<Materials.shimmerBar>(), 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
        }
    }
}