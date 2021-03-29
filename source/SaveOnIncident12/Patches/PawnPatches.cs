using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace SaveOnIncident.Patches
{
    [HarmonyPatch(typeof(Pawn), "Kill")]
    static class Pawn_Kill_SaveOnIncidentPatch
    {
        static void Postfix(Pawn __instance)
        {
            if (__instance.Faction == Faction.OfPlayer)
                if (__instance.RaceProps.Humanlike && Settings.saveAfterColonistDeath)
                    StoryStatePatches.DoSave();
                else if (Settings.saveAfterColonyAnimalDeath)
                    StoryStatePatches.DoSave();
        }
    }
}
