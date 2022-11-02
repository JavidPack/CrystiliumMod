using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CrystiliumMod.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Head)]
	public class HardCrystalHelm : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Hard Crystal Helm");
			// Tooltip.SetDefault("6% increased magic and summon damage"
			// 	+ "\nIncreases maximum minions");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 40000;
			Item.rare = 5;
			Item.defense = 7;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) *= 1.06f;
			player.GetDamage(DamageClass.Summon) *= 1.06f;
			player.maxMinions += 1;
		}

		public override bool IsArmorSet(Item head, Item body, Item legs)
		{
			return body.type == ModContent.ItemType<HardCrystalBreastplate>() && legs.type == ModContent.ItemType<HardCrystalLeggings>();
		}

		public override void UpdateArmorSet(Player player)
		{
			player.setBonus = Language.GetTextValue("ArmorSetBonus.HardCrystalSet");
			// player.setBonus = "10% magic and summon damage";
			player.GetDamage(DamageClass.Magic) *= 1.10f;
			player.GetDamage(DamageClass.Summon) *= 1.10f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.CrystalShard, 15);
			recipe.AddIngredient(ModContent.ItemType<Items.EnchantedGeode>(), 12);
			recipe.AddTile(Terraria.ID.TileID.Anvils);
			recipe.Register();
		}
	}
}