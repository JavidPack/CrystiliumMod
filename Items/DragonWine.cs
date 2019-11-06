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
			item.UseSound = SoundID.Item3;
			item.useStyle = 2;
			item.useTurn = true;
			item.useAnimation = 20;
			item.useTime = 20;
			item.maxStack = 30;
			item.consumable = true;
			item.value = 3500;
			item.rare = 0;
			item.buffTime = 600;
			return;
		}

		public override bool UseItem(Player player)
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
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemType<CrystalBottleWater>());
			recipe.AddIngredient(ItemID.TissueSample);
			recipe.AddIngredient(ItemID.Deathweed);
			recipe.AddIngredient(ItemID.Ichor);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}