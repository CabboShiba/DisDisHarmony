using HarmonyLib;
using System;
using System.Runtime.InteropServices;

namespace DisDisHarmony.Patch
{
    internal class Hook
    {
        [HarmonyPatch(typeof(Marshal), nameof(Marshal.ReadByte), new[] {typeof(IntPtr)})]
        class HookMarshal
        {
            static bool Prefix(IntPtr ptr, ref byte __result)
            {
                try
                {
                    __result = 0;
                }
                catch(Exception ex)
                {
                    Program.Log("Error: " + ex.Message, "ERROR", ConsoleColor.Red);
                }
                return false;
            }
        }
    }
}
