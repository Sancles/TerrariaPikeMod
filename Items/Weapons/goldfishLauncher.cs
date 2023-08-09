using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using PikeMod;
using Microsoft.Xna.Framework.Graphics;
using ReLogic.Content;
using PikeMod.Items.Materials;

namespace PikeMod.Items.Weapons
{
	public class goldfishLauncher : ModItem
	{
        public override void SetDefaults()
        {
            Item.width = 42; // The width of item hitbox
            Item.height = 30; // The height of item hitbox

            Item.autoReuse = false;
            Item.damage = 40;
            Item.DamageType = DamageClass.Ranged;
            Item.knockBack = 5;
            Item.noMelee = true;
            Item.rare = ItemRarityID.Green;
            Item.shootSpeed = 10;
            Item.useAnimation = 35;
            Item.useTime = 35;
            Item.UseSound = SoundID.Item11;
            Item.useStyle = ItemUseStyleID.Shoot;
            Item.shoot = ModContent.ProjectileType<Projectiles.goldfishProj>();
            Item.useAmmo = ItemID.Goldfish;
        }
        public class ModifyDefaults : GlobalItem
        {
            public override void SetDefaults(Item item)
            {
                if (item.type == ItemID.Goldfish)
                {
                    item.ammo = ItemID.Goldfish;
                }
                if (item.type == ItemID.GoldGoldfish)
                {
                    item.ammo = ItemID.Goldfish;
                }
            }
        }

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            Vector2 muzzleOffset = Vector2.Normalize(velocity) * 25f;

            if (Collision.CanHit(position, 0, 0, position + muzzleOffset, 0, 0))
            {
                position += muzzleOffset;
            }
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.IllegalGunParts);
            recipe.AddIngredient(ItemID.CopperBar, 10);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}