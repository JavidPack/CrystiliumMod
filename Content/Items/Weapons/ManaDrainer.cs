using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class ManaDrainer : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Mana Drainer");
			// Tooltip.SetDefault("Steals mana");
			Item.staff[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.damage = 18; //The damage
			Item.DamageType = DamageClass.Magic; //Whether or not it is a magic weapon
			Item.width = 54; //Item width
			Item.height = 54; //Item height
			Item.maxStack = 1; //How many of this item you can stack
			Item.useTime = 4; //How long it takes for the item to be used
			Item.useAnimation = 4; //How long the animation of the item takes
			Item.knockBack = 7f; //How much knockback the item produces
			Item.UseSound = SoundID.Item30; //The soundeffect played when used
			Item.noMelee = true; //Whether the weapon should do melee damage or not
			Item.useStyle = 5; //How the weapon is held, 5 is the gun hold style
			Item.value = Item.sellPrice(0, 1, 0, 0);
			Item.rare = 6;
			Item.mana = 20;
			Item.shoot = ModContent.ProjectileType<Projectiles.ManaBeam>();
			Item.shootSpeed = 16f;
			Item.autoReuse = true;
		}
	}
}