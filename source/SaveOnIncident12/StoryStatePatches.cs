using System;
using HarmonyLib;
using RimWorld;
using Verse;

namespace SaveOnIncident
{
    public static class StoryStatePatches
    {
        public static void DoSave()
        {      
            LongEventHandler.QueueLongEvent(new Action(Current.Game.autosaver.DoAutosave), "Autosaving", false, null, true);
            Settings.FticksSinceSave.SetValue(Current.Game.autosaver, 0);
        }

        [HarmonyPatch(typeof(StoryState), "Notify_IncidentFired")]
        static class StoryState_Notify_IncidentFired_SaveOnIncidentPatch
        {
            static void Postfix(FiringIncident fi)
            {
                if(Settings.misc && fi.def.category == IncidentCategoryDefOf.Misc
                || Settings.threatSmall && fi.def.category == IncidentCategoryDefOf.ThreatSmall
                || Settings.threatBig && fi.def.category == IncidentCategoryDefOf.ThreatBig
                || Settings.factionArrival && fi.def.category == IncidentCategoryDefOf.FactionArrival
                || Settings.orbitalVisitor && fi.def.category == IncidentCategoryDefOf.OrbitalVisitor
                || Settings.shipChunkDrop && fi.def.category == IncidentCategoryDefOf.ShipChunkDrop
                || Settings.diseaseHuman && fi.def.category == IncidentCategoryDefOf.DiseaseHuman
                || Settings.diseaseAnimal && fi.def.category == IncidentCategoryDefOf.DiseaseAnimal
                || Settings.allyAssistance && fi.def.category == IncidentCategoryDefOf.AllyAssistance
                || Settings.giveQuest && fi.def.category == IncidentCategoryDefOf.GiveQuest
                || Settings.deepDrillInfestation && fi.def.category == IncidentCategoryDefOf.DeepDrillInfestation)
                {
                    DoSave();
                }
            }
        }


    }
}
