using UnityEngine;
using Verse;
using System.Reflection;

namespace SaveOnIncident
{
    public class Settings : ModSettings
    {
        public static FieldInfo FticksSinceSave = null;
        public static bool threatBig;
        public static bool deepDrillInfestation;
        public static bool diseaseHuman;
        public static bool diseaseAnimal;
        public static bool threatSmall;
        public static bool factionArrival;
        public static bool orbitalVisitor;
        public static bool shipChunkDrop;
        public static bool giveQuest;
        public static bool allyAssistance;
        public static bool misc;
        public static bool generatedPotentiallyHostileMap;

        public static void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            listing_Standard.CheckboxLabeled("threatBig".Translate(), ref threatBig);
            listing_Standard.CheckboxLabeled("deepDrillInfestation".Translate(), ref deepDrillInfestation);
            listing_Standard.CheckboxLabeled("diseaseHuman".Translate(), ref diseaseHuman);
            listing_Standard.CheckboxLabeled("diseaseAnimal".Translate(), ref diseaseAnimal);
            listing_Standard.CheckboxLabeled("threatSmall".Translate(), ref threatSmall);
            listing_Standard.CheckboxLabeled("factionArrival".Translate(), ref factionArrival);
            listing_Standard.CheckboxLabeled("orbitalVisitor".Translate(), ref orbitalVisitor);
            listing_Standard.CheckboxLabeled("shipChunkDrop".Translate(), ref shipChunkDrop);
            listing_Standard.CheckboxLabeled("giveQuest".Translate(), ref giveQuest);
            listing_Standard.CheckboxLabeled("allyAssistance".Translate(), ref allyAssistance);
            listing_Standard.CheckboxLabeled("misc".Translate(), ref misc);
            listing_Standard.CheckboxLabeled("generatedPotentiallyHostileMap".Translate(), ref generatedPotentiallyHostileMap);
            listing_Standard.End();
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref threatBig, "threatBig", true, false);
            Scribe_Values.Look(ref deepDrillInfestation, "deepDrillInfestation", true, false);
            Scribe_Values.Look(ref diseaseHuman, "diseaseHuman", true, false);
            Scribe_Values.Look(ref diseaseAnimal, "diseaseAnimal", true, false);
            Scribe_Values.Look(ref threatSmall, "threatSmall", false, false);
            Scribe_Values.Look(ref factionArrival, "factionArrival", false, false);
            Scribe_Values.Look(ref orbitalVisitor, "orbitalVisitor", false, false);
            Scribe_Values.Look(ref shipChunkDrop, "shipChunkDrop", false, false);
            Scribe_Values.Look(ref giveQuest, "giveQuest", false, false);
            Scribe_Values.Look(ref allyAssistance, "allyAssistance", false, false);
            Scribe_Values.Look(ref misc, "misc", false, false);
            Scribe_Values.Look(ref generatedPotentiallyHostileMap, "generatedPotentiallyHostileMap", true, false);
        }
    }
}
