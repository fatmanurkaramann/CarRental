using Core.Concrete.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = "Araba eklendi";
        public static string CarNameInvalid = "Araba ismi geçersiz!";
        public static string MaintenanceTime = "sistem bakımda!";
        public static string CarsListed = "ürünler listelendi";
        public static string CarDeleted = "araba silindi";
        public static string CarUpdated = "araba güncellendi";
        public static string CustomerAdded = "Müşteri eklendi";
        public static string CustomerNameInvalid = "Müsteri ismi geçersiz";
        public static string RentedCar = "Araba kiralandı";
        public static string UserAdded = "Kullanıcı eklendi";
        public static string UserDeleted = "Kullanıcı silindi";
        public static string ImageCountError="Resim ekleme başarısız!";
        public static string CarImageAdded="Araba resmi eklendi!";
        public static string UserNotFound="Kullanıcı bulunamadı.";

        public static string UserRegistered = "Kullanıcı başarıyla kaydedildi";
        public static string PasswordError="Şifre hatalı!";

        public static string SuccessfulLogin = "Giriş başarılı";
        public static string UserAlreadyExists = "Kullanıcı mevcut!";
        public static string AccessTokenCreated = "Token olusturuldu.";

        public static string AuthorizationDenied = "Yetkilendirme reddedildi.";
        public static string RentalsListed = "Kiralama bilgileri listelendi.";
    }
}
