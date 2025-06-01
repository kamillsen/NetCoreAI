# EF Core Migration Hatası ve Globalization Ayarları

Bu doküman, .NET 8.0 platformunda Entity Framework Core (EF Core) kullanılarak geliştirilen bir projede karşılaşılan migration hatasının nedenini ve çözümünü detaylı ve öğretici bir şekilde açıklamaktadır.

---

## 💥 Karşılaşılan Hata

Proje geliştiricisi aşağıdaki EF Core komutlarını kullanarak veritabanı migrasyonu yapmak istediğinde:

```powershell
Add-Migration mig1
Update-Database
```

şu hata mesajı ile karşılaşılmıştır:

```
System.Globalization.CultureNotFoundException: Only the invariant culture is supported in globalization-invariant mode.
en-us is an invalid culture identifier.
```

---

## ❓ Bu Hata Ne Anlama Geliyor?

Bu hata, uygulamanın çalıştığı ortamda **sabit (invariant) kültür modu** aktif olduğu için ortaya çıkar. .NET uygulamaları, tarih, saat, sayı biçimleri ve dil gibi işlemleri `CultureInfo` sınıfı üzerinden yapar. Örneğin `"en-US"` (Amerikan İngilizcesi) gibi kültürler bu sınıf aracılığıyla yönetilir.

Ancak:

```xml
<InvariantGlobalization>true</InvariantGlobalization>
```

şeklinde bir ayar `.csproj` dosyasında bulunuyorsa, uygulama sadece kültürsüz (invariant) modda çalışır. Bu modda `"en-US"` gibi kültür tanımlayıcıları geçersiz sayılır ve bu nedenle hata alınır.

---

## 🛠️ Hatanın Tespit Edilmesi

1. `.csproj` dosyası açılır.
2. Aşağıdaki satır kontrol edilir:

```xml
<InvariantGlobalization>true</InvariantGlobalization>
```

Bu satır mevcutsa, `Update-Database` gibi kültüre duyarlı işlemler başarısız olur.

---

## ✅ Çözüm Adımları

1. `.csproj` dosyasındaki ilgili satır **kaldırılır** ya da **false** yapılır:

```xml
<InvariantGlobalization>false</InvariantGlobalization>
```

2. Dosya kaydedilir.
3. Visual Studio veya terminal yeniden başlatılır.
4. Komut tekrar çalıştırılır:

```powershell
Update-Database
```

---

## ℹ️ Terimlerin Açıklamaları

- **EF Core (Entity Framework Core):** .NET platformunda kullanılan bir nesne-ilişkisel eşleme (ORM) kütüphanesidir. Veritabanı işlemlerini kodla yönetmeyi sağlar.
- **Migration:** EF Core'da veritabanı şemasının (tablolar, ilişkiler) kodla tanımlanıp güncellenmesini sağlayan mekanizmadır.
- **CultureInfo:** .NET'te kültürel bilgileri (tarih formatı, dil, para birimi vb.) yöneten sınıftır.
- **Invariant Culture:** Kültür bağımsız, sabit bir çalışma modudur. Performans avantajı sağlar ama çoğu kültürel işlem devre dışı kalır.

---

## 📌 Ekstra Bilgi

- Hatanın neden oluştuğunu doğrulamak için `dotnet --info` komutu terminalde çalıştırılabilir.
- `DOTNET_SYSTEM_GLOBALIZATION_INVARIANT` adlı bir ortam değişkeni varsa, onun değeri de `false` olmalıdır.

---

## 🏁 Sonuç

Bu düzeltme ile birlikte EF Core migration işlemi başarıyla gerçekleştirilmiş ve kültür tabanlı hatalar ortadan kaldırılmıştır. Bu tür hatalar genellikle Linux tabanlı sistemlerde veya yanlış yapılandırılmış proje ayarlarında karşımıza çıkar. Windows kullanıcıları için bu ayarın açık olması **gereksiz** ve **zararlı** olabilir.

---