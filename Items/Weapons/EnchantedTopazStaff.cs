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
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 15; //The damage
			Item.DamageType = DamageClass.Magic; //Whether or not it is a magic weapon
			Item.width = 54; //Item width
			Item.height = 54; //Item height
			Item.maxStack = 1; //How many of this item you can stack
			Item.useTime = 30; //How long it takes for the item to be used
			Item.useAnimation = 30; //How long the animation of the item takes
			Item.knockBack = 7f; //How much knockback the item produces
			Item.UseSound = SoundID.Item30; //The soundeffect played when used
			Item.noMelee = true; //Whether the weapon should do melee damage or not
			Item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			Item.value = 30000;
			Item.rare = 3;
			Item.shoot = ProjectileType<BouncyTopaz>(); //What the item shoots, retains an int value | *
			Item.shootSpeed = 6f; //How fast the projectile fires
			Item.mana = 20;
			Item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.TopazStaff);
			recipe.AddIngredient(ItemID.Topaz, 15);
			recipe.AddIngredient(ItemType<ShinyGemstone>(), 10);
			recipe.AddTile(TileID.Anvils);
			recipe.Register();
		}
	}
}