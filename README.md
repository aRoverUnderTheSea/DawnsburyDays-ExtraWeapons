# YAL's Extra Weapons
**Quick links:** [Steam Workshop page](https://steamcommunity.com/sharedfiles/filedetails/?id=)

A random sampling of weapons that I needed for something:

- [Chakram](https://2e.aonprd.com/Weapons.aspx?ID=235) (Tian Xia)
- [Light Hammer](https://2e.aonprd.com/Weapons.aspx?ID=384) (Player Core)
- [Lion Scythe](https://2e.aonprd.com/Weapons.aspx?ID=533) (Battlecry)
- [Pantograph Gauntlet](https://2e.aonprd.com/Weapons.aspx?ID=172) (Guns & Gears)
- [Probing Cane](https://2e.aonprd.com/Weapons.aspx?ID=229) (Grand Bazaar)
- [Throwing Knife](https://2e.aonprd.com/Weapons.aspx?ID=243) (Grand Bazaar)

If you know what C# is, adding more weapons doesn't take much, but you do have to figure out what the closest-looking icon is or find one that's appropriately licensed.

## Building
You'll want to set a `DAWNSBURY_DAYS` environment variable to point at where the game folder resides (where the `.exe` and `CREDITS.txt` are, no trailing backslash).

You can then open the Visual Studio (regrettably, it would seem like it has to be VS2026 because of .NET 10) and build the project.

The post-build step should copy the DLL from `bin` to the game's `CustomMods` folder,
but if it doesn't, you may have to do so by hand.

Post-build step will also attempt to update the DLL in the `export` folder that contains the files for publishing on Steam Workshop.

## Credits
A mod by YellowAfterlife.