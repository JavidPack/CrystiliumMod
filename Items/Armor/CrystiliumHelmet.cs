using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Armor
{
	public class CrystiliumHelmet : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Crystilium Helmet";
			item.width = 18;
			item.height = 18;
			item.toolTip = "9% increased magic damage";
			item.toolTip2 = "+60 mana";
			item.value = 150000;
			item.rare = 8;
			item.defense = 14;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage *= 1.09f;
			player.statManaMax2 += 60;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType<CrystalBreastplate>() && legs.type == mod.ItemType<CrystalLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Consecutive hits give you more damage";
			player.GetModPlayer<CrystalPlayer>(mod).crystalCharm = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Items.CrystiliumBar>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}