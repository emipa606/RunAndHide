using System.Collections.Generic;
using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace RunandHide.Harmony;

[HarmonyPatch(typeof(CellFinderLoose), "GetFleeDest")]
public static class CellFinderLoosePatch
{
    [HarmonyPrefix]
    public static bool GetFleeDestToolUserPatch(ref IntVec3 __result, Pawn pawn, List<Thing> threats,
        float distance)
    {
        if (pawn.Faction != Faction.OfPlayer)
        {
            return true;
        }

        var spotType = ThingDefOfRunandHide.BunkerSpot;
        if (pawn.RaceProps.Animal)
        {
            spotType = ThingDefOfRunandHide.AnimalBunkerSpot;
        }

        var closestBunkerSpot = GenClosest.ClosestThingReachable(pawn.Position, pawn.Map,
            ThingRequest.ForDef(spotType), PathEndMode.OnCell, TraverseParms.For(pawn));
        if (closestBunkerSpot == null)
        {
            return true;
        }

        __result = closestBunkerSpot.Position;
        return false;
    }
}