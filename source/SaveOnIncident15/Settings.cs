using UnityEngine;
using Verse;

namespace SaveOnIncident
{
    public class Settings : ModSettings
    {
        public static bool threatBig;
        public static bool deepDrillInfestation;
        public static bool diseaseHuman;
        //public static bool diseaseAnimal;
        public static bool threatSmall;
        //public static bool factionArrival;
        //public static bool orbitalVisitor;
        //public static bool shipChunkDrop;
        public static bool giveQuest;
        //public static bool allyAssistance;
        public static bool special;
        public static bool misc;
        public static bool generatedPotentiallyHostileMap;
        public static bool saveAfterColonistDeath;
        public static bool saveAfterColonyAnimalDeath;
        public const int tickInterval = 1000;

        public static void DoSettingsWindowContents(Rect inRect)
        {
            Listing_Standard listing_Standard = new Listing_Standard();
            listing_Standard.Begin(inRect);
            listing_Standard.Label("minimumTickNotice".Translate(tickInterval));
            listing_Standard.CheckboxLabeled("threatBig".Translate(), ref threatBig, "threatBig".Translate());
            listing_Standard.CheckboxLabeled("deepDrillInfestation".Translate(), ref deepDrillInfestation, "deepDrillInfestation".Translate());
            listing_Standard.CheckboxLabeled("diseaseHuman".Translate(), ref diseaseHuman, "diseaseHuman".Translate());
            //listing_Standard.CheckboxLabeled("diseaseAnimal".Translate(), ref diseaseAnimal, "diseaseAnimal".Translate());
            listing_Standard.CheckboxLabeled("threatSmall".Translate(), ref threatSmall, "threatSmall".Translate());
            //listing_Standard.CheckboxLabeled("factionArrival".Translate(), ref factionArrival, "factionArrival".Translate());
            //listing_Standard.CheckboxLabeled("orbitalVisitor".Translate(), ref orbitalVisitor, "orbitalVisitor".Translate());
            //listing_Standard.CheckboxLabeled("shipChunkDrop".Translate(), ref shipChunkDrop, "shipChunkDrop".Translate());
            listing_Standard.CheckboxLabeled("giveQuest".Translate(), ref giveQuest, "giveQuest".Translate());
            //listing_Standard.CheckboxLabeled("allyAssistance".Translate(), ref allyAssistance, "allyAssistance".Translate());
            listing_Standard.CheckboxLabeled("misc".Translate(), ref misc, "misc".Translate());
            listing_Standard.CheckboxLabeled("special".Translate(), ref special, "special".Translate());
            listing_Standard.CheckboxLabeled("generatedPotentiallyHostileMap".Translate(), ref generatedPotentiallyHostileMap, "generatedPotentiallyHostileMap".Translate());
            listing_Standard.CheckboxLabeled("saveAfterColonistDeath".Translate(), ref saveAfterColonistDeath, "saveAfterColonistDeath".Translate());
            listing_Standard.CheckboxLabeled("saveAfterColonyAnimalDeath".Translate(), ref saveAfterColonyAnimalDeath, "saveAfterColonyAnimalDeath".Translate());
            listing_Standard.End();
        }

        public override void ExposeData()
        {
            base.ExposeData();
            Scribe_Values.Look(ref threatBig, "threatBig", true, false);
            Scribe_Values.Look(ref deepDrillInfestation, "deepDrillInfestation", true, false);
            Scribe_Values.Look(ref diseaseHuman, "diseaseHuman", true, false);
            //Scribe_Values.Look(ref diseaseAnimal, "diseaseAnimal", true, false);
            Scribe_Values.Look(ref threatSmall, "threatSmall", false, false);
            //Scribe_Values.Look(ref factionArrival, "factionArrival", false, false);
            //Scribe_Values.Look(ref orbitalVisitor, "orbitalVisitor", false, false);
            //Scribe_Values.Look(ref shipChunkDrop, "shipChunkDrop", false, false);
            Scribe_Values.Look(ref giveQuest, "giveQuest", false, false);
            //Scribe_Values.Look(ref allyAssistance, "allyAssistance", false, false);
            Scribe_Values.Look(ref special, "special", false, false);
            Scribe_Values.Look(ref misc, "misc", false, false);
            Scribe_Values.Look(ref generatedPotentiallyHostileMap, "generatedPotentiallyHostileMap", true, false);
            Scribe_Values.Look(ref saveAfterColonistDeath, "saveAfterColonistDeath", false, false);
            Scribe_Values.Look(ref saveAfterColonyAnimalDeath, "saveAfterColonyAnimalDeath", false, false);
        }
    }
}
