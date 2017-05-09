using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Armor
{
	public class HardCrystalBreastplate : ModItem
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
			item.name = "Hard Crystal Breastplate";
			item.width = 18;
			item.height = 18;
			item.toolTip = "8% increased magic and summon damage";
			item.toolTip2 = "Increases maximum minions";
			item.value = 50000;
			item.rare = 5;
			item.defense = 8;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage *= 1.08f;
			player.minionDamage *= 1.08f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalShard, 20);
			recipe.AddIngredient(mod.ItemType<Items.EnchantedGeode>(), 15);
			recipe.AddTile(Terraria.ID.TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}