using HarmonyLib;
using RimWorld;
using Verse;

namespace SaveOnIncident.Patches
{
    [HarmonyPatch(typeof(Pawn), "Kill")]
    static class Pawn_Kill_SaveOnIncidentPatch
    {
        internal static void Postfix(Pawn __instance)
        {
            if (__instance.Faction == Faction.OfPlayer)
                if (__instance.RaceProps.Humanlike && Settings.saveAfterColonistDeath)
                    SaveOnIncident.SetupAutosave();
                else if (Settings.saveAfterColonyAnimalDeath)
                    SaveOnIncident.SetupAutosave();
        }
    }
}
