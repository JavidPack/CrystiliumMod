using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Armor
{
	public class HardCrystalHelm : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Hard Crystal Helm";
			item.width = 18;
			item.height = 18;
			item.toolTip = "6% increased magic and summon damage";
			item.toolTip2 = "Increases maximum minions";
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
			return body.type == mod.ItemType<HardCrystalBreastplate>() && legs.type == mod.ItemType<HardCrystalLeggings>();
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
			recipe.AddIngredient(mod.ItemType<Items.EnchantedGeode>(), 12);
			recipe.AddTile(Terraria.ID.TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}