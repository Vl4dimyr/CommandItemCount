# CommandItemCount

## Description

This mod shows the current item counts in the item selection dialog of the [Artifact of Command](https://riskofrain2.gamepedia.com/Artifacts) and the [Scrapper](https://riskofrain2.gamepedia.com/Scrapper). The equipment selection dialog remains unchanged!

> You need to use the [Artifact of Command](https://riskofrain2.gamepedia.com/Artifacts) in your run or use the [Scrapper](https://riskofrain2.gamepedia.com/Scrapper) for this mod to work!

## Features

All features are configurable see "Config" below

* Displays the current item counts
* Shows tooltips
* Closes the dialog using `Escape`, `W`, `A`, `S`, `D`, `Space` or `Shift`

## Screenshots

![screenshot](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/sc_white.jpg)

![screenshot](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/sc_scrap.jpg)

![screenshot](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/sc_tooltip.jpg)

![screenshot](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/sc_tooltip_with_stats.jpg)

> Works with [ItemStatsMod](https://thunderstore.io/package/ontrigger/ItemStatsMod/)

## Config

### TL;DR

Use [Risk Of Options](https://thunderstore.io/package/Rune580/Risk_Of_Options/) for in-game settings!

![Risk Of Options Screenshot](https://raw.githubusercontent.com/Vl4dimyr/CommandItemCount/master/images/risk_of_options.jpg)

### Manual Config

The config file (`\BepInEx\config\de.userstorm.commanditemcount.cfg`) will be crated automatically when the mod is loaded.
You need to restart the game for changes to apply in game.

You can disable/enable tooltips, change the size and position of the text and decide whether you want the 'x' in front of the number.
Also you can decide which keys can close the Command/Scrapper dialog.

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
It also leaves all keys enabled for closing the dialog.

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

## Closes the item picker dialog when Esc is pressed
# Setting type: Boolean
# Default value: true
EnableCloseDialogWithEscape = true

## Closes the item picker dialog when W, A, S or D is pressed
# Setting type: Boolean
# Default value: true
EnableCloseDialogWithWASD = true

## Closes the item picker dialog when Space is pressed
# Setting type: Boolean
# Default value: true
EnableCloseDialogWithSpace = true

## Closes the item picker dialog when Shift is pressed
# Setting type: Boolean
# Default value: true
EnableCloseDialogWithShift = true
```

## Manual Install

- Install [BepInEx](https://thunderstore.io/package/bbepis/BepInExPack/) and [R2API](https://thunderstore.io/package/tristanmcpherson/R2API/)
- Download the latest `CommandItemCount_x.y.z.zip` [here](https://thunderstore.io/package/Vl4dimyr/CommandItemCount/)
- Extract and move the `CommandItemCount.dll` into the `\BepInEx\plugins` folder
- (optional) Install [ItemStatsMod](https://thunderstore.io/package/ontrigger/ItemStatsMod/)
- (optional) Install [Risk Of Options](https://thunderstore.io/package/Rune580/Risk_Of_Options/)

## Changelog

The [Changelog](https://github.com/Vl4dimyr/CommandItemCount/blob/master/CHANGELOG.md) can be found on GitHub.

## Bugs/Feedback

For bugs or feedback please use [GitHub Issues](https://github.com/Vl4dimyr/CommandItemCount/issues).

## Help me out

[![Patreon](https://cdn.iconscout.com/icon/free/png-64/patreon-2752105-2284922.png)](https://www.patreon.com/vl4dimyr)

It is by no means required, but if you would like to support me head over to [my Patreon](https://www.patreon.com/vl4dimyr).
