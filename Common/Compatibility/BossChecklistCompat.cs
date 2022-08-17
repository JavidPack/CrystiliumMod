using System.Collections.Generic;
using CrystiliumMod.Content.Items;
using CrystiliumMod.Content.Items.Armor;
using CrystiliumMod.Content.Items.Placeable;
using CrystiliumMod.Content.NPCs.Bosses;
using CrystiliumMod.Core.Compatibility;
using Terraria.ModLoader;
using Terraria.Localization;

namespace CrystiliumMod.Common.Compatibility
{
    public class BossChecklistCompat : WeakRefModSystem
    {
        public const string MOD_NAME = "BossChecklist";

        protected override string WeakRefModName => MOD_NAME;

        protected override void WeakRefPostSetupContent(Mod weakRef) {
            weakRef.Call(
                "AddBoss",
                Mod,
                $"$Mods.CrystiliumMod.BossChecklist.BossName",
                // "Crystal King",
                ModContent.NPCType<CrystalKing>(),
                13.8f,
                () => CrystalWorld.downedCrystalKing,
                () => true,
                new List<int> {ModContent.ItemType<KingTrophy>(), ModContent.ItemType<CrystalMask>()},
                ModContent.ItemType<CrypticCrystal>(),
                // Language.GetTextValue("Mods.CrystiliumMod.BossChecklist.BossDescription", [i:"ModContent.ItemType<CrypticCrystal>()"]);
                "Right click on a Crystal Fountain with a [i:" + ModContent.ItemType<CrypticCrystal>() + "] in your inventory",
                null,
                null // TODO: Custom boss portrait.
            );
        }
    }
}