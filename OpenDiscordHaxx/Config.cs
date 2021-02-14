using Newtonsoft.Json;
using System;
using System.IO;

namespace DiscordHaxx
{
    public class Config
    {
        [JsonProperty("enable_gateway")]
        public bool EnableGateway { get; private set; }


        [JsonProperty("gateway_cap")]
        public int GatewayCap { get; private set; }

        public Config()
        {
            File.WriteAllText("Config.json", JsonConvert.SerializeObject(this));
        }
        
        [JsonConstructor]
        [Obsolete("This is not meant to be called, its just here to troll the deserializer so it doesnt create the config file twice bc i cba to fucking make an if statement", true)]
        public Config(bool we_do_a_little_trolling)
        {}
    }
}
