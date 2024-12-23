using System;
using BepInEx;
using BepInEx.Logging;
using BepInEx.Unity.IL2CPP;
using MLCore = MelonLoader.Core;


namespace BepInEx.MelonLoader.Loader.IL2CPP
{
    [BepInPlugin(MyPluginInfo.PLUGIN_GUID, MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BasePlugin
    {
        public override void Load()
        {
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                if (args.Name.Contains("MelonLoader"))
                    return typeof(MLCore).Assembly;
                return null;
            };

            MLCore.Initialize(Config, false);
            MLCore.PreStart();
            MLCore.Start();
        }
    }
}