using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class HardCrystalHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Hard Crystal Helm");
			Tooltip.SetDefault("6% increased magic and summon damage"
				+ "\nIncreases maximum minions");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
			item.value = 40000;
			item.rare = 5;
			item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage *= 1.06f;
			player.minionDamage *= 1.06f;
			player.maxMinions += 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ItemType<HardCrystalBreastplate>() && legs.type == ItemType<HardCrystalLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "10% mangic and summon damage";
			player.magicDamage *= 1.10f;
			player.minionDamage *= 1.10f;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.CrystalShard, 15);
			recipe.AddIngredient(ItemType<Items.EnchantedGeode>(), 12);
			recipe.AddTile(Terraria.ID.TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}