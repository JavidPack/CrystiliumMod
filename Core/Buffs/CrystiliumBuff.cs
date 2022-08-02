using Terraria.ID;
using Terraria.ModLoader;

namespace CrystiliumMod.Core.Buffs
{
    public abstract class CrystiliumBuff : ModBuff
    {
        public virtual bool LongerExpertDebuff {
            get => BuffID.Sets.LongerExpertDebuff[Type];
            set => BuffID.Sets.LongerExpertDebuff[Type] = value;
        }
    }
}