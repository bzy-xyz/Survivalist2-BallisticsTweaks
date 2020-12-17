Ballistics Tweaks
===================

A mod for Survivalist: Invisible Strain.

By default, non-aimed shots will diverge from the aimpoint in a pattern
that is angularly thicker at the edges and thinner in the center, such that 
the result is distributed uniformly within a unit circle. The angular 
pattern width changes from 10 degrees for a maximally unaimed shot to 0
degrees for an aimed shot.

The same distribution applies to shotgun pellet spread, with a fixed 5
degree spread, making these weapons dubiously effective at any
significant range.

This mod changes the distribution of all ranged weapon spread to be
closer to a normal distribution, scaled such that around 99% of the
shots are within the requested spread. This should somewhat increase
the overall lethality of all ranged weapons beyond their optimal range,
as well as the lethality of shotguns at any range.

This is technically accomplished with the help of rescaling a Bates 
distribution (average of 5 uniform random samples), which avoids 
trigonometry while providing a "good enough" approximation for gameplay.
The radial deflection angle should be Rayleigh distributed to achieve a
bivariate normal distribution, which we accomplish by taking the 
Euclidean norm of two random variates.

We also tweak the shotgun spread to bring it closer in line with
real-world numbers, as well as the maximum inaccuracy angle. Untrained
or impatient characters will still tend to miss their targets most of 
the time, but less egregiously than under vanilla settings.

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

This mod contains code from Survivalist: Invisible Strain. Bob the P.R. Bot
has confirmed that use of small amounts of such code in non-commercial mods
for Survivalist: Invisible Strain is permissible.

Feel free to use other code from this mod in non-commercial mods for 
Survivalist: Invisible Strain if doing so meets your needs.
