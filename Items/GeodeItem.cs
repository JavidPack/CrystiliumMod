using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using Terraria.Utilities;

namespace CrystiliumMod.Items
{
	public class GeodeItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Geode");
			Tooltip.SetDefault("'I wonder what's inside!'");
			ItemID.Sets.ExtractinatorMode[item.type] = item.type;
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 20;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = 1;
			item.consumable = true;
			item.value = 4000;
			item.rare = 1;
		}

		public override void ExtractinatorUse(ref int resultType, ref int resultStack)
		{
			var GemTypeAndStackChooser = new WeightedRandom<Tuple<int,int>>();
			GemTypeAndStackChooser.Add(new Tuple<int, int>(ItemID.Sapphire, Main.rand.Next(1, 5)));
			GemTypeAndStackChooser.Add(new Tuple<int, int>(ItemID.Ruby, Main.rand.Next(1, 5)));
			GemTypeAndStackChooser.Add(new Tuple<int, int>(ItemID.Emerald, Main.rand.Next(1, 5)));
			GemTypeAndStackChooser.Add(new Tuple<int, int>(ItemID.Topaz, Main.rand.Next(1, 5)));
			GemTypeAndStackChooser.Add(new Tuple<int, int>(ItemID.Amethyst, Main.rand.Next(1, 5)));
			GemTypeAndStackChooser.Add(new Tuple<int, int>(ItemID.Diamond, Main.rand.Next(1, 5)));
			GemTypeAndStackChooser.Add(new Tuple<int, int>(ItemID.Amber, Main.rand.Next(1, 5)));
			Tuple<int,int> GemTypeAndStack = GemTypeAndStackChooser;

			resultType = GemTypeAndStack.Item1;
			resultStack = GemTypeAndStack.Item2;
		}
	}
}