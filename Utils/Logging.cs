using System.Collections.Generic;
using static UnityModManagerNet.UnityModManager.ModEntry;


/* Taken directly from CharacterOptionsPlus. See: https://github.com/WittleWolfie/CharacterOptionsPlus */
/* Credit goes to WittleWolfie */
namespace AddedFeats.Utils
{
    internal static class Logging
    {
        private const string BaseChannel = "AF";

        private static readonly Dictionary<string, ModLogger> Loggers = new();

        internal static ModLogger GetLogger(string channel)
        {
            if (Loggers.ContainsKey(channel))
            {
                return Loggers[channel];
            }
            var logger = new ModLogger($"{BaseChannel}+{channel}");
            Loggers[channel] = logger;
            return logger;
        }
    }
}