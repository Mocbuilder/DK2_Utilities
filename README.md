# DK2 Utilities
DK2 Utilities is a collection of tools for Door Kickers 2. In the current version v1.0 there are two features, with more to be added in future updates.

# Installation
There are 2 ways that you can use DK2 Utilities. Regardless of which way you choose, it always needs to be run as administrator. 

## 1. Installer
- Download the newest Installer from the Releases and run it
- Follow the instructions in the installer
- Run the Program as administrator

## 2. Portable Installation
- Download the newest portable.zip from the Releases and unpack it
- Run DK2_Utils.exe as administrator

# Features
## Supply Editor
In Door Kickers 2, every soldier that you place costs one (sometimes a half or two) supply points. These values are assigned to Unit Classes, and are handled numerically in the game's code.
There, 1 Supply point in-game is displayed with a value of 100. A half point is 50, and two points are 200. 0 is nothing, you could deploy an endless amount of soldiers. 
The game can only display half or full points, so if you have soldiers worth 0 supply value, then you'll have one half supply point visible in-game, but it stays at one half, even when you deploy more 0 value soldiers.
You can change the supply value for all units to a value you choose using this feature. Currently, the new value will be assigned globally to all units, excluding the base game units (Rangers, CIA, NWS). 
Further functionality will be added in the next update.

## IoV Tracer Bug Fix
One of the most popular and most depended on mods for DK2 is IoV, or Instruments of Violence. But, for unknown reasons there is a bug where weapons in-game that come from the mod throw an error everytime they fire. 
According to the error the Tracer for the bullet cannot be found. To fix it, this feature simply replaces all mentions of the specific buggy Tracers in the code with the base-game Tracers.

# FAQ
## There was an Update for a mod/the game, do I have to run the program again ?
Yes, do to the files which are being modified getting replaced when a mod or the game gets updated, you will have to run the program again.

## Why does it have to be run as administrator ?
Do to the program modifying files, it needs to have administrator permissions.

# ToDo/Confirmed Feature Requests
- Include base-game units in Supply Editor
- Choose which folders/mods to apply the supply edit to