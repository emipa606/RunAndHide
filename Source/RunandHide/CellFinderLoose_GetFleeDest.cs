using HarmonyLib;
using RimWorld;
using Verse;
using Verse.AI;

namespace RunandHide.Harmony;

[HarmonyPatch(typeof(CellFinderLoose), nameof(CellFinderLoose.GetFleeDest))]
public static class CellFinderLoose_GetFleeDest
{
    public static bool Prefix(ref IntVec3 __result, Pawn pawn)
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