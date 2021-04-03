using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public class Messages
    {
        public static string CarAdded = "Araç Eklendi";
        public static string CarRented = "O Tarihte Araç Kiralı";
        public static string CarIdInvalid = "Araç id geçersiz";
        public static string MaintenanceTime = "Şu an bakım var";
        public static string CarsListed = "Araçlar listelendi";
        public static string BrandAdded = "Marka Eklendi";
        public static string CarImageIsNotExists = "Resim bulunamadı";
        public static string CarImageLimitExceeded = "Resim sınırına ulaşıldı";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Parola hatalı";
        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı zaten mevcut";
        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string AccessTokenCreated = "Token oluşturuldu";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string CarDeleted = "Araba silindi";
    }
}
