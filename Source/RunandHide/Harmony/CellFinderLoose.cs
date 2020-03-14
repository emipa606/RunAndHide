using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HarmonyLib;
using Verse;

namespace RunandHide.Harmony
{
    [HarmonyPatch(typeof(CellFinderLoose), "GetFleeDestToolUser")]
    public static class CellFinderLoosePatch
    {
        [HarmonyPrefix]
        public static bool GetFleeDestToolUserPatch(ref IntVec3 __result, Pawn pawn, List<Thing> threats, float distance)
        {
            if(pawn.IsColonist)
            {
                Thing closestBunkerSpot = GenClosest.ClosestThingReachable(pawn.Position, pawn.Map, ThingRequest.ForDef(ThingDefOfRunandHide.BunkerSpot), Verse.AI.PathEndMode.OnCell, TraverseParms.For(pawn, Danger.Deadly, TraverseMode.ByPawn));
                if(closestBunkerSpot != null)
                {
                    __result = closestBunkerSpot.Position;
                    return false;
                }
            }
            return true;
        }
    }
}
