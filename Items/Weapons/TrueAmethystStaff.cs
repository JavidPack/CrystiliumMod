using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrystiliumMod.Items.Weapons
{
	public class TrueAmethystStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "True Amethyst Staff";
			item.damage = 62; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 54; //Item width
			item.height = 54; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.toolTip = "'Aura of Destruction'"; //The item tooltip
			item.useTime = 3; //How long it takes for the item to be used
			item.useAnimation = 3; //How long the animation of the item takes
			Item.staff[item.type] = true;
			item.knockBack = 4f; //How much knockback the item produces
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 120000; //How much the item is worth
			item.rare = 8; //The rarity of the item
			item.shoot = mod.ProjectileType<Projectiles.TrueAmethystProjectile>(); //What the item shoots, retains an int value
			item.shootSpeed = 1f; //How fast the projectile fires   
			item.mana = 3;
			item.autoReuse = true; //Whether it automatically uses the item again after it's done being used/animated
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Items.CrystiliumBar>(), 15);
			recipe.AddIngredient(mod.ItemType<Items.Weapons.EnchantedAmethystStaff>(), 1);
			recipe.AddIngredient(mod.ItemType<Items.BrokenStaff>(), 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			Vector2 playerPos = player.Center; //position of player
			int maxPixelDist = 200; //max distance projectiles can spawn from player
			int minPixelDist = 80; //min distance projectiles can spawn from player
			Vector2 transVector = new Vector2(Main.rand.Next(minPixelDist, maxPixelDist), 0f).RotatedByRandom(2 * Math.PI);
			position = position + transVector; //move projectile position accordingly
			speedX = 0; speedY = 0;
			return true;
		}
	}
}