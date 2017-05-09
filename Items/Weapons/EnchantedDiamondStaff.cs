using CrystiliumMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class EnchantedDiamondStaff : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Enchanted Diamond Staff";
			item.damage = 13; //The damage
			item.magic = true; //Whether or not it is a magic weapon
			item.width = 54; //Item width
			item.height = 54; //Item height
			item.maxStack = 1; //How many of this item you can stack
			item.toolTip = "'Zap!'"; //The item’s tooltip
			item.useTime = 75; //How long it takes for the item to be used
			item.useAnimation = 75; //How long the animation of the item takes
			Item.staff[item.type] = true;
			item.knockBack = 7f; //How much knockback the item produces
			item.UseSound = SoundID.Item30; //The soundeffect played when used
			item.noMelee = true; //Whether the weapon should do melee damage or not
			item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			item.value = 30000;
			item.rare = 3;
			item.shoot = mod.ProjectileType<GiantDiamond>(); //What the item shoots, retains an int value | *
			item.shootSpeed = 6f; //How fast the projectile fires
			item.mana = 20;
			item.autoReuse = true; //Whether it automatically uses the item again after its done being used/animated
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.DiamondStaff, 1);
			recipe.AddIngredient(ItemID.Diamond, 15);
			recipe.AddIngredient(null, "ShinyGemstone", 15);
			recipe.AddTile(16);
			recipe.SetResult(this, 1);
			recipe.AddRecipe();
		}
	}
}