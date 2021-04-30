using System.Xml.Serialization;

public class PermissionConfig
{
    [XmlAttribute("Adminlere_İzin_Ver")]
    public bool AllowAdmins { get; set; }

    [XmlElement("Komut_Yetkileri")]
    public PermissionsConfig permissionsConfig = new PermissionsConfig();
}

