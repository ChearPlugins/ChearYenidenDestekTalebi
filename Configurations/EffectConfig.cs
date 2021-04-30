using System.Xml.Serialization;

public class EffectModel
{
    [XmlAttribute]
    public ushort Id { get; set; }

    [XmlElement("En_Az_Yazı_Yazma_Sınırı")]
    public ushort MinimumTextLimit { get; set; }

    [XmlElement("Butonlar")]
    public EffectButtonsModel effectButtonsModel = new EffectButtonsModel();

    [XmlElement("Sesler")]
    public EffectSoundsModel effectSoundsModel = new EffectSoundsModel();
}
