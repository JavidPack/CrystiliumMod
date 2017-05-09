using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class ShiningTrigger : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Shining Trigger";
			item.damage = 251;
			item.ranged = true;
			item.width = 40;
			item.height = 20;
			item.toolTip = "High damage, low velocity";
			item.useTime = 65;
			item.useAnimation = 65;
			item.useStyle = 5;
			item.noMelee = true; //so the item's animation doesn't do damage
			item.knockBack = 4;
            item.value = 100000;
            item.rare = 7;
            item.UseSound = SoundID.Item11;
			item.autoReuse = true;
			item.shoot = 10; //idk why but all the guns in the vanilla source have this
			item.shootSpeed = 0.01f;
            item.useAmmo = AmmoID.Bullet;
        }
	}
}