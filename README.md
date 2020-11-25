Ballistics Tweaks
===================

A mod for Survivalist: Invisible Strain.

By default, non-aimed shots will diverge from the aimpoint in a pattern
that is thicker at the edges and thinner in the center. The angular
pattern width changes from 10 degrees for a maximally unaimed shot to 0
degrees for an aimed shot.

The same distribution applies to shotgun pellet spread, with a fixed 5
degree spread, making these weapons dubiously effective at any
significant range.

This mod changes the distribution of all ranged weapon spread to be
closer to a normal distribution, scaled such that around 95% of the
shots are within the requested spread. This should dramatically increase
the lethality of all ranged weapons beyond their optimal range, as well
as the lethality of shotguns at any range.

This is technically accomplished by rescaling a Bates distribution
(average of 5 uniform random samples), which avoids trigonometry while
providing a "good enough" approximation for gameplay. As a side effect,
all raycasts are restricted to about 1.6 times the requested spread,
eliminating the need to worry about pathological effects like pellets
going backwards ever happening.


Requirements
------------

* Unity Mod Manager installed into Survivalist: Invisible Strain.

Build
-----

1. Checkout to `dev/BallisticsTweaks`.
2. From the `dev/BallisticsTweaks/src` directory, run `dotnet build`.
3. Copy `dev/BallisticsTweaks/src/bin/Debug/net40/BallisticsTweaks.dll` 
   and `dev/BallisticsTweaks/Info.json` to `Mods/BallisticsTweaks`.

License
-------

I claim nothing. ¯\_(ツ)_/¯