using Rocket.Unturned.Player;

public class SupportData
{
    public UnturnedPlayer unturnedPlayer { get; set; }
    public SupportType supportType { get; set; }
    public string supportText { get; set; }

    public SupportData() { }

    public SupportData(UnturnedPlayer uPlayer, SupportType sType, string sText)
    {
        unturnedPlayer = uPlayer;
        supportType = sType;
        supportText = sText;
    }
}

