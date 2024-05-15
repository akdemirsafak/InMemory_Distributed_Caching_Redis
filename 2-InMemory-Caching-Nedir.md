

## Kısım 2 : In-Memory Caching

### In memory Caching nedir?

Kullanıcıların isteği neticesinde veritabanından gelen dataların uygulamayı barındıran sunucunun belleğinde(Ram) geçici olarak kaydedilip kullanılmasıdır.

### Nasıl çalışır ?

Kullanıcıdan gelen istek üzerine ilk olarak cache üzerinde datanın var olması durumuna bakılır eğer data varsa buradan gönderilir, eğer ki data yoksa data veritabanından alınır ve cache'e yazıldıktan sonra kullanıcıya iletilir. Cache'lenecek data miktarı sunucunun Ram kapasitesine göre değişiklik gösterecektir.

### Muhtemel Problemler

Bir uygulamanın aynı veritabanından beslenecek şekilde up olmuş birden fazla instance'ında In-Memory Cache kullanılıyorsa veri tutarsızlığı yaşanabilir.
Burada kullanılabilecek çözümlerden birisi Session Sticky'dir. Load balancer isteği gönderen kullanıcıyı ilk olarak hangi instance'a gönderdiyse devamında da aynı instance'a gönderir.
