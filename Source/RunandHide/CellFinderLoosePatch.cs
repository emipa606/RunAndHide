using System.Collections.Generic;
using HarmonyLib;
using Verse;
using Verse.AI;

namespace RunandHide.Harmony
{
    [HarmonyPatch(typeof(CellFinderLoose), "GetFleeDestToolUser")]
    public static class CellFinderLoosePatch
    {
        [HarmonyPrefix]
        public static bool GetFleeDestToolUserPatch(ref IntVec3 __result, Pawn pawn, List<Thing> threats,
            float distance)
        {
            if (!pawn.IsColonist)
            {
                return true;
            }

            var closestBunkerSpot = GenClosest.ClosestThingReachable(pawn.Position, pawn.Map,
                ThingRequest.ForDef(ThingDefOfRunandHide.BunkerSpot), PathEndMode.OnCell, TraverseParms.For(pawn));
            if (closestBunkerSpot == null)
            {
                return true;
            }

            __result = closestBunkerSpot.Position;
            return false;
        }
    }
}