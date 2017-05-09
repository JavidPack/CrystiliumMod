using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CrystiliumMod.Items.Weapons
{
	public class NebulaStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Nebula Crystal Staff";
			item.damage = 88; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 54; //Item width
			item.height = 54; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.toolTip = "'You feel the power of the cosmos'"; //The item tooltip
			item.useTime = 25; //How long it takes for the item to be used
			item.useAnimation = 25; //How long the animation of the item takes
			Item.staff[item.type] = true;
			item.knockBack = 7f; //How much knockback the item produces
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 120000; //How much the item is worth
			item.rare = 8; //The rarity of the item
			item.shoot = mod.ProjectileType<Projectiles.NebulaShard>(); //What the item shoots, retains an int value
			item.shootSpeed = 4f; //How fast the projectile fires   
			item.mana = 14;
			item.channel = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddIngredient(mod, "CrystiliumBar", 15);
			recipe.AddTile(412);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}