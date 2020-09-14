using System;
using System.Runtime.CompilerServices;
using BepInEx.Bootstrap;
using ItemStats;
using RoR2;

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
                    _enabled = Chainloader.PluginInfos.ContainsKey("dev.ontrigger.itemstats");
                }

                return (bool)_enabled;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        internal static string GetStats(ItemIndex itemIndex, int itemCount, CharacterMaster master)
        {
            try
            {
                return ItemStats.ItemStatsMod.GetStatsForItem(itemIndex, itemCount, new StatContext(master));
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
