﻿using System.Collections.ObjectModel;
using BepInEx;
using BepInEx.Configuration;
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
        public static ConfigEntry<bool> Display0 { get; set; }
        public static ConfigEntry<bool> DisplayX { get; set; }
        public static ConfigEntry<string> NumberPosition { get; set; }
        public static ConfigEntry<string> NumberSize{ get; set; }

        private TMPro.TextAlignmentOptions GetAlignment()
        {
            switch (NumberPosition.Value)
            {
                case "TopRight": return TMPro.TextAlignmentOptions.TopRight;
                case "BottomRight": return TMPro.TextAlignmentOptions.BottomRight;
                case "BottomLeft": return TMPro.TextAlignmentOptions.BottomLeft;
                case "TopLeft": return TMPro.TextAlignmentOptions.TopLeft;
                case "Center": return TMPro.TextAlignmentOptions.Center;
            }

            return TMPro.TextAlignmentOptions.TopRight;
        }

        private Vector2 GetPosition()
        {
            switch (NumberSize.Value)
            {
                case "Small":
                    switch (NumberPosition.Value)
                    {
                        case "TopRight": return new Vector2(-5f, -1.5f);
                        case "BottomRight": return new Vector2(-5f, 1.5f);
                        case "BottomLeft": return new Vector2(5f, 1.5f);
                        case "TopLeft": return new Vector2(5f, -1.5f);
                        case "Center": return new Vector2(0, 0);
                    }
                    break;
                case "Medium":
                    switch (NumberPosition.Value)
                    {
                        case "TopRight": return new Vector2(-5f, 0.5f);
                        case "BottomRight": return new Vector2(-5f, 0.5f);
                        case "BottomLeft": return new Vector2(5f, 0.5f);
                        case "TopLeft": return new Vector2(5f, 0.5f);
                        case "Center": return new Vector2(0, 0);
                    }
                    break;
                case "Large":
                    switch (NumberPosition.Value)
                    {
                        case "TopRight": return new Vector2(-5f, 2.5f);
                        case "BottomRight": return new Vector2(-5f, -2f);
                        case "BottomLeft": return new Vector2(5f, -2f);
                        case "TopLeft": return new Vector2(5f, 2.5f);
                        case "Center": return new Vector2(0, 0);
                    }
                    break;
            }

            return new Vector2(-5f, -1.5f);
        }

        private float GetSize()
        {
            switch (NumberSize.Value)
            {
                case "Small": return 18f;
                case "Medium": return 30f;
                case "Large": return 42f;
            }

            return 18f;
        }

        private void CreateNumberLabel (Transform parent, ItemIndex itemIndex, int count)
        {
            string textContainerName = $"TextContainer_{(int)itemIndex}";

            Transform old = parent.Find(textContainerName);

            if (old != null)
            {
                Destroy(old.gameObject);
            }

            if (!Display0.Value && count == 0)
            {
                return;
            }

            GameObject textContainer = new GameObject(textContainerName);

            textContainer.transform.parent = parent;

            textContainer.AddComponent<CanvasRenderer>();

            RectTransform rectTransform = textContainer.AddComponent<RectTransform>();
            HGTextMeshProUGUI hgtextMeshProUGUI = textContainer.AddComponent<HGTextMeshProUGUI>();

            hgtextMeshProUGUI.text = (DisplayX.Value ? "x" : "") + count;
            hgtextMeshProUGUI.fontSize = GetSize();
            hgtextMeshProUGUI.color = Color.white;
            hgtextMeshProUGUI.alignment = GetAlignment();
            hgtextMeshProUGUI.enableWordWrapping = false;

            rectTransform.localPosition = Vector2.zero;
            rectTransform.anchorMin = Vector2.zero;
            rectTransform.anchorMax = Vector2.one;
            rectTransform.localScale = Vector3.one;
            rectTransform.sizeDelta = Vector2.zero;
            rectTransform.anchoredPosition = GetPosition();
        }

        private void SetPickupOptionsHook(
            On.RoR2.UI.PickupPickerPanel.orig_SetPickupOptions orig,
            PickupPickerPanel self,
            PickupPickerController.Option[] options
        )
        {
            orig.Invoke(self, options);

            // if no options or equipment return
            if (
                options.Length < 1 ||
                !PickupCatalog.GetPickupDef(options[0].pickupIndex).equipmentIndex.Equals(EquipmentIndex.None)
            )
            {
                return;
            }

            ReadOnlyCollection<MPButton> elements =
                self.GetFieldValue<UIElementAllocator<MPButton>>("buttonAllocator").elements;

            Inventory inventory = LocalUserManager.GetFirstLocalUser().cachedMasterController.master.inventory;

            for (int i = 0; i < options.Length; i++)
            {
                Transform parent = elements[i].transform;
                ItemIndex itemIndex = PickupCatalog.GetPickupDef(options[i].pickupIndex).itemIndex;
                int itemCount = inventory.GetItemCount(itemIndex);

                CreateNumberLabel(parent, itemIndex, itemCount);
            }
        }

        private void InitConfig()
        {
            Display0 = Config.Bind<bool>(
                "Settings",
                "Display0",
                true,
                "Display '0' or 'x0' if item count is 0"
            );

            DisplayX = Config.Bind<bool>(
                "Settings",
                "DisplayX",
                true,
                "Display the 'x' in front of the number"
            );

            NumberPosition = Config.Bind<string>(
                "Settings",
                "NumberPosition",
                "TopRight",
                "Number Position Options: TopRight, BottomRight, BottomLeft, TopLeft, Center"
            );

            NumberSize= Config.Bind<string>(
                "Settings",
                "NumberSize",
                "Small",
                "Number Size Options: Small, Medium, Large"
            );
        }

        public void Awake()
        {
            InitConfig();

            On.RoR2.UI.PickupPickerPanel.SetPickupOptions += SetPickupOptionsHook;
        }

        public void OnDestroy()
        {
            On.RoR2.UI.PickupPickerPanel.SetPickupOptions -= SetPickupOptionsHook;
        }
    }
}
