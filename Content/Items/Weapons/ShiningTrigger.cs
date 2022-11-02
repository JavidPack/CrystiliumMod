using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Content.Items.Weapons
{
	public class ShiningTrigger : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Shining Trigger");
			// Tooltip.SetDefault("High damage, low velocity");
		}

		public override void SetDefaults()
		{
			Item.damage = 251;
			Item.DamageType = DamageClass.Ranged;
			Item.width = 40;
			Item.height = 20;
			Item.useTime = 65;
			Item.useAnimation = 65;
			Item.useStyle = 5;
			Item.noMelee = true; //so the item's animation doesn't do damage
			Item.knockBack = 4;
			Item.value = 100000;
			Item.rare = 7;
			Item.UseSound = SoundID.Item11;
			Item.autoReuse = true;
			Item.shoot = 10; //idk why but all the guns in the vanilla source have this
			Item.shootSpeed = 0.01f;
			Item.useAmmo = AmmoID.Bullet;
		}
	}
}