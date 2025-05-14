
# 🚗 RentACar API (.NET Core 8.0)

Bu proje, araç kiralama işlemlerini gerçekleştirmek üzere geliştirilmiş, **.NET Core 8.0** tabanlı bir **Web API** uygulamasıdır. Proje, yazılım geliştirmede yaygın olarak kullanılan **Onion Architecture**, **Repository Pattern**, **DTO**, **JWT Authentication**, **Swagger** ve **Entity Framework Core** teknolojilerini içermektedir.

---

## 🚀 Kullanılan Teknolojiler

- ASP.NET Core 8.0 Web API
- Onion Architecture
- Repository Pattern
- Entity Framework Core
- Swagger (API Dokümantasyonu)
- JWT (Kimlik Doğrulama)
- AutoMapper
- SQL Server
- Postman (Test amaçlı)

---

## 📁 Proje Yapısı (Onion Architecture)

```
RentACar
│
├── Core
│   ├── Domain             👈 Entity’ler, temel interface’ler, domain kuralları
│   └── Application        👈 UseCase’ler, Servis interface’leri, DTO’lar
│
├── Infrastructure
│   └── Persistence        👈 EF Core DbContext ve Repository implementasyonları
│
├── Presentation
│   └── API                👈 Controller’lar, Swagger, JWT, UI katmanı
```

---

## 🧩 Katmanların Görevleri

- **Core.Domain:**  
  Uygulamanın iş kuralları burada tanımlanır. Entity sınıfları ve temel interface’ler bu katmandadır.

- **Core.Application:**  
  Servisler, DTO’lar ve uygulama mantığı (iş kurallarıyla bağlantılı değil) burada bulunur.

- **Infrastructure.Persistence:**  
  Veri tabanı işlemleri burada gerçekleştirilir. `DbContext`, `Repository` sınıfları burada tanımlanır.

- **Presentation.API:**  
  API Controller’ları, Swagger ayarları, JWT konfigürasyonları bu katmanda bulunur.

---

## 💾 Veritabanı Ayarı

Veritabanı bağlantısı `RentCarDbContext` içerisinde tanımlanmıştır:
Server=SERHAT\\SQLEXPRESS bu ismi kendi sql server isminize göre ayarlayabilirsiniz.
```csharp
public class RentCarDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=SERHAT\\SQLEXPRESS; Database=RentedCarDb; Trusted_Connection=True; TrustServerCertificate=True;");
    }

    public DbSet<Car> Cars { get; set; }
    public DbSet<RentedCar> RentedCars { get; set; }
    // Diğer DbSet'ler
}
```
