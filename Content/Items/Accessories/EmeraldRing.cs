using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Accessories
{
	public class EmeraldRing : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Emerald Ring");
			// Tooltip.SetDefault("5% increased damage");
		}

		public override void SetDefaults()
		{
			Item.width = 40;
			Item.height = 40;
			Item.value = Item.sellPrice(0, 0, 70, 0);
			Item.rare = 1;
			Item.accessory = true;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetDamage(DamageClass.Magic) += .05f;
			player.GetDamage(DamageClass.Melee) += .05f;
			player.GetDamage(DamageClass.Ranged) += .05f;
			player.GetDamage(DamageClass.Summon) += .05f;
			player.GetDamage(DamageClass.Throwing) += .05f;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.GoldBar, 4);
			recipe.AddIngredient(ItemID.Emerald, 3);
			recipe.Register();
		}
	}
}