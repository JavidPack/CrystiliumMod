using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CrystiliumMod.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class CrystiliumHelmet : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystilium Helmet");
			// Tooltip.SetDefault("9% increased magic damage"
			// 	+ "\n+60 mana");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 150000;
			Item.rare = 8;
			Item.defense = 14;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) *= 1.09f;
			player.statManaMax2 += 60;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<CrystalBreastplate>() && legs.type == ModContent.ItemType<CrystalLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.CrystiliumSet");
			// player.setBonus = "Consecutive hits give you more damage";
			player.GetModPlayer<CrystalPlayer>().crystalCharm = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.CrystiliumBar>(), 15);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}