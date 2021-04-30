using ChearYenidenDestekTalebi;
using Rocket.Core;
using Rocket.Unturned.Player;
using System.Linq;

public class Permission
{
    public static bool hasPermission(UnturnedPlayer player, string text)
    {
        if (Main.Instance.Configuration.Instance.PermissionSetting.AllowAdmins)
            return true;

        return R.Permissions.GetPermissions(player).Any(X => X.Name == text); 
    }
}

