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
        public static string SuccessUpdate = "Güncelleme Başarılı";
        public static string SuccessGet = "Listeleme Başarılı";

        public static string AuthorizationDenied = "Yetkisiz işlem";
        public static string AccessTokenCreated = "Token Başarıyla Oluşturuldu";


        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string WrongPassword = "Kullanıcı adı veya parola yanlış";
        public static string SuccessfulLogin = "Giriş Başarılı";

        public static string AlreadyUserExists = "Böyle bir kullanıcı zaten var";
        public static string SuccessfulRegister = "Kayıt işlemi başarılı";
    }
}
