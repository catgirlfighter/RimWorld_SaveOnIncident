using System;
using HarmonyLib;
using RimWorld;
using Verse;
using System.Reflection;

namespace SaveOnIncident.Patches
{
    [HarmonyPatch(typeof(IncidentWorker), nameof(IncidentWorker.TryExecute))]
    static class IncidentWorker_TryExecute_SaveOnIncidentPatch
    {
        static void Postfix(bool __result, IncidentWorker __instance)
        {
            if (!__result)
                return;
            //
            var def = __instance.def;

            //Log.Message($"catdef={fi.def.category},def={fi.def}");
            if (Settings.misc && def.category == IncidentCategoryDefOf.Misc
            || Settings.threatSmall && def.category == IncidentCategoryDefOf.ThreatSmall
            || Settings.threatBig && def.category == IncidentCategoryDefOf.ThreatBig
            || Settings.factionArrival && def.category == IncidentCategoryDefOf.FactionArrival
            || Settings.orbitalVisitor && def.category == IncidentCategoryDefOf.OrbitalVisitor
            || Settings.shipChunkDrop && def.category == IncidentCategoryDefOf.ShipChunkDrop
            || Settings.diseaseHuman && def.category == IncidentCategoryDefOf.DiseaseHuman
            || Settings.diseaseAnimal && def.category == IncidentCategoryDefOf.DiseaseAnimal
            || Settings.allyAssistance && def.category == IncidentCategoryDefOf.AllyAssistance
            || Settings.giveQuest && def.category == IncidentCategoryDefOf.GiveQuest
            || Settings.deepDrillInfestation && def.category == IncidentCategoryDefOf.DeepDrillInfestation)
            {
                SaveOnIncident.SetupAutosave();
            }
        }
    }
}
