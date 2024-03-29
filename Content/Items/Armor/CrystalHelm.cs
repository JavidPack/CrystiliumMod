using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CrystiliumMod.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CrystalHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystal Helm");
			// Tooltip.SetDefault("8% increased magic and summon damage"
			// 	+ "\nIncreases maximum minions");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 15000;
			Item.rare = 3;
			Item.defense = 3;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) *= 1.08f;
			player.GetDamage(DamageClass.Summon) *= 1.08f;
			player.maxMinions += 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<CrystalBreastplate>() && legs.type == ModContent.ItemType<CrystalLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.CrystalSet");
			// player.setBonus = "Walking leaves behind damaging crystals";
			if (player.moveSpeed != 0)
			{
				player.AddBuff(ModContent.BuffType<Buffs.CrystalLeak>(), 2);
			}
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.RadiantPrism>(), 10);
			recipe.AddIngredient(ModContent.ItemType<Items.ShinyGemstone>(), 15);
			recipe.AddTile(Terraria.ID.TileID.Anvils);
			recipe.Register();
		}
	}
}