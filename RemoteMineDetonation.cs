using BepInEx;
using HarmonyLib;

namespace RemoteMineDetonation
{
	[BepInPlugin(PLUGIN_GUID, PLUGIN_NAME, PLUGIN_VERSION)]
	public class Plugin : BaseUnityPlugin
	{
		public const string PLUGIN_GUID = "com.jacksonb-cs.RemoteMineDetonation";
		public const string PLUGIN_NAME = "RemoteMineDetonation";
		public const string PLUGIN_VERSION = "1.0.0";

		private void Awake()
		{
			var harmony = new Harmony(PLUGIN_GUID);
			harmony.PatchAll();

			// Plugin startup logic
			Logger.LogInfo($"Plugin {PLUGIN_NAME} is loaded!");
		}
	}

	// Replaces the result of "toggling" a landmine with its detonation.
	//
	// Essentially, anytime the method to turn the landmine off is invoked (such as
	// when a player executes the corresponding ship terminal command), the method
	// to detonate the landmine is immediately invoked.
	[HarmonyPatch(typeof(Landmine))]
	[HarmonyPatch(nameof(Landmine.ToggleMine))]
	public class LandmineTogglePatch
	{
		[HarmonyPrefix]
		public static void Prefix(Landmine __instance)
		{
			__instance.TriggerMineOnLocalClientByExiting();
		}
	}
}
