using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Armor
{
    public class CrystiliumBreastplate : ModItem
    {
        public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
        {
            equips.Add(EquipType.Body);
            return true;
        }

        public override void DrawHands(ref bool drawHands, ref bool drawArms)
        {
            base.DrawHands(ref drawHands, ref drawArms);
        }

        public override void SetDefaults()
        {
            item.name = "Crystilium Breastplate";
            item.width = 18;
            item.height = 18;
            item.toolTip = "12% increased magic damage";
            item.value = 200000;
            item.rare = 8;
            item.defense = 15;
        }

        public override void UpdateEquip(Player player)
        {
            player.magicDamage *= 1.12f;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("CrystiliumBar"), 20);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
        }
    }
}