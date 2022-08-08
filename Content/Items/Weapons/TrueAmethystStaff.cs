using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class TrueAmethystStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("True Amethyst Staff");
			Tooltip.SetDefault("'Aura of Destruction'");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 62; //The damage
			Item.DamageType = DamageClass.Magic; //Whether or not it is a magic weapon
			Item.width = 54; //Item width
			Item.height = 54; //Item height
			Item.maxStack = 1; //How many of this item you can stack
			Item.useTime = 3; //How long it takes for the item to be used
			Item.useAnimation = 3; //How long the animation of the item takes
			Item.knockBack = 4f; //How much knockback the item produces
			Item.noMelee = true; //Whether the weapon should do melee damage or not
			Item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			Item.value = 120000; //How much the item is worth
			Item.rare = 8; //The rarity of the item
			Item.shoot = ModContent.ProjectileType<Projectiles.TrueAmethystProjectile>(); //What the item shoots, retains an int value
			Item.shootSpeed = 1f; //How fast the projectile fires
			Item.mana = 3;
			Item.autoReuse = true; //Whether it automatically uses the item again after it's done being used/animated
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ModContent.ItemType<Items.CrystiliumBar>(), 15);
			recipe.AddIngredient(ModContent.ItemType<Items.Weapons.EnchantedAmethystStaff>());
			recipe.AddIngredient(ModContent.ItemType<Items.BrokenStaff>());
			recipe.AddTile(TileID.MythrilAnvil);
			recipe.Register();
		}

        public override void ModifyShootStats(Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
			Vector2 playerPos = player.Center; //position of player
			int maxPixelDist = 200; //max distance projectiles can spawn from player
			int minPixelDist = 80; //min distance projectiles can spawn from player
			Vector2 transVector = new Vector2(Main.rand.Next(minPixelDist, maxPixelDist), 0f).RotatedByRandom(2 * Math.PI);
			position = position + transVector; //move projectile position accordingly
			velocity = Vector2.Zero;
		}
	}
}