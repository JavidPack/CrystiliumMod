using Terraria;
using System;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class EnchantedRubyStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Enchanted Ruby Staff";
			item.damage = 19; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 54; //Item width
			item.height = 54; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.toolTip = "'Feel the fire'"; //The item’s tooltip
			item.useTime = 45; //How long it takes for the item to be used
			item.useAnimation = 45; //How long the animation of the item takes
			Item.staff[item.type] = true;
			item.knockBack = 7f; //How much knockback the item produces
			item.UseSound = SoundID.Item30; //The soundeffect played when used
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 30000;
			item.rare = 3;
			item.shoot = mod.ProjectileType<Projectiles.FireGem>(); //What the item shoots, retains an int value | *
			item.shootSpeed = 2f; //How fast the projectile fires   
			item.mana = 20;
			item.autoReuse = false; //Whether it automatically uses the item again after its done being used/animated
		}
		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.RubyStaff, 1);
			recipe.AddIngredient(ItemID.Ruby, 15);
			recipe.AddIngredient(null, "ShinyGemstone", 10);
			recipe.AddTile(16);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			//float SdirX = (Main.MouseWorld.X - player.position.X) * 8.5f;
			//float SdirY = (Main.MouseWorld.Y - player.position.Y) * 8.5f;
			//float angle = (float)Math.Atan(12f);
			Projectile.NewProjectile(position.X - player.width / 2, position.Y - player.height / 2, speedX, speedY, mod.ProjectileType<Projectiles.FireGem>(), damage, knockBack, player.whoAmI, 0f, 0f);
			return false;
		}
	}
}