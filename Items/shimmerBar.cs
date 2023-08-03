using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PikeMod.Items
{
    public class shimmerBar : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(silver: 45);
            Item.rare = ItemRarityID.Orange;
        }
    }
}