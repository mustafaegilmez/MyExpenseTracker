🧾 MyExpenseTracker - Kişisel Gelir Gider Takip Uygulaması
===========================================================

📌 Proje Hakkında
-------------------
MyExpenseTracker, çok katmanlı mimari ile geliştirilmiş, kullanıcıların gelir ve giderlerini kolayca takip edebileceği bir ASP.NET Core MVC uygulamasıdır. Kullanıcılar kayıt olabilir, giriş yapabilir, kendi kategorilerini ve işlemlerini yönetebilir.

📁 Katmanlar
-------------
- **Entity Layer**: Tüm varlık (model) tanımları
- **Data Access Layer (DAL)**: Entity Framework ile veri erişimi (Generic Repository Pattern)
- **Service Layer**: İş mantığı
- **Web Layer**: ASP.NET Core MVC UI
- **Utility Layer**: Şifreleme, JWT ve yardımcı sınıflar

🔐 Kimlik Doğrulama
--------------------
- Cookie tabanlı kullanıcı oturumu
- Hashlenmiş parola saklama (BCrypt)
- Girişte ClaimsPrincipal ile oturum açma
- Rol bazlı yetkilendirme (Admin, User)

🛠️ Temel Özellikler
---------------------
- Kullanıcı Kayıt / Giriş
- Gelir & Gider İşlemleri
- Kategori oluşturma, güncelleme, silme
- Kişiye özel veri yönetimi
- Profil düzenleme

📊 Planlanan Geliştirmeler
----------------------------
- Grafiklerle raporlama (Chart.js vb.)
- Filtreleme ve gelişmiş işlem arama
- Toast bildirimler
- Admin paneli: Kullanıcı yönetimi, rol atama
- Birim testleri ve daha güçlü validasyonlar

🚀 Kurulum
-----------
1. `appsettings.json` içine bağlantı stringini girin
2. Terminalde `dotnet ef database update` komutu ile veritabanını oluşturun
3. Projeyi çalıştır: `dotnet run`

📌 Not
-------
Kodlama prensibi olarak sade, genişletilebilir ve kullanıcı odaklı bir yapı tercih edilmiştir.

---

👨‍💻 Geliştirici: Mustafa Eğilmez
📬 İletişim: mustafaegilmez.dev@gmail.com
