using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class HardCrystalBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hard Crystal Breastplate");
			Tooltip.SetDefault("8% increased magic and summon damage"
				+ "\nIncreases maximum minions");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
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