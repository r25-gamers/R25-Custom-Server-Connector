using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using UnhollowerBaseLib;

namespace R25Server
{ 
    [BepInPlugin("org.bepinex.plugins.R25Server", "R25 Custom Server connector Mod", "1.0.0.0")]
    [BepInProcess("Among Us.exe")]
    public class R25Server : BasePlugin
    {
        private readonly Harmony harmony;
        public static BepInEx.Logging.ManualLogSource log;

        public R25Server()
        {
            log = Log;
            this.harmony = new Harmony("R25 Custom Server connector Mod");
        }

        public override void Load()
        {
            log.LogInfo("R25 Custom Server connector Mod");
            ServerManager serverManager = ServerManager.Instance;
            var defaultRegions = ServerManager.DefaultRegions.ToList();

            defaultRegions.Add(new DnsRegionInfo("45.32.25.27", "R25 Custom Server", StringNames.NoTranslation, "45.32.25.27", 22023)
                .Cast<IRegionInfo>());

            ServerManager.DefaultRegions = defaultRegions.ToArray();
            serverManager.AvailableRegions = defaultRegions.ToArray();

            this.harmony.PatchAll();
        }
    }
}
