using HarmonyLib;
using Verse;

namespace SaveOnIncident
{
    public static class TickManagerPatches
    {
        //[HarmonyPatch(typeof(TickManager), "Notify_GeneratedPotentiallyHostileMap")]
        static class StoryState_Notify_IncidentFired_SaveOnIncidentPatch
        {
            static void Postfix()
            {
                if(Settings.generatedPotentiallyHostileMap) StoryStatePatches.DoSave();
            }
        }
    }
}
