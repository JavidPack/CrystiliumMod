using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Armor
{
	public class CrystalBreastplate : ModItem
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
			item.name = "Crystal Breastplate";
			item.width = 18;
			item.height = 18;
			item.toolTip = "10% increased magic and summon damage";
			item.toolTip2 = "Increases maximum minions";
			item.value = 20000;
			item.rare = 3;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage *= 1.10f;
			player.minionDamage *= 1.10f;
			player.maxMinions += 1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Items.RadiantPrism>(), 15);
			recipe.AddIngredient(mod.ItemType<Items.ShinyGemstone>(), 25);
			recipe.AddTile(Terraria.ID.TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}