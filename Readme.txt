--Kitap Kayıt Sistemi--
------------------------
-Projedeki amaç kitapların belli başlı durumlarını ve bilgilerini sisteme kaydetmektir.
-Panel,Groupbox,Textbox,Button ve View seçenekleri olarak dataGridView kullanmayı tercih ettim yapacağım proje uygun olarak gördüm.
-Sistemin çalışma durumu şöyle kitaplar hakkındaki bilgileri girip kaydet'e basıyoruz ve kitap özellikleri
dataGridView de gözüküyor. Herhangi bir yanlış yazım ve ekleme yapıldığında sil veya güncelle butonlarını kullanarak düzeltme
yapma şansımız var. Genelde projenin kullanım alanları kitap satıcıları için daha çok verim sağlayacaktır.

---------------------------------------------

- Yapılan değişiklikler -

-Arama butonu eklendi.(Ad'a göre arama yapılıyor.)
-Güncelleme butonu eklendi.
-Panel içinde groupBox eklendi.
-Yeni kayıtların sıralanış biçimi değiştirildi. (Id'e göre sıralanıyor, son eklenen başa geliyor.)
-Veritabanı bağlantısı eklendi. (Microsoft SQL Server Management Studio 2018)

------------------------------------------------

- Veritabanı Restore İşlemleri -

Sistemdeki bilgileri çekmek için veritabanımıza restore işlemi yapmamız gerekmektedir.
Restore işlemleri için adımları takip ederek gerçekleştiriniz.
Veritabanımızda Databases üstüne gelerek sağ tıklayıp RESTORE DATABASE.. tıklıyoruz.
Source kısmından Device seçerek Add tıklıyoruz.
Dosyamızın içindeki kitap.bak dosyasını seçerek OK diyoruz.
Daha sonra gelen dosyanın aşağıdaki RESTORE kutucuğunu tikleyip OK basıyoruz.
Restore işlemi olmuştur.

