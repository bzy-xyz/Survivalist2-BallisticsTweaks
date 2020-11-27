using System;
using System.Collections.Generic;

using UnityEngine;
using HarmonyLib;
using UnityModManagerNet;

namespace BallisticsTweaks
{
    static class Main
    {
        public static UnityModManager.ModEntry mod;

        static bool Load(UnityModManager.ModEntry modEntry)
        {
            Harmony.DEBUG = true;

            var harmony = new Harmony(modEntry.Info.Id);
            harmony.PatchAll();

            typeof(AmmoWeapon).GetField("Spread", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).SetValue(null, 2.0f);
            typeof(AmmoWeapon).GetField("MaxInaccuracyAngle", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static).SetValue(null, 5.0f);

            mod = modEntry;

            return true;
        }      
    }

    static class FakeGaussianDistribution {

        static int NUM_SAMPLES = 5;

        public static float NextFakeGaussian(float mean, float sigma, float seed) {
            // As of v102 the MathUtil.GetNormallyDistributedRand returns a
            // Bates distribution with a variance of 1/(12n), where n is the
            // number of requested samples.
            // We can rescale the result of this to emulate a "real" normal
            // distribution.
            float sample = MathUtil.GetNormallyDistributedRand(seed, NUM_SAMPLES);

            float sample_sigma = Mathf.Sqrt(1.0f / (12f * NUM_SAMPLES));

            return (sample - 0.5f) * (sigma / sample_sigma);
        }

        public static float NextFakeRayleigh(float sigma, float seed) {
            float x1 = NextFakeGaussian(0f, sigma, seed);
            float x2 = NextFakeGaussian(0f, sigma, seed + 1023f);

            return Mathf.Sqrt(x1 * x1 + x2 * x2);
        }
    }
    
    [HarmonyPatch(typeof(AmmoWeapon), "GetRandomFireDir")]
    static class AmmoWeapon__GetRandomFireDir__Patch {
        static bool Prefix(ref Vector3 __result, Character character, Vector3 dir, float spread, float seed)
        {
            float perpAngle = MathUtil.RandomFloat(seed) * ((float)Math.PI * 2f);
            float spreadAngle = Mathf.Abs(FakeGaussianDistribution.NextFakeRayleigh(spread / 2.0f, seed + 1000f));

		    __result = AmmoWeapon.GetFireDir(character, dir, perpAngle, spreadAngle);
            return false;
        }
    }
}
