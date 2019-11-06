using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CrystiliumHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crystilium Helmet");
			Tooltip.SetDefault("9% increased magic damage"
				+ "\n+60 mana");
		}

		public override void SetDefaults()
		{
			item.width = 18;
			item.height = 18;
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
			return body.type == ItemType<CrystalBreastplate>() && legs.type == ItemType<CrystalLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = "Consecutive hits give you more damage";
			player.GetModPlayer<CrystalPlayer>().crystalCharm = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<Items.CrystiliumBar>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}