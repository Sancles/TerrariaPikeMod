using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PikeMod.Items.Materials
{
    public class shimmerMass : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 30;
            Item.maxStack = 99;
            Item.value = 15;
            Item.rare = ItemRarityID.Orange;
        }
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Materials.unobtanium>(), 15);
            recipe.AddCustomShimmerResult(ModContent.ItemType<Materials.shimmerBar>(),4);
            recipe.Register();
        }
    }
}