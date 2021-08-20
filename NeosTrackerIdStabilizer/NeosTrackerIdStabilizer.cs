using FrooxEngine;
using HarmonyLib;
using NeosModLoader;
using System;
using System.Reflection;

namespace NeosTrackerIdStabilizer
{
    public class NeosTrackerIdStabilizer : NeosMod
    {
        public override string Name => "NeosTrackerIdStabilizer";
        public override string Author => "runtime";
        public override string Version => "1.0.0";
        public override string Link => "https://github.com/zkxs/NeosTrackerIdStabilizer";

        public override void OnEngineInit()
        {
            Harmony harmony = new Harmony("net.michaelripley.NeosTrackerIdStabilizer");

            MethodInfo originalMethod = AccessTools.DeclaredPropertySetter(typeof(ViveTracker), nameof(ViveTracker.UniqueID));
            if (originalMethod == null)
            {
                Error($"Could not find ViveTracker.UniqueID setter");
                return;
            }

            MethodInfo patch = AccessTools.DeclaredMethod(typeof(NeosTrackerIdStabilizer), nameof(NeosTrackerIdStabilizer.UniqueIDSetterPostfix));
            harmony.Patch(originalMethod, postfix: new HarmonyMethod(patch));
            Msg("patch installed successfully");
        }

        public static void UniqueIDSetterPostfix(ViveTracker __instance, string value)
        {
            MethodInfo publicIdSetter = AccessTools.DeclaredPropertySetter(typeof(ViveTracker), nameof(ViveTracker.PublicID));
            if (publicIdSetter == null)
            {
                Error("Could not find ViveTracker.PublicID setter");
                return;
            }
            try
            {
                Debug($"renaming vive tracker from {__instance.PublicID} to {value}");
                publicIdSetter.Invoke(__instance, new object[] { value });
            }
            catch (Exception e)
            {
                Error($"Exception calling ViveTracker.PublicID setter:\n{e}");
            }
        }
    }
}
