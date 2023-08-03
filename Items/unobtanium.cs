using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace PikeMod.Items
{
    public class unobtanium : ModItem
    {

        public override void SetDefaults()
        {
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 999;
            Item.value = Item.buyPrice(platinum: 999);
            Item.rare = ItemRarityID.Orange;
        }
    }
}