using System.Collections.ObjectModel;
using BepInEx;
using BepInEx.Configuration;
using R2API.Utils;
using RoR2;
using RoR2.UI;
using UnityEngine;

namespace CommandItemCount
{
    public enum Position { TopRight, BottomRight, BottomLeft, TopLeft, Center }
    public enum Size { Small, Medium, Large }

    [BepInDependency("com.rune580.riskofoptions", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("ontrigger-ItemStatsMod-2.2.1", BepInDependency.DependencyFlags.SoftDependency)]
    [BepInDependency("com.bepis.r2api", BepInDependency.DependencyFlags.HardDependency)]
    [BepInPlugin("de.userstorm.commanditemcount", "CommandItemCount", "{VERSION}")]
    [NetworkCompatibility(CompatibilityLevel.NoNeedForSync, VersionStrictness.DifferentModVersionsAreOk)]
    public class CommandItemCountPlugin : BaseUnityPlugin
    {
        public static ConfigEntry<bool> Show0 { get; set; }
        public static ConfigEntry<bool> ShowX { get; set; }
        public static ConfigEntry<Position> NumberPosition { get; set; }
        public static ConfigEntry<Size> NumberSize{ get; set; }
        public static ConfigEntry<bool> EnableTooltip { get; set; }
        public static ConfigEntry<bool> EnableCloseDialogWithEscape { get; set; }
        public static ConfigEntry<bool> EnableCloseDialogWithWASD { get; set; }
        public static ConfigEntry<bool> EnableCloseDialogWithSpace { get; set; }
        public static ConfigEntry<bool> EnableCloseDialogWithShift { get; set; }

        private TMPro.TextAlignmentOptions GetAlignment()
        {
            switch (NumberPosition.Value)
            {
                case Position.TopRight: return TMPro.TextAlignmentOptions.TopRight;
                case Position.BottomRight: return TMPro.TextAlignmentOptions.BottomRight;
                case Position.BottomLeft: return TMPro.TextAlignmentOptions.BottomLeft;
                case Position.TopLeft: return TMPro.TextAlignmentOptions.TopLeft;
                case Position.Center: return TMPro.TextAlignmentOptions.Center;
            }

            return TMPro.TextAlignmentOptions.TopRight;
        }

        private Vector2 GetPosition()
        {
            switch (NumberSize.Value)
            {
                case Size.Small:
                    switch (NumberPosition.Value)
                    {
                        case Position.TopRight: return new Vector2(-5f, -1.5f);
                        case Position.BottomRight: return new Vector2(-5f, 1.5f);
                        case Position.BottomLeft: return new Vector2(5f, 1.5f);
                        case Position.TopLeft: return new Vector2(5f, -1.5f);
                        case Position.Center: return new Vector2(0, 0);
                    }
                    break;
                case Size.Medium:
                    switch (NumberPosition.Value)
                    {
                        case Position.TopRight: return new Vector2(-5f, 0.5f);
                        case Position.BottomRight: return new Vector2(-5f, 0.5f);
                        case Position.BottomLeft: return new Vector2(5f, 0.5f);
                        case Position.TopLeft: return new Vector2(5f, 0.5f);
                        case Position.Center: return new Vector2(0, 0);
                    }
                    break;
                case Size.Large:
                    switch (NumberPosition.Value)
                    {
                        case Position.TopRight: return new Vector2(-5f, 2.5f);
                        case Position.BottomRight: return new Vector2(-5f, -2f);
                        case Position.BottomLeft: return new Vector2(5f, -2f);
                        case Position.TopLeft: return new Vector2(5f, 2.5f);
                        case Position.Center: return new Vector2(0, 0);
                    }
                    break;
            }

            return new Vector2(-5f, -1.5f);
        }

        private float GetSize()
        {
            switch (NumberSize.Value)
            {
                case Size.Small: return 18f;
                case Size.Medium: return 30f;
                case Size.Large: return 42f;
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

            if (!Show0.Value && count == 0)
            {
                return;
            }

            GameObject textContainer = new GameObject(textContainerName);

            textContainer.transform.parent = parent;

            textContainer.AddComponent<CanvasRenderer>();

            RectTransform rectTransform = textContainer.AddComponent<RectTransform>();
            HGTextMeshProUGUI hgtextMeshProUGUI = textContainer.AddComponent<HGTextMeshProUGUI>();

            hgtextMeshProUGUI.text = (ShowX.Value ? "x" : "") + count;
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

        private void CreateTooltip (Transform parent, PickupDef pickupDefinition, int count)
        {
            ItemDef itemDefinition = ItemCatalog.GetItemDef(pickupDefinition.itemIndex);
            EquipmentDef equipmentDef = EquipmentCatalog.GetEquipmentDef(pickupDefinition.equipmentIndex);
            bool isItem = itemDefinition != null;

            TooltipContent content = new TooltipContent();

            content.titleColor = pickupDefinition.darkColor;
            content.titleToken = isItem ? itemDefinition.nameToken : equipmentDef.nameToken;
            content.bodyToken = isItem ? itemDefinition.descriptionToken : equipmentDef.descriptionToken;

            if (isItem && ItemStatsMod.enabled)
            {
                CharacterMaster master = PlayerCharacterMasterController.instances[0].master;

                string stats = ItemStatsMod.GetStats(itemDefinition.itemIndex, count, master);

                if (stats != null)
                {
                    content.overrideBodyText = $"{Language.GetString(content.bodyToken)}{stats}";
                }
            }

            TooltipProvider tooltipProvider = parent.gameObject.AddComponent<TooltipProvider>();

            tooltipProvider.SetContent(content);
        }

        private void SetPickupOptionsHook(
            On.RoR2.UI.PickupPickerPanel.orig_SetPickupOptions orig,
            PickupPickerPanel self,
            PickupPickerController.Option[] options
        )
        {
            orig.Invoke(self, options);

            if (options.Length < 1)
            {
                return;
            }

            ReadOnlyCollection<MPButton> elements =
                self.GetFieldValue<UIElementAllocator<MPButton>>("buttonAllocator").elements;

            Inventory inventory = LocalUserManager.GetFirstLocalUser().cachedMasterController.master.inventory;

            for (int i = 0; i < options.Length; i++)
            {
                Transform parent = elements[i].transform;
                PickupDef pickupDefinition = PickupCatalog.GetPickupDef(options[i].pickupIndex);
                ItemIndex itemIndex = pickupDefinition.itemIndex;
                int itemCount = !itemIndex.Equals(ItemIndex.None) ? inventory.GetItemCount(itemIndex) : 0;

                if (pickupDefinition.equipmentIndex.Equals(EquipmentIndex.None))
                {
                    CreateNumberLabel(parent, itemIndex, itemCount);
                }

                if (EnableTooltip.Value)
                {
                    CreateTooltip(parent, pickupDefinition, itemCount);
                }
            }
        }

        private void HandleClosePickupPickerPanel()
        {
            if (
                (EnableCloseDialogWithEscape.Value && Input.GetKeyDown(KeyCode.Escape)) ||
                (EnableCloseDialogWithWASD.Value && Input.GetKeyDown(KeyCode.W)) ||
                (EnableCloseDialogWithWASD.Value && Input.GetKeyDown(KeyCode.A)) ||
                (EnableCloseDialogWithWASD.Value && Input.GetKeyDown(KeyCode.S)) ||
                (EnableCloseDialogWithWASD.Value && Input.GetKeyDown(KeyCode.D)) ||
                (EnableCloseDialogWithSpace.Value && Input.GetKeyDown(KeyCode.Space)) ||
                (EnableCloseDialogWithShift.Value && Input.GetKeyDown(KeyCode.LeftShift))
            )
            {
                PickupPickerPanel[] panels = FindObjectsOfType(typeof(PickupPickerPanel)) as PickupPickerPanel[];

                if (panels.Length > 0)
                {
                    foreach (PickupPickerPanel panel in panels)
                    {
                        Destroy(panel.gameObject);
                    }

                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        Console.instance.SubmitCmd(null, "pause", false);
                    }
                }
            }
        }

        private void InitConfig()
        {
            Show0 = Config.Bind<bool>(
                "Settings",
                "Show0",
                true,
                "Display '0' or 'x0' if item count is 0"
            );

            ShowX = Config.Bind<bool>(
                "Settings",
                "ShowX",
                true,
                "Display the 'x' in front of the number"
            );

            NumberPosition = Config.Bind<Position>(
                "Settings",
                "NumberPosition",
                Position.TopRight,
                "Number Position"
            );

            NumberSize = Config.Bind<Size>(
                "Settings",
                "NumberSize",
                Size.Small,
                "Number Size"
            );

            EnableTooltip = Config.Bind<bool>(
                "Settings",
                "EnableTooltip",
                true,
                "Show Item/Equipment Tooltip"
            );

            EnableCloseDialogWithEscape = Config.Bind<bool>(
                "Settings",
                "EnableCloseDialogWithEscape",
                true,
                "Closes the item picker dialog when Esc is pressed"
            );

            EnableCloseDialogWithWASD = Config.Bind<bool>(
                "Settings",
                "EnableCloseDialogWithWASD",
                true,
                "Closes the item picker dialog when W, A, S or D is pressed"
            );

            EnableCloseDialogWithSpace = Config.Bind<bool>(
                "Settings",
                "EnableCloseDialogWithSpace",
                true,
                "Closes the item picker dialog when Space is pressed"
            );

            EnableCloseDialogWithShift = Config.Bind<bool>(
                "Settings",
                "EnableCloseDialogWithShift",
                true,
                "Closes the item picker dialog when Shift is pressed"
            );

            if (RiskOfOptionsMod.enabled)
            {
                RiskOfOptionsMod.Init(
                    "This mod shows the current item counts in the item selection dialog of the Artifact of Command and the Scrapper."
                );
                RiskOfOptionsMod.AddCheckboxOption(Show0);
                RiskOfOptionsMod.AddCheckboxOption(ShowX);
                RiskOfOptionsMod.AddChoiceOption<Position>(NumberPosition);
                RiskOfOptionsMod.AddChoiceOption<Size>(NumberSize);
                RiskOfOptionsMod.AddCheckboxOption(EnableTooltip);
                RiskOfOptionsMod.AddCheckboxOption(EnableCloseDialogWithEscape);
                RiskOfOptionsMod.AddCheckboxOption(EnableCloseDialogWithWASD);
                RiskOfOptionsMod.AddCheckboxOption(EnableCloseDialogWithSpace);
                RiskOfOptionsMod.AddCheckboxOption(EnableCloseDialogWithShift);
            }
        }

        public void Awake()
        {
            InitConfig();

            On.RoR2.UI.PickupPickerPanel.SetPickupOptions += SetPickupOptionsHook;
        }

        public void Update()
        {
            HandleClosePickupPickerPanel();
        }

        public void OnDestroy()
        {
            On.RoR2.UI.PickupPickerPanel.SetPickupOptions -= SetPickupOptionsHook;
        }
    }
}
