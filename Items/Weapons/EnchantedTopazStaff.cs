using CrystiliumMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;

namespace CrystiliumMod.Items.Weapons
{
	public class EnchantedTopazStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Enchanted Topaz Staff");
			Tooltip.SetDefault("'Bouncy gems are the best'");
			Item.staff[item.type] = true;
		}

		public override void SetDefaults()
		{
			item.damage = 15; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 54; //Item width
			item.height = 54; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.useTime = 30; //How long it takes for the item to be used
			item.useAnimation = 30; //How long the animation of the item takes
			item.knockBack = 7f; //How much knockback the item produces
			item.UseSound = SoundID.Item30; //The soundeffect played when used
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 30000;
			item.rare = 3;
			item.shoot = ProjectileType<BouncyTopaz>(); //What the item shoots, retains an int value | *
			item.shootSpeed = 6f; //How fast the projectile fires
			item.mana = 20;
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TopazStaff);
			recipe.AddIngredient(ItemID.Topaz, 15);
			recipe.AddIngredient(ItemType<ShinyGemstone>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}