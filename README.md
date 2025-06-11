# Personel Tayin Talep Yönetim Sistemi

Kurumsal personel hareketleri, adliye tayin talepleri ve görevlendirmelerini yönetmek için geliştirilen Clean Architecture tabanlı modern bir web uygulamasıdır.


## Proje Amacı

Bu uygulama, adliyelerde görev yapan personelin, komisyonlar ve birimler arası tayin taleplerinin etkin bir şekilde yönetilmesini, personel görevlendirmelerinin ve rol bazlı giriş/şifre süreçlerinin güvenli bir şekilde takibini amaçlar.


## Kullanılan Teknolojiler ve Kütüphaneler

- .NET 9.0 / ASP.NET Core Web API  
- Entity Framework Core  
- CQRS ve MediatR  
- Clean Architecture katmanlı mimari 
- UnitOfWork & Repository Pattern  
- AutoMapper  
- FluentValidation  
- JWT Authentication  
- SQL Server  
- Swagger (Swashbuckle)  
- PasswordHasher  
- Domain Driven Design (DDD) İlkeleri


## Mimari

Clean Architecture yaklaşımıyla, aşağıdaki katmanlara ayrılmıştır:

- Domain: Temel iş kuralları, entity'ler, value object'ler, repository interface'leri.
- Application: Use case'ler (CQRS handler'ları, business rules, DTO'lar, mapping, validasyon).
- Infrastructure: Veri tabanı erişimi, repository implementasyonları, external servisler, security.
- API: HTTP endpoint’ler, swagger, authentication (controller’lar).

Temel özellikler:
- CQRS ile her iş akışı için ayrı Command/Query ve Handler ile sade kod ve yüksek test edilebilirlik.
- Transaction yönetimi: UnitOfWork ile tüm işlemler atomik.
- Role-based yetkilendirme: JWT ile güvenli erişim.
- Test edilebilirlik: Her katman bağımsız, kolay mocklanabilir.

---

## Temel Özellikler

- Personel kaydı (şifre, temel ve detay bilgilerle)
- Şifre yönetimi (ilk girişte değiştirme zorunluluğu, hash+salt)
- Komisyon/adliye/birim yönetimi
- PersonelBirimGorevlendirme: Birim ve ünvan bazlı görevlendirme
- Tayin talebi oluşturma ve taleplerin yönetimi
- JWT ile kullanıcı girişi ve rol tabanlı erişim
- Detaylı hata ve validasyon mesajları
- Swagger ile dokümantasyon

---

## Kurulum

> Not: Aşağıdaki adımlar varsayılan olarak Visual Studio/VS Code, .NET 8 ve SQL Server kullanılarak yazılmıştır.

### 1. Projeyi Klonla

git clone https://github.com/selimmurat/AYEP.PersonelTayinTalepServer.git
cd proje-adi

### 2. Bağımlılıkları Yükle

dotnet restore

### 3. Veritabanı Ayarları

- `appsettings.json` dosyasında kendi SQL bağlantı stringini ayarla.
- Migration’ları apply et:

### 4. Uygulamayı Çalıştır

dotnet run --project Api
veya Visual Studio’da F5

### 5. Swagger ile Test

- `https://localhost:??/swagger/index.html ` adresinden API endpoint’lerini ve dökümantasyonu inceleyebilirsin.

## Kullanım Notları

- İlk kullanıcı girişi: Oluşturulan personel için ilk girişte şifre değiştirme zorunludur.
- JWT Token: Login olduktan sonra dönen JWT token ile diğer endpoint’lere erişim sağlanır (Authorization header’a ekle).
- Roller: Admin ve Personel gibi roller ile erişim seviyeleri kontrol edilir.
- Personel oluştururken: Birim ve ünvan bilgisi verilirse görevlendirme otomatik oluşturulur, aksi halde sadece temel bilgiler kaydedilir.
- Error ve validasyon mesajları: Dönüş tipi her zaman standart IResultBase ile gelir.

## 

- Katmanlar arası geçişte dependency injection kullanılmıştır.
- Her iş kuralı (business rule) ayrı class’ta ve kolayca test edilebilir.
- Handler’lar arası orchestrasyon için MediatR kullanılmıştır.
- Yeni bir aggregate/özellik eklemek çok kolaydır.

## İletişim

Sorularınız için:  
- [selimmuratt@gmail.com veya https://www.linkedin.com/in/selim-murat-56b54b210/]
