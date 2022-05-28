using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string SuccessAdd = "Ekleme Başarılı";
        public static string SuccessDelete = "Silme Başarılı";
        public static string FailDelete = "Silme Başarısız";
        public static string SuccessUpdate = "Güncelleme Başarılı";
        public static string SuccessGet = "Listeleme Başarılı";
        public static string AuthorizationDenied = "Yetkisiz işlem";
        public static string AccessTokenCreated = "Token Başarıyla Oluşturuldu";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string TvNotFound = "Yanlış işlem";
        public static string WrongPassword = "Kullanıcı adı veya parola yanlış";
        public static string SuccessfulLogin = "Giriş Başarılı";
        public static string AlreadyUserExists = "Böyle bir kullanıcı zaten var";
        public static string SuccessfulRegister = "Kayıt işlemi başarılı";
        public static string CreateUserAddress = "Adres başarıyla oluşturuldu";
        public static string DeleteUserAddress = "Adres başarıyla silindi";
        public static string UpdateUserAddress = "Adres başarıyla güncellendi";
        public static string UpdateCreditCard = "Kredi kartı başarıyla güncellendi";
        public static string DeleteUserCreditCard = "Kredi kartı başarıyla silindi";
        public static string AddUserCreditCard = "Kredi kartı başarıyla eklendi";
        public static string UploadImage = "Başarıyla Yüklendi";
        public static string IsMainExists = "Is Main zaten mevcut lütfen işareti kaldırıp yükleyiniz";
        public static string ProductAlreadyExists = "Böyle bir ürün zaten var";
        public static string SuccessfulChangePassword = "Parola başarıyla sıfırlandı";
        public static string SuccessfulUserUpdate = "Başarıyla Güncellendi";
        public static string OrderIsNotFound = "Sipariş Bulunamadı";
        public static string CardIsNotFound = "Kredi Kartı Bulunamadı";
        public static string AddressIsNotFound = "Adres Bulunamadı";
        public static string CityIsNotFound = "Şehir Bulunamadı";
        public static string RoleNotFound = "Rol Bulunamadı";
        public static string DontChangeAdminRole = "Admin Rolü Değiştirilemez";
        public static string UserAddressMaximumCount6 = "En fazla 6 tane adres eklenebilir";
        public static string TvStock0 = "Bu televizyonda stok kalmamış!";
        public static string SuccessOrder = "Siparişiniz başarıyla alınmıştır.";
    }
}
