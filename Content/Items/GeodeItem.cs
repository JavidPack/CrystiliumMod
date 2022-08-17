using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace CrystiliumMod.Content.Items
{
	public class GeodeItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Geode");
			// Tooltip.SetDefault("'I wonder what's inside!'");
			ItemID.Sets.ExtractinatorMode[Item.type] = Item.type;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 20;
			Item.maxStack = 999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = 1;
			Item.consumable = true;
			Item.value = 4000;
			Item.rare = 1;
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