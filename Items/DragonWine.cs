using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items
{
	public class DragonWine : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dragon Potion");
			Tooltip.SetDefault("Quadruples your damage for 10 seconds, but you lose 200 hp on use");
		}

		public override void SetDefaults()
		{
			Item.UseSound = SoundID.Item3;
			Item.useStyle = 2;
			Item.useTurn = true;
			Item.useAnimation = 20;
			Item.useTime = 20;
			Item.maxStack = 30;
			Item.consumable = true;
			Item.value = 3500;
			Item.rare = 0;
			Item.buffTime = 600;
			return;
		}

		public override bool? UseItem(Player player)/* tModPorter Suggestion: Return null instead of false */
		{
			player.statLife -= 200;
			player.AddBuff(BuffType<Buffs.DragonFury>(), 600);
			if (player.statLife <= 0)
			{
				//Main.player[item.owner].KillMe(9999, 1, true, " couldn't take the heat"/*" sacrificed too much"*/);
			}
			return true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemType<CrystalBottleWater>());
			recipe.AddIngredient(ItemID.TissueSample);
			recipe.AddIngredient(ItemID.Deathweed);
			recipe.AddIngredient(ItemID.Ichor);
			recipe.AddTile(TileID.Bottles);
			recipe.Register();
		}
	}
}