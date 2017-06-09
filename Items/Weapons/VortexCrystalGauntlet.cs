using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class VortexCrystalGauntlet : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Vortex Crystal Gauntlet");
			Tooltip.SetDefault("'A shiny swirl consumes your arm'");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 110; //The damage
			item.ranged = true;
			item.width = 60; //Item width
			item.height = 60; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.useTime = 50; //How long it takes for the item to be used
			item.useAnimation = 50; //How long the animation of the item takes
			item.knockBack = 7f; //How much knockback the item produces
			item.UseSound = SoundID.Item30; //The soundeffect played when used
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 30000;
			item.rare = 3;
			item.shoot = mod.ProjectileType<Projectiles.VortexPortal>(); //What the item shoots, retains an int value | *
			item.shootSpeed = 0f; //How fast the projectile fires
			item.autoReuse = false; //Whether it automatically uses the item again after its done being used/animated
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FragmentVortex, 10);
			recipe.AddIngredient(mod.ItemType<CrystiliumBar>(), 15);
			recipe.AddIngredient(mod.ItemType<CrystiliumBar>(), 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack) //This lets you modify the firing of the item
		{
			Vector2 value18 = Main.screenPosition + new Vector2((float)Main.mouseX, (float)Main.mouseY);
			position = value18;
			return true;
		}
	}
}