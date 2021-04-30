using System.Xml.Serialization;

public class EffectSoundsModel
{
    [XmlElement("Geldiğinde")]
    public ushort GettingId { get; set; }

    [XmlElement("Gittiğinde")]
    public ushort SendingId { get; set; }
}

