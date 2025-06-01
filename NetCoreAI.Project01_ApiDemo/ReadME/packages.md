# 📦 Proje Bağımlılıkları (NuGet Paketleri)

Bu .NET 8.0 Web API projesinde kullanılan temel NuGet paketleri aşağıda detaylı bir şekilde açıklanmıştır. Her bir paket, sistemin belirli bir ihtiyacına hizmet eder ve kaldırıldığında belirli işlevler çalışmaz hâle gelir.

---

## 1. Microsoft.EntityFrameworkCore

**🔍 Açıklama:**  
Entity Framework Core (EF Core), nesne-ilişkisel eşleme (ORM) desteği sunan modern bir veri erişim kütüphanesidir.

**🎯 Kullanım Amacı:**  
- Veritabanı işlemlerini C# koduyla yönetmek  
- LINQ sorguları kullanmak  
- Code-first veri modeli geliştirmek

**❌ Olmazsa:**  
- Veritabanı işlemleri için doğrudan SQL yazmak gerekir  
- `DbContext` ve `DbSet` nesneleri kullanılamaz

---

## 2. Microsoft.EntityFrameworkCore.SqlServer

**🔍 Açıklama:**  
EF Core’un SQL Server veritabanı ile çalışmasını sağlayan sağlayıcı paketidir.

**🎯 Kullanım Amacı:**  
- `UseSqlServer(...)` metodu ile veritabanına bağlanmak  
- SQL Server’a özgü yapıların (identity, schema) kullanımı

**❌ Olmazsa:**  
- SQL Server ile bağlantı kurulamaz  
- Veritabanı işlemleri yapılamaz

---

## 3. Microsoft.EntityFrameworkCore.Tools

**🔍 Açıklama:**  
EF Core CLI (Command Line Interface) araçlarını sağlar.

**🎯 Kullanım Amacı:**  
- `dotnet ef migrations add`  
- `dotnet ef database update`  
- CLI üzerinden migration işlemleri yapmak

**❌ Olmazsa:**  
- Komut satırından migration ve veritabanı güncelleme yapılamaz  
- Otomasyon işlemleri aksar

---

## 4. Microsoft.EntityFrameworkCore.Design

**🔍 Açıklama:**  
Tasarım zamanı (design-time) işlemler için gerekli bileşenleri içerir.

**🎯 Kullanım Amacı:**  
- Migration sınıflarını oluşturmak  
- `Scaffold-DbContext` komutlarını çalıştırmak  
- Visual Studio üzerinden migration işlemlerini desteklemek

**❌ Olmazsa:**  
- Design-time migration üretilemez  
- Scaffolding (database-first) çalışmaz

---

## 5. Swashbuckle.AspNetCore

**🔍 Açıklama:**  
ASP.NET Core uygulamaları için Swagger/OpenAPI desteği sunar.

**🎯 Kullanım Amacı:**  
- Swagger arayüzü üzerinden API'yi test etmek  
- Otomatik API dökümantasyonu oluşturmak  
- `/swagger` endpointinden erişim sağlamak

**❌ Olmazsa:**  
- Geliştirici için anlaşılır API dökümantasyonu sunulamaz  
- Test süreçleri manuel hâle gelir

---

## ⚙️ Ek Özellikler (PropertyGroup)

- **`<TargetFramework>net8.0</TargetFramework>`**  
  Projenin .NET 8.0 framework'ü ile çalıştığını belirtir.

- **`<Nullable>enable</Nullable>`**  
  Nullable referans türü denetimini etkinleştirir. Null güvenliği sağlar.

- **`<InvariantGlobalization>true</InvariantGlobalization>`**  
  Sabit kültürel format kullanımıyla sistemler arası tutarlılık sağlar (özellikle tarih/sayı biçimleri).

---

Bu paketler, projenin veritabanı yönetimi, API test edilebilirliği, migration desteği ve kod üretkenliği gibi temel işlevlerini yerine getirebilmesi için kritik öneme sahiptir.
