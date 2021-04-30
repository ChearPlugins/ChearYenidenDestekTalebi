using Rocket.API.Collections;
using Rocket.Core.Plugins;
using Rocket.Unturned;
using Rocket.Unturned.Player;
using SDG.Unturned;

namespace ChearYenidenDestekTalebi
{
    public class Main : RocketPlugin<Config>
    {
        public static Main Instance;
        protected override void Load()
        {
            Instance = this;
            EffectManager.onEffectButtonClicked += EffectButtonClicked;
            EffectManager.onEffectTextCommitted += EffectTextCommitted;

            U.Events.OnPlayerConnected += Joined;
        }

        protected override void Unload()
        {
            EffectManager.onEffectButtonClicked -= EffectButtonClicked;
            EffectManager.onEffectTextCommitted -= EffectTextCommitted;

            U.Events.OnPlayerConnected -= Joined;
        }

        private void Joined(UnturnedPlayer player)
        {
            DataManager.SetData(ulong.Parse(player.CSteamID.ToString()), "ReportBox", null);
        }

        private void EffectButtonClicked(Player player, string buttonName)
        {
            var ButtonConfig = Configuration.Instance.EffectSettings.effectButtonsModel;
            var uPlayer = UnturnedPlayer.FromPlayer(player);

            var BoxData = DataManager.getData(ulong.Parse(uPlayer.CSteamID.ToString()), "ReportBox", DataType.String);

            if (ButtonConfig.BugName == buttonName || ButtonConfig.CheatingName == buttonName || ButtonConfig.InsultingName == buttonName || ButtonConfig.QuestionName == buttonName || ButtonConfig.OtherName == buttonName)
                if (BoxData != null)
                {
                    if (BoxData.ToString().Replace(" ", null).Length < 5)
                    {
                        Message.Send(uPlayer, "MinimumTextLimit", "{MinimumTextLimit}", Configuration.Instance.EffectSettings.MinimumTextLimit.ToString());
                        return;
                    }

                }
                else
                    return;

            if (ButtonConfig.BugName == buttonName && BoxData != null)
                SupportManager.Add(uPlayer, SupportType.Bug, BoxData.ToString());

            else if (ButtonConfig.CheatingName == buttonName && BoxData != null)
                SupportManager.Add(uPlayer, SupportType.Cheating, BoxData.ToString());

            else if (ButtonConfig.InsultingName == buttonName && BoxData != null)
                SupportManager.Add(uPlayer, SupportType.Insulting, BoxData.ToString());

            else if (ButtonConfig.QuestionName == buttonName && BoxData != null)
                SupportManager.Add(uPlayer, SupportType.Question, BoxData.ToString());

            else if (ButtonConfig.OtherName == buttonName && BoxData != null)
                SupportManager.Add(uPlayer, SupportType.Other, BoxData.ToString());

            SupportUI.Close(uPlayer);
        }

        private void EffectTextCommitted(Player player, string buttonName, string text)
        {
            if (buttonName == Configuration.Instance.EffectSettings.effectButtonsModel.ReportBoxName)
            {
                DataManager.SetData(ulong.Parse(UnturnedPlayer.FromPlayer(player).CSteamID.ToString()), "ReportBox", text);
            }

        }

        public override TranslationList DefaultTranslations => Trans.list;

    }

}
