using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Items.Weapons
{
	public class PrismCast : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Prismatic Catalyst");
			Tooltip.SetDefault("'Clense your soul'");
			Item.staff[item.type] = true; //this makes the useStyle animate as a staff instead of as a gun
		}

		public override void SetDefaults()
		{
			item.damage = 0;
			item.magic = true;
			item.mana = 55;
			item.width = 40;
			item.height = 40;
			item.useTime = 77;
			item.useAnimation = 77;
			item.useStyle = 5;
			item.noMelee = true;
			item.knockBack = 5;
			item.value = 30000;
			item.rare = 3;
			item.healLife = 10;
			item.UseSound = SoundID.Item20;
			item.autoReuse = true;
		}
	}
}