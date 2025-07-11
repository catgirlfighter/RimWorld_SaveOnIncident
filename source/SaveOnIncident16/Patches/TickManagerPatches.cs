using HarmonyLib;
using Verse;

namespace SaveOnIncident.Patches
{
    public static class TickManagerPatches
    {
        [HarmonyPatch(typeof(TickManager), "Notify_GeneratedPotentiallyHostileMap")]
        static class StoryState_Notify_IncidentFired_SaveOnIncidentPatch
        {
            internal static void Postfix()
            {
                if(Settings.generatedPotentiallyHostileMap) SaveOnIncident.SetupAutosave();
            }
        }
    }
}
