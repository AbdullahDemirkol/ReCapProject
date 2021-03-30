using Entities.Concrate;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        internal static string MaintenanceTime = "Bakım zamanı.";

        internal static string ErrorAddCar= "Arabanın modeli veya fiyatı hatalı girildi. Databaseye kaydedilmedi.";
        internal static string SuccesAddCar = "Araba eklendi.";
        internal static string CarsListed = "Arabalar listelendi.";
        internal static string CarsDetailListed = "Arabaların detayları listelendi.";
        internal static string SelectedBrandListed = "Seçilen markaya sahip arabalar listelendi.";
        internal static string SelectedColorListed= "Seçilen renge sahip arabalar listelendi.";
        internal static string SuccessRemoveCar = "Araba silindi.";

        internal static string RentalSuccessAdded="Kiralama eklendi.";
        internal static string RentalSuccessUpdated="Kiralama güncellendi.";
        internal static string RentalSuccessDeleted="Kiralama silindi.";
        internal static string RentalDetailListed="Kiralama detayları listelendi.";
        internal static string RentalListed="Kiralamalar listelendi.";
        internal static string RentalErrorAdded="Kiralama eklenemedi.";
        internal static string RentalErrorUpdated="Kiralama güncellenemedi.";
        internal static string RentalErrorDeleted="Kiralama silinemedi.";


        internal static string UserSuccessAdded = "Kullanıcı eklendi.";
        internal static string UserSuccessDeleted = "Kullanıcı silindi.";
        internal static string UserSuccessUpdated = "Kullanıcı güncellendi.";
        internal static string UserSuccessGetById = "Verilen Id'ye ait kullanıcı bulundu.";
        internal static string UserListed="Kullanıcılar listelendi.";
        internal static string UserErrorAdded = "Kullanıcı eklenemedi.";
        internal static string UserErrorDeleted = "Kullanıcı silinemedi.";
        internal static string UserErrorUpdated = "Kullanıcı güncellenemedi.";
        internal static string UserErrorGetById="Verilen Id'ye ait kullanıcı bulunamadı.";


        internal static string CustomerSuccessAdded="Sirket eklendi.";
        internal static string CustomerSuccessDeleted="Sirket silindi";
        internal static string CustomerSuccessUpdated="Sirket güncellendi";
        internal static string CustomerSuccessGetByUserId ="Verilen kullanıcı Id'sine göre sirket bulundu";
        internal static string CustomerListed="Sirketler listelendi";
        internal static string CustomerErrorAdded = "Sirket eklenemedi.";
        internal static string CustomerErrorDeleted = "Sirket silinemedi.";
        internal static string CustomerErrorUpdated = "Sirket güncellenemedi.";
        internal static string CustomerErrorGetByUserId= "Verilen kullanıcı Id'sine göre sirket bulunamadı";
        
        
        internal static string ColorSuccessAdded="Renk eklendi.";
        internal static string ColorSuccessDeleted="Renk silindi.";
        internal static string ColorErrorListed="Renkler listelenemedi.";
        internal static string ColorSuccessListed="Renkler listelendi.";
        internal static string ColorGetByIdListed="Istenilen renk getirildi.";
        internal static string ColorSuccessUpdated="Renk güncellendi.";
        
        
        internal static string BrandSuccessAdded="Marka eklendi.";
        internal static string BrandSuccessDeleted="Marka silindi.";
        internal static string BrandSuccessUpdated="Marka güncellendi.";
        internal static string BrandErrorListed="Markalar listelenemedi.";
        internal static string BrandSuccessListed="Markalar listelendi.";
        internal static string BrandGetByIdListed="Istenilen marka getirildi.";
    }
}
