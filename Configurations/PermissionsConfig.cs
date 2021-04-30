using System.Xml.Serialization;

public class PermissionsConfig
{
    [XmlElement("Destek_Komutu")]
    public string CommandSupport { get; set; }

    [XmlElement("Destek_Liste_Komutu")]
    public string CommandList { get; set; }

    [XmlElement("Destek_Git_Komutu")]
    public string CommandGo { get; set; }

    [XmlElement("Destek_Sil_Komutu")]
    public string CommandRemove { get; set; }

    [XmlElement("Destek_Bilgi_Komutu")]
    public string CommandInformation { get; set; }

    [XmlElement("Destek_Bildirim_Komutu")]
    public string CommandNotification { get; set; }
}

