using System.Collections.ObjectModel;
using BepInEx;
using R2API.Utils;
using RoR2;
using RoR2.UI;
using UnityEngine;

namespace CommandItemCount
{
    [BepInDependency("com.bepis.r2api", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("de.userstorm.commanditemcount", "CommandItemCount", "{VERSION}")]
    public class CommandItemCountPlugin : BaseUnityPlugin
    {
        private void SetPickupOptionsHook(On.RoR2.UI.PickupPickerPanel.orig_SetPickupOptions orig, PickupPickerPanel self, PickupPickerController.Option[] options)
        {
            orig.Invoke(self, options);

            // if no options or equipment return
            if (options.Length < 1 || !PickupCatalog.GetPickupDef(options[0].pickupIndex).equipmentIndex.Equals(EquipmentIndex.None))
            {
                return;
            }

            ReadOnlyCollection<MPButton> elements = self.GetFieldValue<UIElementAllocator<MPButton>>("buttonAllocator").elements;
            Inventory inventory = LocalUserManager.GetFirstLocalUser().cachedMasterController.master.inventory;

            for (int j = 0; j < options.Length; j++)
            {
                ItemIndex itemIndex = PickupCatalog.GetPickupDef(options[j].pickupIndex).itemIndex;

                string textContainerName = $"TextContainer_{(int)itemIndex}";

                Transform parent = elements[j].transform;
                Transform old = parent.Find(textContainerName);

                if (old != null)
				{
                    Destroy(old.gameObject);
                }

                int itemCount = inventory.GetItemCount(itemIndex);

                GameObject textContainer = new GameObject(textContainerName);

                textContainer.transform.parent = parent;

                textContainer.AddComponent<CanvasRenderer>();

                RectTransform rectTransform = textContainer.AddComponent<RectTransform>();
                HGTextMeshProUGUI hgtextMeshProUGUI = textContainer.AddComponent<HGTextMeshProUGUI>();

                hgtextMeshProUGUI.text = "x" + itemCount;
                hgtextMeshProUGUI.fontSize = 18f;
                hgtextMeshProUGUI.color = Color.white;
                hgtextMeshProUGUI.alignment = TMPro.TextAlignmentOptions.TopRight;
                hgtextMeshProUGUI.enableWordWrapping = false;

                rectTransform.localPosition = Vector2.zero;
                rectTransform.anchorMin = Vector2.zero;
                rectTransform.anchorMax = Vector2.one;
                rectTransform.localScale = Vector3.one;
                rectTransform.sizeDelta = Vector2.zero;
                rectTransform.anchoredPosition = new Vector2(-5f, -1.5f);

                rectTransform.ForceUpdateRectTransforms();
            }
        }

        public void Awake()
        {
            On.RoR2.UI.PickupPickerPanel.SetPickupOptions += SetPickupOptionsHook;
        }

        public void OnDestroy()
        {
            On.RoR2.UI.PickupPickerPanel.SetPickupOptions -= SetPickupOptionsHook;
        }
    }
}
