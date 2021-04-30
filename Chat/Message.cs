using ChearYenidenDestekTalebi;
using Rocket.Unturned.Player;
using SDG.Unturned;
using UnityEngine;

public class Message
{
    public static void Send(UnturnedPlayer player, string key) => ChatManager.serverSendMessage($"{Main.Instance.Translate("Title").Replace("{", "<").Replace("}", ">")} {Main.Instance.Translate(key).Replace("{", "<").Replace("}", ">")}", Color.green, null, player.SteamPlayer(), EChatMode.SAY, null, true);
    public static void Send(UnturnedPlayer player, string key, string oldValue, string newValue) => ChatManager.serverSendMessage($"{Main.Instance.Translate("Title").Replace("{", "<").Replace("}", ">")} {Main.Instance.Translate(key).Replace(oldValue, newValue).Replace("{", "<").Replace("}", ">")}", Color.green, null, player.SteamPlayer(), EChatMode.SAY, null, true);
}

