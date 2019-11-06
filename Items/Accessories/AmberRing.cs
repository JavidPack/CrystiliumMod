using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Accessories
{
	public class AmberRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Amber Ring");
			Tooltip.SetDefault("Slightly increases life regen");
		}

		public override void SetDefaults()
		{
			item.width = 40;
			item.height = 40;
			item.value = Item.sellPrice(0, 1, 0, 0);
			item.rare = 2;
			item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.lifeRegen += 6;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FossilOre, 4);
			recipe.AddIngredient(ItemID.Amber, 3);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}