using System.Reflection;
using Verse;

namespace RunandHide;

[StaticConstructorOnStartup]
public static class RunandHideBase
{
    static RunandHideBase()
    {
        new HarmonyLib.Harmony("Mlie.RunandHide").PatchAll(Assembly.GetExecutingAssembly());
    }
}