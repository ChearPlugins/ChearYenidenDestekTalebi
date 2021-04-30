using Rocket.API;
using Rocket.Unturned.Player;
using SDG.Unturned;
using System.Collections.Generic;
using System.Linq;

namespace ChearYenidenDestekTalebi.Command
{
    internal class SupportCommand : IRocketCommand
    {
        public AllowedCaller AllowedCaller => AllowedCaller.Player;

        public string Name => "Destek";

        public string Help => "Destek talebi sistemini yönetir.";

        public string Syntax => "Support";

        public List<string> Aliases => new List<string>();

        public List<string> Permissions => new List<string>();

        public void Execute(IRocketPlayer rPlayer, string[] args)
        {
            var uPlayer = (UnturnedPlayer)rPlayer;

            if (!rPlayer.HasPermission(Main.Instance.Configuration.Instance.PermissionSetting.permissionsConfig.CommandSupport))
            {
                Message.Send(uPlayer, "NotPermission");
                return;
            }

            if (args.Length == 0)
            {

                if (SupportManager.Has(uPlayer))
                {
                    Message.Send(uPlayer, "HasSupport");
                    return;
                }

                SupportUI.Send(uPlayer);

            }
            else if (args[0].ToLower() == "liste")
            {
                if (!Permission.hasPermission(uPlayer, Main.Instance.Configuration.Instance.PermissionSetting.permissionsConfig.CommandList))
                {
                    Message.Send(uPlayer, "NotPermission");
                    return;
                }

                if(SupportManager.Count == 0)
                {
                    Message.Send(uPlayer, "NoActiveSupport");
                    return;
                }

                int count = 1;

                ChatManager.serverSendMessage($"<color=orange>[</color><color=yellow>#</color><color=orange>]</color> Destek Talepleri;", UnityEngine.Color.white, null, uPlayer.SteamPlayer(), EChatMode.SAY, null, true);
                foreach (var Support in SupportManager.List)
                {
                    string SupportType = Support.supportType.ToString().Replace("Question", "Genel").Replace("Cheating", "Hile").Replace("Insulting", "Hakaret").Replace("Other", "Diğer");
                    ChatManager.serverSendMessage($"<color=orange>[</color><color=yellow>{count}</color><color=orange>]</color> Oyuncu: <color=green>{Support.unturnedPlayer.CharacterName}</color> <color=orange>|</color> Tür: <color=green>{SupportType}</color>", UnityEngine.Color.white, null, uPlayer.SteamPlayer(), EChatMode.SAY, null, true);
                    count++;
                }
            }
            else if (args[0].ToLower() == "git")
            {
                if (!Permission.hasPermission(uPlayer, Main.Instance.Configuration.Instance.PermissionSetting.permissionsConfig.CommandGo))
                {
                    Message.Send(uPlayer, "NotPermission");
                    return;
                }

                if (args.Length == 1)
                {
                    Message.Send(uPlayer, "GoArgsNull");
                    return;
                }

                var TargetPlayer = UnturnedPlayer.FromName(args[1]);

                if (TargetPlayer == null)
                {
                    Message.Send(uPlayer, "NoPlayerFound");
                    return;
                }

                if (!SupportManager.Has(TargetPlayer))
                {
                    Message.Send(uPlayer, "HasNotPlayer");
                    return;
                }

                var SupportRequest = SupportManager.List[SupportManager.List.IndexOf(SupportManager.List.Where(X=> X.unturnedPlayer.CSteamID == TargetPlayer.CSteamID).FirstOrDefault())];

                uPlayer.Teleport(TargetPlayer);
                SupportManager.List.Remove(SupportRequest);
                SupportUI.Sound(TargetPlayer, SoundType.Getting);
                Message.Send(TargetPlayer, "GettingNotification", "{Player}", uPlayer.CharacterName);
            }
            else if (args[0].ToLower() == "sil")
            {
                if (!Permission.hasPermission(uPlayer, Main.Instance.Configuration.Instance.PermissionSetting.permissionsConfig.CommandRemove))
                {
                    Message.Send(uPlayer, "NotPermission");
                    return;
                }

                if (args.Length == 1)
                {
                    Message.Send(uPlayer, "GoArgsNull");
                    return;
                }

                var TargetPlayer = UnturnedPlayer.FromName(args[1]);

                if (TargetPlayer == null)
                {
                    Message.Send(uPlayer, "NoPlayerFound");
                    return;
                }

                if (!SupportManager.Has(TargetPlayer))
                {
                    Message.Send(uPlayer, "HasNotPlayer");
                    return;
                }

                var SupportRequest = SupportManager.List[SupportManager.List.IndexOf(SupportManager.List.Where(X => X.unturnedPlayer.CSteamID == TargetPlayer.CSteamID).FirstOrDefault())];

                SupportManager.List.Remove(SupportRequest);
                Message.Send(uPlayer, "RemovePlayerSupport", "{Player}", TargetPlayer.CharacterName);
                
            }
            else if (args[0].ToLower() == "bilgi")
            {
                if (!Permission.hasPermission(uPlayer, Main.Instance.Configuration.Instance.PermissionSetting.permissionsConfig.CommandInformation))
                {
                    Message.Send(uPlayer, "NotPermission");
                    return;
                }

                if (args.Length == 1)
                {
                    Message.Send(uPlayer, "GoArgsNull");
                    return;
                }

                var TargetPlayer = UnturnedPlayer.FromName(args[1]);

                if (TargetPlayer == null)
                {
                    Message.Send(uPlayer, "NoPlayerFound");
                    return;
                }

                if (!SupportManager.Has(TargetPlayer))
                {
                    Message.Send(uPlayer, "HasNotPlayer");
                    return;
                }

                var SupportRequest = SupportManager.List[SupportManager.List.IndexOf(SupportManager.List.Where(X => X.unturnedPlayer.CSteamID == TargetPlayer.CSteamID).FirstOrDefault())];

                ChatManager.serverSendMessage($"<color=orange>[</color><color=yellow>Bilgi</color><color=orange>]</color> Oyuncu: <color=green>{SupportRequest.unturnedPlayer.CharacterName}</color> <color=orange>|</color> Tür: <color=green>{SupportRequest.supportType}</color>", UnityEngine.Color.white, null, uPlayer.SteamPlayer(), EChatMode.SAY, null, true);
                string SupportType = SupportRequest.supportType.ToString().Replace("Question", "Genel").Replace("Cheating", "Hile").Replace("Insulting", "Hakaret").Replace("Other", "Diğer");
                ChatManager.serverSendMessage($"<color=orange>[</color><color=yellow>#</color><color=orange>]</color> <color=green>{SupportType}</color>", UnityEngine.Color.white, null, uPlayer.SteamPlayer(), EChatMode.SAY, null, true);
            }
            else
            {
                ChatManager.serverSendMessage($"Kullanım: <color=green>/destek [liste/git/sil/bilgi]</color>", UnityEngine.Color.white, null, uPlayer.SteamPlayer(), EChatMode.SAY, null, true);
            }
        }
    }
}
