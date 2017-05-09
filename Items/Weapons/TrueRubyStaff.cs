using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	class TrueRubyStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "True Ruby Staff";
			item.damage = 30; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 54; //Item width
			item.height = 54; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.toolTip = "Shoots homing fireballs of doom"; //The item’s tooltip
			item.useTime = 5; //How long it takes for the item to be used
			item.useAnimation = 5; //How long the animation of the item takes
			Item.staff[item.type] = true;
			item.knockBack = 1f; //How much knockback the item produces
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 120000; //How much the item is worth
			item.rare = 8; //The rarity of the item
			item.shoot = mod.ProjectileType<Projectiles.TrueRubyProjectile>(); //What the item shoots, retains an int value | *
			item.shootSpeed = 7f; //How fast the projectile fires   
			item.mana = 2;
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(mod.ItemType<Items.CrystiliumBar>(), 15);
			recipe.AddIngredient(mod.ItemType<Items.Weapons.EnchantedRubyStaff>(), 1);
			recipe.AddIngredient(mod.ItemType<Items.BrokenStaff>(), 1);
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}
