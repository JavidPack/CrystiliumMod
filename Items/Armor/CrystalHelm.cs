using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Armor
{
	public class CrystalHelm : ModItem
	{
		public override bool Autoload(ref string name, ref string texture, IList<EquipType> equips)
		{
			equips.Add(EquipType.Head);
			return true;
		}

		public override void SetDefaults()
		{
			item.name = "Crystal Helm";
			item.width = 18;
			item.height = 18;
			item.toolTip = "8% increased magic and summon damage";
			item.toolTip2 = "Increases maximum minions";
			item.value = 15000;
			item.rare = 3;
			item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.magicDamage *= 1.08f;
			player.minionDamage *= 1.08f;
			player.maxMinions += 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == mod.ItemType<CrystalBreastplate>() && legs.type == mod.ItemType<CrystalLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Walking leaves behind damaging crystals";
			if (player.moveSpeed != 0)
			{
				player.AddBuff(mod.BuffType<Buffs.CrystalLeak>(), 2);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Items.RadiantPrism>(), 10);
			recipe.AddIngredient(mod.ItemType<Items.ShinyGemstone>(), 15);
			recipe.AddTile(Terraria.ID.TileID.Anvils);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}