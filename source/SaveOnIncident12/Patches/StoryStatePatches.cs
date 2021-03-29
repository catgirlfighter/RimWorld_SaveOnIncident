using System;
using HarmonyLib;
using RimWorld;
using Verse;
using System.Reflection;

namespace SaveOnIncident.Patches
{
    public static class StoryStatePatches
    {
        static FieldInfo FticksSinceSave = null;
        //static PropertyInfo FAutosaveIntervalTicks = null;

        public static void DoSave()
        {
            if ((int)FticksSinceSave.GetValue(Current.Game.autosaver) < Settings.tickInterval)
                return;
            //
            //FticksSinceSave.SetValue(Current.Game.autosaver, FAutosaveIntervalTicks.GetValue(Current.Game.autosaver));
            FticksSinceSave.SetValue(Current.Game.autosaver, 0);
            LongEventHandler.QueueLongEvent(new Action(Current.Game.autosaver.DoAutosave), "Autosaving", false, null, true);
        }

        [HarmonyPatch(typeof(StoryState), "Notify_IncidentFired")]
        static class StoryState_Notify_IncidentFired_SaveOnIncidentPatch
        {
            static void Prepare()
            {
                FticksSinceSave = AccessTools.Field(typeof(Autosaver), "ticksSinceSave");
                if (FticksSinceSave == null) throw new Exception("Couldn't get a field Autosaver.ticksSinceSave");

                //FAutosaveIntervalTicks = AccessTools.Property(typeof(Autosaver), "AutosaveIntervalTicks");
                //if (FAutosaveIntervalTicks == null) throw new Exception("Couldn't get a field Autosaver.AutosaveIntervalTicks");
            }

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
