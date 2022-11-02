using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Legs)]
	public class CrystiliumGreaves : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystilium Greaves");
			// Tooltip.SetDefault("+9% magic crit chance");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 100000;
			Item.rare = 8;
			Item.defense = 12;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetCritChance(DamageClass.Magic) += 9;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.CrystiliumBar>(), 12);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}