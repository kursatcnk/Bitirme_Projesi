# Spor Salonu Yönetim Sistemi

Bitirme projem olarak C# Windows Forms ve SQL Server ile yazdığım spor salonu yönetim uygulaması. Üye, eğitmen, ekipman ve randevu kayıtlarını tek bir masaüstü uygulamasında topluyor.

## Özellikler

- **Giriş ve kayıt:** kullanıcı adı / şifre ile giriş, yeni kullanıcı oluşturma.
- **Üyeler:** üye ekleme, güncelleme, silme ve listeleme. Yeni üyeye hoş geldin e-postası ve SMS gönderilebiliyor.
- **Eğitmenler:** eğitmen kayıtları ve uzmanlık bilgileri.
- **Ekipmanlar:** salondaki ekipmanların envanteri.
- **Randevular:** üye için eğitmenden randevu alma. Aynı eğitmene aynı saate ikinci randevu verilmiyor.
- Üye ve eğitmen güncelleme / silme işlemleri SQL Server'daki stored procedure'lar üzerinden yapılıyor.

## Çalıştırma

Gerekenler: Visual Studio, .NET Framework 4.7.2 ve SQL Server.

1. `GYM.bak` yedeğini SQL Server'a geri yükle. Veritabanı olmadan giriş ekranı açılmaz.
2. `BitirmeProjesi/App.config` içindeki `GYM` bağlantı dizesinde `Data Source` değerini kendi sunucu adınla değiştir (SQL Express için `.\SQLEXPRESS`).
3. `BitirmeProjesi.sln` dosyasını açıp çalıştır.

Hoş geldin SMS'i ve e-postası için kullanıcı adı ve şifreler `App.config`'teki `appSettings` bölümüne yazılıyor. Boş bırakılan kanal kullanılmıyor; bu bilgileri repoya göndermeyin.

## Güvenlik notları

Projeyi sonradan elden geçirip şunları düzelttim:

- Bütün sorgular parametreli; kullanıcının yazdığı hiçbir değer SQL metnine eklenmiyor. Ortak bağlantı ve sorgu kodu `Globals.cs` içinde.
- Şifreler MD5 yerine PBKDF2 (SHA-256, 100.000 tur, rastgele tuz) ile saklanıyor (`Sifreleme.cs`). Yedekteki eski MD5 kayıtlarıyla giriş yapılabiliyor ve şifre ilk girişte yeni biçime çevriliyor.
- Bağlantı dizesi tek yerde (`App.config`); SMS ve e-posta bilgileri koddan çıkarıldı.
- Randevu kontrolü artık eğitmene göre yapılıyor: aynı saatte farklı eğitmenlere randevu verilebiliyor.
