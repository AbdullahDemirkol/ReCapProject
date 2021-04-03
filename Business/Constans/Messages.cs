using Entities.Concrate;
using Entities.DTOs;
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
        internal static string CarsSuccessListed = "Arabalar listelendi.";
        internal static string CarDetailsSuccessListed = "Arabaların detayları listelendi.";
        internal static string SelectedBrandListed = "Seçilen markaya sahip arabalar listelendi.";
        internal static string SelectedColorListed= "Seçilen renge sahip arabalar listelendi.";
        internal static string SuccessRemoveCar = "Araba silindi.";
        internal static string SuccesUpdateCar="Araba güncellendi.";
        internal static string ErrorUpdateCar="Araba güncellenemedi.";
        internal static string CarBrandListedNull="Markaya ait arabalar bulunmamaktadır.";
        internal static string CarColorListedNull="Renge ait arabalar bulunmamaktadır.";
        internal static string CarsErrorListed="Arabalar bulunmamaktadır.";
        internal static string CarDetailsErrorListed="Araba detayları bulunmamaktadır.";

        internal static string RentalSuccessAdded="Kiralama eklendi.";
        internal static string RentalSuccessUpdated="Kiralama güncellendi.";
        internal static string RentalSuccessDeleted="Kiralama silindi.";
        internal static string RentalDetailSuccessListed="Kiralama detayları listelendi.";
        internal static string RentalSuccessListed="Kiralamalar listelendi.";
        internal static string RentalErrorAdded="Kiralama bilgileri eksik.";
        internal static string RentalErrorUpdated="Kiralama bilgileri hatalı.";
        internal static string RentalErrorDeleted="Kiralama silinemedi.";
        internal static string RentalErrorListed="Kiralama bulunamadı.";
        internal static string RentalDetailErrorListed="Kiralama detayları bulunamadı.";


        internal static string UserSuccessAdded = "Kullanıcı eklendi.";
        internal static string UserSuccessDeleted = "Kullanıcı silindi.";
        internal static string UserSuccessUpdated = "Kullanıcı güncellendi.";
        internal static string UserSuccessGetById = "Verilen Id'ye ait kullanıcı bulundu.";
        internal static string UserSuccessListed="Kullanıcılar listelendi.";
        internal static string UserErrorAdded = "Kullanıcı eklenemedi.";
        internal static string UserErrorDeleted = "Kullanıcı silinemedi.";
        internal static string UserErrorUpdated = "Kullanıcı güncellenemedi.";
        internal static string UserErrorGetById="Verilen Id'ye ait kullanıcı bulunamadı.";
        internal static string UserErrorListed="Kullanıcılar listelenemedi.";


        internal static string CustomerSuccessAdded="Sirket eklendi.";
        internal static string CustomerSuccessDeleted="Sirket silindi";
        internal static string CustomerSuccessUpdated="Sirket güncellendi";
        internal static string CustomerSuccessGetByUserId ="Verilen kullanıcı Id'sine göre sirket bulundu";
        internal static string CustomerDetailsSuccessListed = "Sirketler listelendi";
        internal static string CustomerErrorAdded = "Sirket eklenemedi.";
        internal static string CustomerErrorDeleted = "Sirket silinemedi.";
        internal static string CustomerErrorUpdated = "Sirket güncellenemedi.";
        internal static string CustomerErrorGetByUserId= "Verilen kullanıcı Id'sine göre sirket bulunamadı";
        internal static string CustomerDetailsErrorListed="Sirket bulunmamaktadır.";


        internal static string ColorSuccessAdded="Renk eklendi.";
        internal static string ColorSuccessDeleted="Renk silindi.";
        internal static string ColorSuccessUpdated = "Renk güncellendi.";
        internal static string ColorSuccessListed = "Renkler listelendi.";
        internal static string ColorSuccessGetById = "Istenilen renk getirildi.";
        internal static string ColorErrorListed="Renkler listelenemedi.";
        internal static string ColorErrorAdded="Renk bilgileri hatalı olduğu için kaydedilmedi.";
        internal static string ColotErrorGetById="Istenilen renk bulunmamaktadır.";
        internal static string ColorErrorUpdated="Renk bilgileri hatalı olduğu için güncellenemedi.";


        internal static string BrandSuccessAdded="Marka eklendi.";
        internal static string BrandSuccessDeleted="Marka silindi.";
        internal static string BrandSuccessUpdated="Marka güncellendi.";
        internal static string BrandSuccessListed = "Markalar listelendi.";
        internal static string BrandSuccessGetById = "Istenilen marka getirildi.";
        internal static string BrandErrorAdded = "Marka bilgileri hatalı olduğu için kaydedilemedi.";
        internal static string BrandErrorGetById = "Istenilen marka bulunmamaktadır.";
        internal static string BrandErrorListed = "Markalar listelenemedi.";
        internal static string BrandErrorUpdated="Marka bilgileri hatalı olduğu için güncellenemedi.";

    }
}
