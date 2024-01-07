using BepInEx;

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
			// Plugin startup logic
			Logger.LogInfo($"Plugin {PLUGIN_GUID} is loaded!");
		}
	}
}
