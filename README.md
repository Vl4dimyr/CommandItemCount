# CommandItemCount

## Description

This mod shows the current item counts in the item selection dialog of the [Artifact of Command](https://riskofrain2.gamepedia.com/Artifacts) and the [Scrapper](https://riskofrain2.gamepedia.com/Scrapper). The equipment selection dialog remains unchanged!

> You need to use the [Artifact of Command](https://riskofrain2.gamepedia.com/Artifacts) in your run or use the [Scrapper](https://riskofrain2.gamepedia.com/Scrapper) for this mod to work!

## Screenshots

![screenshot](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/sc_white.jpg)

![screenshot](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/sc_scrap.jpg)

![screenshot](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/sc_tooltip.jpg)

![screenshot](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/sc_tooltip_with_stats.jpg)

> Works with [ItemStatsMod](https://thunderstore.io/package/ontrigger/ItemStatsMod/)

## Config

The config file (`\BepInEx\config\de.userstorm.commanditemcount.cfg`) will be crated automatically when the mod is loaded.
You need to restart the game for changes to apply in game.

You can disable/enable tooltips, change the size and position of the text and decide whether you want the 'x' in front of the number.

### Options with x
|        | TopRight | BottomRight | BottomLeft | TopLeft | Center |
|--------|----------|-------------|------------|---------|--------|
| Small  | ![x_small_top_right](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_small_top_right.png) | ![x_small_bottom_right](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_small_bottom_right.png) | ![x_small_bottom_left](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_small_bottom_left.png) | ![x_small_top_left](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_small_top_left.png) | ![x_small_center](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_small_center.png) |
| Medium | ![x_medium_top_right](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_medium_top_right.png) | ![x_medium_bottom_right](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_medium_bottom_right.png) | ![x_medium_bottom_left](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_medium_bottom_left.png) | ![x_medium_top_left](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_medium_top_left.png) | ![x_medium_center](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_medium_center.png) |
| Large  | ![x_large_top_right](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_large_top_right.png) | ![x_large_bottom_right](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_large_bottom_right.png) | ![x_large_bottom_left](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_large_bottom_left.png) | ![x_large_top_left](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_large_top_left.png) | ![x_large_center](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/x_large_center.png) |

### Options without x
|        | TopRight | BottomRight | BottomLeft | TopLeft | Center |
|--------|----------|-------------|------------|---------|--------|
| Small  | ![small_top_right](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/small_top_right.png) | ![small_bottom_right](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/small_bottom_right.png) | ![small_bottom_left](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/small_bottom_left.png) | ![small_top_left](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/small_top_left.png) | ![small_center](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/small_center.png) |
| Medium | ![medium_top_right](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/medium_top_right.png) | ![medium_bottom_right](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/medium_bottom_right.png) | ![medium_bottom_left](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/medium_bottom_left.png) | ![medium_top_left](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/medium_top_left.png) | ![medium_center](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/medium_center.png) |
| Large  | ![large_top_right](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/large_top_right.png) | ![large_bottom_right](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/large_bottom_right.png) | ![large_bottom_left](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/large_bottom_left.png) | ![large_top_left](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/large_top_left.png) | ![large_center](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/options/large_center.png) |

### Example config

The example config keeps tooltips enabled, disables `0` and `x` and uses `Large` numbers in the `Center` of the icon.

```ini
## Settings file was created by plugin CommandItemCount v1.2.0
## Plugin GUID: de.userstorm.commanditemcount

[Settings]

## Display '0' or 'x0' if item count is 0
# Setting type: Boolean
# Default value: true
Display0 = false

## Display the 'x' in front of the number
# Setting type: Boolean
# Default value: true
DisplayX = false

## Number Position Options: TopRight, BottomRight, BottomLeft, TopLeft, Center
# Setting type: String
# Default value: TopRight
NumberPosition = Center

## Number Size Options: Small, Medium, Large
# Setting type: String
# Default value: Small
NumberSize = Large

## Show Item/Equipment Tooltip
# Setting type: Boolean
# Default value: true
EnableTooltip = true
```

## Manual Install

- Install [BepInEx](https://thunderstore.io/package/bbepis/BepInExPack/) and [R2API](https://thunderstore.io/package/tristanmcpherson/R2API/)
- Download the latest `CommandItemCount_x.y.z.zip` [here](https://thunderstore.io/package/Vl4dimyr/CommandItemCount/)
- Extract and move the `CommandItemCount.dll` into the `\BepInEx\plugins` folder
- (optional) Install [ItemStatsMod](https://thunderstore.io/package/ontrigger/ItemStatsMod/)

## Changelog

The [Changelog](https://github.com/Vl4dimyr/CommandItemCount/blob/master/CHANGELOG.md) can be found on GitHub.

## Bugs/Feedback

For bugs or feedback please use [GitHub Issues](https://github.com/Vl4dimyr/CommandItemCount/issues).
