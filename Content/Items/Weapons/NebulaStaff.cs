using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class NebulaStaff : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Nebula Crystal Staff");
			Tooltip.SetDefault("'You feel the power of the cosmos'");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 88; //The damage
			Item.DamageType = DamageClass.Magic; //Whether or not it is a magic weapon
			Item.width = 54; //Item width
			Item.height = 54; //Item height
			Item.maxStack = 1; //How many of this item you can stack
			Item.useTime = 25; //How long it takes for the item to be used
			Item.useAnimation = 25; //How long the animation of the item takes
			Item.knockBack = 7f; //How much knockback the item produces
			Item.noMelee = true; //Whether the weapon should do melee damage or not
			Item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			Item.value = 120000; //How much the item is worth
			Item.rare = 8; //The rarity of the item
			Item.shoot = ModContent.ProjectileType<Projectiles.NebulaShard>(); //What the item shoots, retains an int value
			Item.shootSpeed = 4f; //How fast the projectile fires
			Item.mana = 14;
			Item.channel = true;
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.FragmentNebula, 10);
			recipe.AddIngredient(ModContent.ItemType<CrystiliumBar>(), 15);
			recipe.AddTile(TileID.LunarCraftingStation);
			recipe.Register();
		}
	}
}