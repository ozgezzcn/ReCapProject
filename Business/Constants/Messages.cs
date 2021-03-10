using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string AddedCar = "Araç Sisteme Başarılı Bir Şekilde Eklendi.";
        public static string DeletedCar = "Araç Sistemden Başarılı Bir Şekilde Silindi.";
        public static string UpdatedCar = "Araç Başarılı Bir Şekilde Sistemde Güncellendi.";
        public static string FailedCarAddOrUpdate = "Lütfen Günlük Fiyat Bölümünü Sıfırdan Büyük Giriniz!";

        public static string AddedBrand =   "Marka Sisteme Başarılı Bir Şekilde Eklendi.";
        public static string DeletedBrand = " Marka Sistemden Başarılı Bir Şekilde Silindi.";
        public static string UpdatedBrand = "Marka Başarılı Bir Şekilde Sistemde Güncellendi.";
        public static string FailedBrandAddOrUpdate = "Lütfen Marka Adının Uzunluğunu İki Karakterden Fazla Giriniz! ";

        public static string AddedColor = "Renk Sisteme Başarılı Bir Şekilde Eklendi.";
        public static string DeletedColor = " Renk Sistemden Başarılı Bir Şekilde Silindi.";
        public static string UpdatedColor = "Renk Başarılı Bir Şekilde Sistemde Güncellendi.";

        public static string AddedCustomer = "Müşteri Sisteme Başarılı Bir Şekilde Eklendi.";
        public static string DeletedCustomer = " Müşteri Sistemden Başarılı Bir Şekilde Silindi.";
        public static string UpdatedCustomer = "Müşteri Başarılı Bir Şekilde Sistemde Güncellendi.";

        public static string AddedRental = "Araç Kiralama İşleminiz Başarılı Bir Şekilde Gerçekleşmiştir.";
        public static string DeletedRental = "Araç Kiralama İşleminiz İptal Edilmiştir.";
        public static string UpdatedRental = "Araç Kiralama İşleminiz Güncellendi.";
        public static string FailedRentalAddOrUpdate = "Bu Araç Henüz Teslim Edilmemiştir! Bu Nedenle Kiralayamazsınız.";
        public static string ReturnedRental = "Kiraladığınız Araç Teslim Edilmiştir.";

        public static string AddedUser = "Kullanıcı Sisteme Başarılı Bir Şekilde Eklendi.";
        public static string DeletedUser = "Kullanıcı Başarılı Bir Şekilde Silindi.";
        public static string UpdatedUser = "Kullanıcı Başarılı Bir Şekilde Güncellendi.";

        public static string AddedCarImage = "Araç İçin Yüklenen Resim Başarılı Bir Şekilde Sisteme Eklendi.";
        public static string DeletedCarImage = "Aracın Resmi Başarılı Bir Şekilde Sistemden Silindi.";
        public static string UpdatedCarImage = "Araç İçin Yüklenen Resim Başarılı Bir Şekilde Sistemde Güncellendi.";
        public static string FailedCarImageAdd = "Bir Araç 5'den Fazla Resime Sahip Olamaz.";

        public static string AuthorizationDenied= "Yetkiniz Yok";
        public static string UserRegistered = "Kayıt oldu.";

        public static string UserNotFound = "Kullanıcı bulunamadı.";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı";
        public static string PasswordError = "Parola hatası!";
        public static string UserAlreadyExists = "Kullanıcı mevcut!";
        public static string AccessTokenCreated = "Token oluşturuldu.";
    }
}
