using ChearYenidenDestekTalebi;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;
using System.Linq;

public class SupportManager
{


    private static List<SupportData> SupportList = new List<SupportData>();

    public static void Add(UnturnedPlayer player, SupportType type, string text)
    {
        SupportList.Add(new SupportData(player, type, text));

        foreach (var Admin in Provider.clients)
            if (Permission.hasPermission(UnturnedPlayer.FromSteamPlayer(Admin), Main.Instance.Configuration.Instance.PermissionSetting.permissionsConfig.CommandNotification))
            {
                var AdminToPlayer = UnturnedPlayer.FromSteamPlayer(Admin);

                if (AdminToPlayer.CSteamID != player.CSteamID)
                {
                    SupportUI.Sound(AdminToPlayer, SoundType.Sending);
                    Message.Send(AdminToPlayer, "SendingNotification", "{Player}", player.CharacterName);
                }
            }
                
    }

    public static void Del(UnturnedPlayer player)
    {
        if (SupportList.Any(X => X.unturnedPlayer.CSteamID == player.CSteamID))
            SupportList.Remove(SupportList[SupportList.IndexOf(SupportList.Where(X => X.unturnedPlayer.CSteamID == player.CSteamID).FirstOrDefault())]);
    }

    public static SupportData Get(UnturnedPlayer player) => SupportList[SupportList.IndexOf(SupportList.Where(X => X.unturnedPlayer.CSteamID == player.CSteamID).FirstOrDefault())];

    public static bool Has(UnturnedPlayer player) => SupportList.Any(X => X.unturnedPlayer.CSteamID == player.CSteamID);

    public static int Count { get => SupportList.Count;}

    public static List<SupportData> List = SupportList;

}

