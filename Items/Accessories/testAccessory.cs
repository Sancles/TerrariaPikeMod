using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace PikeMod.Items.Accessories
{
    public class testAccessory : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 26;
            Item.height = 30;
            Item.maxStack = 1;
            Item.value = Item.buyPrice(gold: 4, silver: 50);
            Item.rare = ItemRarityID.Orange;
            Item.accessory = true;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            int defenseLoss = player.statDefense / 3;
            player.statDefense = player.statDefense - defenseLoss;
            player.GetArmorPenetration(DamageClass.Generic) += defenseLoss * 1.2f;
        }
    }
}