using System.Xml.Serialization;

public class EffectButtonsModel
{
    [XmlElement("Bug")]
    public string BugName { get; set; }

    [XmlElement("Genel")]
    public string QuestionName { get; set; }

    [XmlElement("Hile")]
    public string CheatingName { get; set; }

    [XmlElement("Hakaret")]
    public string InsultingName { get; set; }

    [XmlElement("Diğer")]
    public string OtherName { get; set; }

    public string ExitName { get; set; }

    [XmlElement("Yazı_Kutusu")]
    public string ReportBoxName { get; set; }
}

