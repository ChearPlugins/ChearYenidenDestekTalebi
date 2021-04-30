using ChearYenidenDestekTalebi;
using Rocket.Unturned.Player;
using SDG.Unturned;

public class SupportUI
{
    public static void Send(UnturnedPlayer player)
    {
        player.Player.enablePluginWidgetFlag(EPluginWidgetFlags.Modal);
        
        EffectManager.sendUIEffect(Main.Instance.Configuration.Instance.EffectSettings.Id, 1200, Provider.findTransportConnection(player.CSteamID), true);
    }

    public static void Close(UnturnedPlayer player)
    {
        player.Player.disablePluginWidgetFlag(EPluginWidgetFlags.Modal);
        EffectManager.askEffectClearByID(Main.Instance.Configuration.Instance.EffectSettings.Id, Provider.findTransportConnection(player.CSteamID));

    }

    public static void Sound(UnturnedPlayer player, SoundType type)
    {
        var SoundIds = Main.Instance.Configuration.Instance.EffectSettings.effectSoundsModel;

        if (SoundType.Getting == type)
            EffectManager.sendUIEffect(SoundIds.GettingId, 1201, Provider.findTransportConnection(player.CSteamID), true);
        else if (SoundType.Sending == type)
            EffectManager.sendUIEffect(SoundIds.SendingId, 1202, Provider.findTransportConnection(player.CSteamID), true);
    }
}

