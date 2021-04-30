using Rocket.API;
using System.Xml.Serialization;

namespace ChearYenidenDestekTalebi
{
    public class Config : IRocketPluginConfiguration
    {
        [XmlElement("İzin_Ayarları")]
        public PermissionConfig PermissionSetting = new PermissionConfig();

        [XmlElement("Efekt_Ayarları")]
        public EffectModel EffectSettings = new EffectModel();

        public void LoadDefaults()
        {
            PermissionSetting = new PermissionConfig()
            {
                AllowAdmins = false,
                permissionsConfig = new PermissionsConfig()
                {
                    CommandSupport = "chear.destek",

                    CommandList = "chear.destek.liste",

                    CommandGo = "chear.destek.git",

                    CommandRemove = "chear.destek.sil",

                    CommandInformation = "chear.destek.bilgi",

                    CommandNotification = "chear.destek.bildirimler"
                }
            };

            EffectSettings = new EffectModel()
            {
                Id = 1200,
                MinimumTextLimit = 5,
                effectSoundsModel = new EffectSoundsModel()
                {
                    GettingId = 1201,
                    SendingId = 1202
                },
                effectButtonsModel = new EffectButtonsModel()
                {
                    BugName = "BugBildirmeButton",
                    QuestionName = "GenelSoruButton",
                    CheatingName = "HileSikayetButton",
                    InsultingName = "HakaretButton",
                    OtherName = "DigerButton",
                    ReportBoxName = "ReportTextBox"
                }
            };
        }
    }
}
