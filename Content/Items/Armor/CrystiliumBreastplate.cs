using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Armor
{
	[AutoloadEquip(EquipType.Body)]
	public class CrystiliumBreastplate : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Crystilium Breastplate");
			// Tooltip.SetDefault("12% increased magic damage");
		}

		public override void SetDefaults()
		{
			Item.width = 18;
			Item.height = 18;
			Item.value = 200000;
			Item.rare = 8;
			Item.defense = 15;
		}

		public override void UpdateEquip(Player player)
		{
			player.GetDamage(DamageClass.Magic) *= 1.12f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.CrystiliumBar>(), 20);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}
	}
}