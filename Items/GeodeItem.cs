using Terraria.ID;
using Terraria;
using Terraria.ModLoader;

namespace CrystiliumMod.Items
{
	public class GeodeItem : ModItem
	{
		public override void SetDefaults()
		{
			item.name = "Geode";
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			AddTooltip("'I wonder what's inside!'");
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 4000;
			item.rare = 1;
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
		}

		public override void ExtractinatorUse(ref int resultType, ref int resultStack)
		{
			int GemType = Main.rand.Next(7);
			if (GemType == 0)
			{
				resultType = ItemID.Sapphire;
				resultStack = Main.rand.Next(4) + 1;
			}
			if (GemType == 1)
			{
				resultType = 178;
				resultStack = Main.rand.Next(4) + 1;
			}
			if (GemType == 2)
			{
				resultType = 179;
				resultStack = Main.rand.Next(4) + 1;
			}
			if (GemType == 3)
			{
				resultType = 180;
				resultStack = Main.rand.Next(4) + 1;
			}
			if (GemType == 4)
			{
				resultType = 181;
				resultStack = Main.rand.Next(4) + 1;
			}
			if (GemType == 5)
			{
				resultType = 182;
				resultStack = Main.rand.Next(4) + 1;
			}
			if (GemType == 6)
			{
				resultType = 999;
				resultStack = Main.rand.Next(4) + 1;
			}
		}
	}
}