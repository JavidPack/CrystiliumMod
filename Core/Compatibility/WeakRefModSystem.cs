using Terraria.ModLoader;

namespace CrystiliumMod.Core.Compatibility
{
    public abstract class WeakRefModSystem : ModSystem
    {
        protected abstract string WeakRefModName { get; }
        
        private Mod? WeakRefMod;

        public override void Load() {
            base.Load();
            
            WeakRefMod = GetWeakRefMod();
            if (WeakRefMod is not null) 
                WeakRefModLoaded(WeakRefMod);
        }

        public override void PostSetupContent() {
            base.PostSetupContent();
            
            if (WeakRefMod is not null)
                WeakRefPostSetupContent(WeakRefMod);
        }

        public override void Unload() {
            base.Unload();
            
            if (WeakRefMod is not null)
                WeakRefModUnloaded(WeakRefMod);
        }

        protected virtual void WeakRefModLoaded(Mod weakRef) {
        }

        protected virtual void WeakRefPostSetupContent(Mod weakRef) {
        }

        protected virtual void WeakRefModUnloaded(Mod weakRef) {
        }

        protected virtual Mod? GetWeakRefMod() {
            return ModLoader.TryGetMod(WeakRefModName, out Mod? mod) ? mod : null;
        }
    }
}