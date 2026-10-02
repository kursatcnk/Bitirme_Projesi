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
2. Formlardaki (`Giris.cs`, `Globals.cs`, `Uyeler.cs` ...) bağlantı dizesinde `Data Source` değerini kendi sunucu adınla değiştir.
3. `BitirmeProjesi.sln` dosyasını açıp çalıştır.

E-posta ve SMS göndermek için gereken ayarlar `YeniUye.cs` ve `SMS.cs` dosyalarındaki açıklama satırlarında anlatılıyor.
