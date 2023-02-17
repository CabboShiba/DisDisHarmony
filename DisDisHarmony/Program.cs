using HarmonyLib;
using System;
using System.IO;
using System.Reflection;

namespace DisDisHarmony
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Title = $"[{DateTime.Now}] DisDisHarmony made by https://github.com/CabboShiba";
                object[] parameters = null;
                var LoadedAssembly = Assembly.LoadFile(Path.GetFullPath(args[0]));
                var paraminfo = LoadedAssembly.EntryPoint.GetParameters();
                parameters = new object[paraminfo.Length];
                Harmony patch = new Harmony("DisDisHarmony_https://github.com/CabboShiba");
                patch.PatchAll(Assembly.GetExecutingAssembly());
                LoadedAssembly.EntryPoint.Invoke(null, parameters);
            }
            catch (Exception ex)
            {
                Log("Error: " + ex.Message, "Error", ConsoleColor.Red);
            }
            Console.ReadLine();
        }


        public static void Log(string Data, string Type, ConsoleColor Color)
        {
            Console.ForegroundColor = Color;
            Console.WriteLine($"[{DateTime.Now.ToString("HH:mm:ss")} - {Type}] {Data}");
            Console.ResetColor();
        }
    }
}
