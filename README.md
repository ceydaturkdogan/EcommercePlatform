# Proje Tanımı
EcommercePlatform, çeşitli ürün ve sipariş verilerini yönetmeyi sağlayan bir ASP.NET Core Web API projesidir. Kullanıcılar, bu platform aracılığıyla sipariş bilgilerini görüntüleme, düzenleme, ekleme ve silme gibi CRUD işlemlerini yapabilirler.

## Özellikler
Veri Listeleme: Mevcut ürün ve sipariş verilerini listeler.
Veri Ekleme: Yeni ürün ve sipariş verilerini ekleme imkânı sağlar.
Veri Güncelleme: Mevcut verilerin güncellenmesini sağlar.
Veri Silme: İstenmeyen verilerin silinmesine olanak tanır.
RESTful API Yapısı: API, REST standartlarına uygun olarak tasarlanmıştır.

## Gereksinimler
.NET 8 SDK veya üstü
(İsteğe Bağlı) SQL Server – Veritabanı kullanılıyorsa gereklidir.
Visual Studio veya VS Code (tercihen)

## Kurulum ve Çalıştırma

#### Projeyi Klonlayın:

git clone https://github.com/ceydaturkdogan/EcommercePlatform.git
cd EcommercePlatform

#### Bağımlılıkları Yükleyin:

dotnet restore
####Uygulamayı Çalıştırın:

dotnet run --project ECommercePlatform.WebApi
#### Uygulamayı Test Edin: Çalıştırdıktan sonra Swagger UI aracılığıyla endpoint'leri test edebilirsiniz. Tarayıcınızdan https://localhost:7267/swagger/ adresine gidin.

## Ek Bilgiler

* Hata Yönetimi: Temel hata yönetimi, UseExceptionHandler middleware'i ile sağlanmıştır.
* Güvenlik: JWT (JSON Web Token) kullanılarak kimlik doğrulama ve yetkilendirme işlemleri yapılmaktadır.
* Swagger UI: API endpoint'lerini dokümante etmek için Swagger entegrasyonu sağlanmıştır.

### Katkıda Bulunma

Projeye katkı sağlamak için:
Bu repoyu fork edin.
Kendi branch'inizde değişiklik yapın:
git checkout -b feature/ÖzellikAdı
Değişikliklerinizi commitleyin:

git commit -m 'Özellik ekle: ÖzellikAdı'
Branch'inizi pushlayın:

git push origin feature/ÖzellikAdı
Bir Pull Request açarak katkıda bulunabilirsiniz.

## İletişim
Sorularınız veya önerileriniz için LinkedIn üzerinden iletişime geçebilirsiniz.
