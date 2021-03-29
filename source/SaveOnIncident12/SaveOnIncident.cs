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
        

        public SaveOnIncident(ModContentPack content) : base(content)
        {
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

    }
}