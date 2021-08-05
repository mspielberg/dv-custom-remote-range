using HarmonyLib;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DvMod.CustomRemoteRange
{
    public static class CustomRemoteRange
    {
        [HarmonyPatch(typeof(LocomotiveRemoteController), nameof(LocomotiveRemoteController.UpdateSignal))]
        public static class UpdateSignalPatch
        {
            private static int GetNormalRange() => Main.settings.normalRange;
            private static int GetExtendedRange() => Main.settings.extendedRange;

            public static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
            {
                foreach (var inst in instructions)
                {
                    if (inst.LoadsConstant(LocomotiveRemoteController.MAX_REGULAR_SIGNAL_DISTANCE))
                        yield return CodeInstruction.Call(typeof(UpdateSignalPatch), nameof(UpdateSignalPatch.GetNormalRange));
                    else if (inst.LoadsConstant(LocomotiveRemoteController.MAX_EXTENDED_SIGNAL_DISTANCE))
                        yield return CodeInstruction.Call(typeof(UpdateSignalPatch), nameof(UpdateSignalPatch.GetExtendedRange));
                    else
                        yield return inst;
                }
            }
        }
    }
}