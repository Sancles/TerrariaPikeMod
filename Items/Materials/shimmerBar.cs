using Terraria;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;

namespace PikeMod.Items.Materials
{
    public class shimmerBar : ModItem
    {
		public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 25;                        //how many needed to research, bars need 25
        }

        public override void SetDefaults()
        {
            Item.DefaultToPlaceableTile(ModContent.TileType<Tiles.shimmerBarPlaced>());
            Item.width = 30;
            Item.height = 24;
            Item.maxStack = 9999;
            Item.value = Item.buyPrice(silver: 45);
            Item.rare = ItemRarityID.Orange;
        }
    }
}