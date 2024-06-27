# Mesajlasma_Sistemi_Mini_App

## Genel Bakış

Bu proje, basit bir mesajlaşma sistemi uygulaması oluşturan bir Windows Forms uygulamasıdır. Kullanıcıların SQL Server veritabanını kullanarak giriş yapmalarına, mesaj göndermelerine ve gelen ve giden mesajları görüntülemelerine olanak tanır.

## Kurulum

1. **Gereksinimler:**
    - Visual Studio (C# geliştirme ortamı)
    - .NET Framework
    - SQL Server

2. **Adımlar:**
    - Bu projeyi bilgisayarınıza klonlayın veya indirin.
    - Visual Studio'da projeyi açın.
    - SQL Server'ınızda `DbMesajlasmaSistemi` adlı bir veritabanı oluşturun ve gerekli tabloları (`TBLKISILER` ve `TBLMESAJLAR`) ekleyin.
    - Projedeki bağlantı dizesini (`conn` değişkeni) kendi SQL Server ayarlarınıza göre güncelleyin.

## Kullanım

### Giriş Yapma

- Uygulamayı çalıştırdığınızda, kullanıcı numarası ve şifre ile giriş yapılabilir.
- `button1` (Giriş Yap) butonuna tıkladığınızda:
    - Girilen bilgiler `TBLKISILER` tablosunda doğrulanır.
    - Bilgiler doğruysa, `Form2` açılır ve kullanıcının numarası iletilir.
    - Bilgiler yanlışsa, "Hatalı Giriş Yaptınız!" mesajı görüntülenir.

### Mesaj Gönderme ve Görüntüleme

- `Form2` yüklendiğinde:
    - Kullanıcının numarası ve adı-soyadı görüntülenir.
    - `gelenKutusu()` metodu, kullanıcının aldığı mesajları `dgvGelen` kontrolünde listeler.
    - `gidenKutusu()` metodu, kullanıcının gönderdiği mesajları `dgvGiden` kontrolünde listeler.

- `button1` (Gönder) butonuna tıkladığınızda:
    - Girilen mesaj bilgileri `TBLMESAJLAR` tablosuna kaydedilir.
    - Mesaj başarıyla gönderildiğinde bir bildirim gösterilir ve `gidenKutusu()` metodu çağrılarak giden mesajlar güncellenir.

## Kod Özeti

### Form1 Sınıfı

- `Form1` sınıfı, kullanıcının giriş yapmasını sağlar.

### Metodlar ve Olaylar

- `button1_Click()`: Kullanıcının giriş bilgilerini kontrol eder ve doğrulama başarılı olursa `Form2`yi açar.

### Form2 Sınıfı

- `Form2` sınıfı, kullanıcının mesajları görüntülemesini ve yeni mesaj göndermesini sağlar.

### Metodlar ve Olaylar

- `gelenKutusu()`: Kullanıcının aldığı mesajları listeler.
- `gidenKutusu()`: Kullanıcının gönderdiği mesajları listeler.
- `Form2_Load()`: Form yüklendiğinde kullanıcı bilgilerini ve mesajlarını görüntüler.
- `button1_Click()`: Kullanıcının girdiği mesajı veritabanına kaydeder ve giden mesajları günceller.

## Önemli Notlar

- Veritabanı bağlantı dizesi (`conn` değişkeni) uygulama ayarlarınıza göre güncellenmelidir.
- Bu uygulama temel bir doğrulama ve mesajlaşma sistemini göstermektedir. Gerçek dünyadaki uygulamalarda daha gelişmiş doğrulama ve güvenlik önlemleri alınmalıdır.

Bu rehber, projeyi kurmanıza ve kullanmanıza yardımcı olacaktır. Herhangi bir sorunla karşılaşırsanız, gerekli ayarları ve adımları tekrar kontrol edin.

## Projeye Ait Örnek Ekran Görüntüleri
### Giriş Ekranı
![Giriş](https://github.com/huseynaktas/Mesajlasma_Sistemi_Mini_App/assets/114494075/a440dcf3-c946-4cf8-9790-a2e0e247ea69)

### Mesajlaşma Ekranı
![Mesaj](https://github.com/huseynaktas/Mesajlasma_Sistemi_Mini_App/assets/114494075/85c00e88-d6b4-4d34-a2d8-cf9864b0358c)

