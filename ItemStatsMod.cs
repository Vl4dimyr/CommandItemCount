using ItemStats;
using RoR2;
using System.Runtime.CompilerServices;

namespace CommandItemCount
{
    static class ItemStatsMod
    {
        private static bool? _enabled;

        internal static bool enabled
        {
            get
            {
                if (_enabled == null)
                {
                    _enabled = BepInEx.Bootstrap.Chainloader.PluginInfos.ContainsKey("dev.ontrigger.itemstats");
                }

                return (bool)_enabled;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        internal static string GetStats(ItemIndex itemIndex, int itemCount)
        {
            return ItemStatProvider.ProvideStatsForItem(itemIndex, itemCount);
        }
    }
}
