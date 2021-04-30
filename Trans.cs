using Rocket.API.Collections;

public class Trans
{
    public static TranslationList list = new TranslationList()
    {
        {"Title", "{color=orange}[DestekTalebi]{/color}" },
        {"NotPermission", "{color=red}Bunun için gerekli izne sahip değilsiniz.{/color}"},
        {"HasSupport", "{color=red}Zaten bir destek talebiniz bulunmaktadır.{/color}"},
        {"TextBoxIsEmpty", "{color=red}Kutunun içi boş olduğu için destek talebi gönderilemiyor.{/color}"},
        {"MinimumTextLimit", "{color=red}Kutunun içinde en kısa {MinimumTextLimit} haneli yazı yazabilirsiniz.{/color}"},
        {"GoArgsNull", "{color=red}Bir oyuncunun ismini girmek zorundasınız.{/color}"},
        {"NoActiveSupport", "{color=red}Şuan aktif bir destek talebi bulunmamaktadır.{/color}"},
        {"HasNotPlayer", "{color=red}Girdiğiniz oyuncunun destek talebi bulunmamaktadır.{/color}"},
        {"NoPlayerFound", "{color=red}Böyle bir oyuncu sunucu bulunamamaktadır.{/color}"},
        {"RemovePlayerSupport", "{color=yellow}{Player}{/color} {color=white}adlı kişinin destek talebi kaldırıldı.{/color}"},
        {"SendingNotification", "{color=yellow}{Player}{/color} {color=white}adlı kişi destek talebi açtı.{/color}"},
        {"GettingNotification", "{color=yellow}{Player}{/color} {color=white}adlı yetkili destek talebinize geldi.{/color}"}
        
    };
}

