using HarmonyLib;
using System.Reflection;
using Verse;
using UnityEngine;
using RimWorld;
using System;

namespace SaveOnIncident
{
    [StaticConstructorOnStartup]
    public class SaveOnIncident : Mod
    {
        public static FieldInfo FticksSinceSave = null;
        public static PropertyInfo FAutosaveIntervalTicks = null;

        public SaveOnIncident(ModContentPack content) : base(content)
        {
            FticksSinceSave = AccessTools.Field(typeof(Autosaver), "ticksSinceSave");
            if (FticksSinceSave == null) throw new Exception("Couldn't get a field Autosaver.ticksSinceSave");

            FAutosaveIntervalTicks = AccessTools.Property(typeof(Autosaver), "AutosaveIntervalTicks");
            if (FAutosaveIntervalTicks == null) throw new Exception("Couldn't get a field Autosaver.AutosaveIntervalTicks");
            //
            var harmony = new Harmony("net.avilmask.rimworld.mod.SaveOnIncident");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            GetSettings<Settings>();
        }

        public void Save()
        {
            LoadedModManager.GetMod<SaveOnIncident>().GetSettings<Settings>().Write();
        }

        public override string SettingsCategory()
        {
            return "Save On Incident";
        }

        public override void DoSettingsWindowContents(Rect inRect)
        {
            Settings.DoSettingsWindowContents(inRect);
        }

        public static void SetupAutosave()
        {
            int ticks = (int)FticksSinceSave.GetValue(Current.Game.autosaver);
            int intv = (int)FAutosaveIntervalTicks.GetValue(Current.Game.autosaver);

            if (intv - ticks <= Settings.tickInterval)
            {
                return;
            }

            if (ticks < Settings.tickInterval)
            {
                FticksSinceSave.SetValue(Current.Game.autosaver, intv - Settings.tickInterval);
                return;
            }

            FticksSinceSave.SetValue(Current.Game.autosaver, 0);
            LongEventHandler.QueueLongEvent(new Action(Current.Game.autosaver.DoAutosave), "Autosaving", false, null, true);
        }
    }
}