using Core.Entities.Concrete;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        public static string MaintenanceTime = "Bakım zamanı.";

        public static string ErrorAddCar= "Arabanın modeli veya fiyatı hatalı girildi. Databaseye kaydedilmedi.";
        public static string SuccesAddCar = "Araba eklendi.";
        public static string CarsSuccessListed = "Arabalar listelendi.";
        public static string CarDetailsSuccessListed = "Arabaların detayları listelendi.";
        public static string SelectedBrandListed = "Seçilen markaya sahip arabalar listelendi.";
        public static string SelectedColorListed= "Seçilen renge sahip arabalar listelendi.";
        public static string SuccessRemoveCar = "Araba silindi.";
        public static string SuccesUpdateCar="Araba güncellendi.";
        public static string ErrorUpdateCar="Araba güncellenemedi.";
        public static string CarBrandListedNull="Markaya ait arabalar bulunmamaktadır.";
        public static string CarColorListedNull="Renge ait arabalar bulunmamaktadır.";
        public static string CarsErrorListed="Arabalar bulunmamaktadır.";
        public static string CarDetailsErrorListed="Araba detayları bulunmamaktadır.";

        public static string RentalSuccessAdded="Kiralama eklendi.";
        public static string RentalSuccessUpdated="Kiralama güncellendi.";
        public static string RentalSuccessDeleted="Kiralama silindi.";
        public static string RentalDetailSuccessListed="Kiralama detayları listelendi.";
        public static string RentalSuccessListed="Kiralamalar listelendi.";
        public static string RentalErrorAdded="Kiralama bilgileri eksik.";
        public static string RentalErrorUpdated="Kiralama bilgileri hatalı.";
        public static string RentalErrorDeleted="Kiralama silinemedi.";
        public static string RentalErrorListed="Kiralama bulunamadı.";
        public static string RentalDetailErrorListed="Kiralama detayları bulunamadı.";


        public static string UserSuccessAdded = "Kullanıcı eklendi.";
        public static string UserSuccessDeleted = "Kullanıcı silindi.";
        public static string UserSuccessUpdated = "Kullanıcı güncellendi.";
        public static string UserSuccessGetById = "Verilen Id'ye ait kullanıcı bulundu.";
        public static string UserSuccessListed="Kullanıcılar listelendi.";
        public static string UserErrorAdded = "Kullanıcı eklenemedi.";
        public static string UserErrorDeleted = "Kullanıcı silinemedi.";
        public static string UserErrorUpdated = "Kullanıcı güncellenemedi.";
        public static string UserErrorGetById="Verilen Id'ye ait kullanıcı bulunamadı.";
        public static string UserErrorListed="Kullanıcılar listelenemedi.";


        public static string CustomerSuccessAdded="Sirket eklendi.";
        public static string CustomerSuccessDeleted="Sirket silindi";
        public static string CustomerSuccessUpdated="Sirket güncellendi";
        public static string CustomerSuccessGetByUserId ="Verilen kullanıcı Id'sine göre sirket bulundu";
        public static string CustomerDetailsSuccessListed = "Sirketler listelendi";
        public static string CustomerErrorAdded = "Sirket eklenemedi.";
        public static string CustomerErrorDeleted = "Sirket silinemedi.";
        public static string CustomerErrorUpdated = "Sirket güncellenemedi.";
        public static string CustomerErrorGetByUserId= "Verilen kullanıcı Id'sine göre sirket bulunamadı";
        public static string CustomerDetailsErrorListed="Sirket bulunmamaktadır.";


        public static string ColorSuccessAdded="Renk eklendi.";
        public static string ColorSuccessDeleted="Renk silindi.";
        public static string ColorSuccessUpdated = "Renk güncellendi.";
        public static string ColorSuccessListed = "Renkler listelendi.";
        public static string ColorSuccessGetById = "Istenilen renk getirildi.";
        public static string ColorErrorListed="Renkler listelenemedi.";
        public static string ColorErrorAdded="Renk bilgileri hatalı olduğu için kaydedilmedi.";
        public static string ColotErrorGetById="Istenilen renk bulunmamaktadır.";
        public static string ColorErrorUpdated="Renk bilgileri hatalı olduğu için güncellenemedi.";


        public static string BrandSuccessAdded="Marka eklendi.";
        public static string BrandSuccessDeleted="Marka silindi.";
        public static string BrandSuccessUpdated="Marka güncellendi.";
        public static string BrandSuccessListed = "Markalar listelendi.";
        public static string BrandSuccessGetById = "Istenilen marka getirildi.";
        public static string BrandErrorAdded = "Marka bilgileri hatalı olduğu için kaydedilemedi.";
        public static string BrandErrorGetById = "Istenilen marka bulunmamaktadır.";
        public static string BrandErrorListed = "Markalar listelenemedi.";
        public static string BrandErrorUpdated="Marka bilgileri hatalı olduğu için güncellenemedi.";


        public static string CarImageSuccessAdded = "Arabaya resim eklendi.";
        public static string CarImageSuccessDeleted = "Seçilen araba resmi silindi.";
        public static string CarImagedSuccessUpdated = "Seçilen araba resmin güncellendi.";
        public static string CarImageErrorListed = "Araba resimleri listelenemedi.";
        public static string CarImageSuccessListed = "Araba resimleri listelendi.";
        public static string CarImageLimitExceded = "Bu arabaya ait max 5 resim bulunmaktadır.";
        public static string CarImageNotFound="Araba resmi bulunmamaktadır.";
        public static string CarImageErrorGet="Seçilen id'ye ait resim bulunmamaktadır.";
        
        
        public static string UserNotFound="Kullanıcı bulunamadı.";
        public static string PasswordError="Şifre hatalı.";
        public static string SuccesfullLogin="Giriş başarılı.";
        
        
        public static string UserAlreadyExists= "Kullanıcı mevcut.";
        public static string UserRegistered="Kullanıcı başarıyla eklendi.";
        public static string AccessTokenCreated="Access token başarıyla oluşturuldu.";
        public static string AuthorizationDenied= "Yetkiniz yok.";
    }
}
