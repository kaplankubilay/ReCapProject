using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Urun eklendi.";
        public static string BrandAdded = "Marka eklendi";
        public static string FaultEntry = "Hatali giris.";
        public static string BrandUpdate = "Marka guncellendi.";
        public static string BrandDeleted = "Marka silindi.";
        public static string CarAdded = "Araç eklendi";
        public static string CarUpdated = "Araç güncellendi.";
        public static string CarDeleted = "Araç silindi.";
        public static string ColorUpdate = "Renk güncellendi.";
        public static string ColorAdded = "Renk eklendi.";
        public static string ColorDeleted = "Renk silindi";
        public static string FuelAdded = "Yakıt tipi eklendi.";
        public static string FuelUpdated = "Yakıt tipi güncellendi.";
        public static string FuelDeleted = "Yakıt tipi silindi.";
        public static string CustomerUpdated = "Müsteri güncellendi.";
        public static string CustomerAdded = "Müşteri eklendi.";
        public static string CustomerDeleted = "Müşteri silindi.";
        public static string RentalControlMessage = "Araç henüz dönüş yapmadı.";


        public static string Error = "Hata";
        public static string Success = "İşlem başarılı.";
        public static string AlreadyAxistPropertyName = "Eklenmeye çalışılan isim zaten mevcut.";
        public static string LenghtMinControl = "En az 2 karakter olmalı.";
        public static string NameLenghtControl = "İsim 2 karakterdeN az olamaz";
        public static string CarNotReturnYet = "Araç henüz dönmedi.";

        public static string AuthorizationDenied = "Gecersiz kullanıcı.";
        public static string UserRegistered = "Kullanıcı kaydedildi.";
        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string PasswordError = "Parola Hatası.";
        public static string SuccessfulLogin = "Giriş başarılı.";
        public static string UserAlreadyExists = "Kullanıcı zaten var";
        public static string AccessTokenCreated = "Token oluşturuldu.";
    }
}
