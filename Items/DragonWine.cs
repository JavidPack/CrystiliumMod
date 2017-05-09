using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using System;
using System.Collections.Generic;


namespace CrystiliumMod.Items
{
	public class DragonWine : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Dragon Potion";
			item.UseSound = SoundID.Item3;
			item.useStyle = 2;
			item.useTurn = true;
			item.useAnimation = 20;
			item.useTime = 20;
			item.maxStack = 30;
			item.consumable = true;
			item.toolTip = "Quadruples your damage for 10 seconds, but you lose 200 hp on use";
			item.value = 3500;
			item.rare = 0;
			item.buffTime = 600;
			return;
		}
		public override bool UseItem(Player player)
		{
			player.statLife -= 200;
			player.AddBuff(mod.BuffType<Buffs.DragonFury>(), 600);
			if (player.statLife <= 0)
			{
				//Main.player[item.owner].KillMe(9999, 1, true, " couldn't take the heat"/*" sacrificed too much"*/);
			}
			return true;
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<CrystalBottleWater>(), 1);
			recipe.AddIngredient(ItemID.TissueSample, 1);
			recipe.AddIngredient(ItemID.Deathweed, 1);
			recipe.AddIngredient(ItemID.Ichor, 1);
			recipe.AddTile(TileID.Bottles);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}