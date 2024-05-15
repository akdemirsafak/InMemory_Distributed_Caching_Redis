## Kısım 6 : Redis Nedir ? (REmote DIctionary Server)
Open source ve veri erişiminde olabilecek en hızlı yöntemi benimseyerek dataları memory'de tutan bir NoSQL veritabanıdır.

NoSQL olmasının yanında tutulacak veri türüne göre bünyesinde temel yapı türlerini barındırır.Bu özelliği diğer Db'lere oranla Redis'i oldukça güçlü hale getirmektedir.Redis'in tercih edilme sebeplerinden biri tüm ilişkisel veritabanlarından hızlı olmasıdır.
Redis distributed bir sistem olduğundan ve in-memory caching'e nazaran uygulamaya dair tüm instance'ların cache'lerini tek bir uzak memory'de tuttuğundan dolayı net veri tutarlılığı olan bir sistemdir.

Redis'in verileri bellekte tutan bir veritabanı olmasının diğer bir avantaj ise veri okuma ve yazma operasyonlarını milisaniyeler cinsinde gerçekleştirebiliyor olmasıdır.
Twitter, Github,Tumbly, Pinterest, İnstagram bu teknolojiyi kullanmaktadır.

<strong> Redis caching amaçlı kullanılan bir server olsa da kullanıcıların session bilgilerini de tutabildiğimizen dolayı <u>Session Store, Pub/Sub paradigmasını desteklemesinden dolayı Publish-Subscribe</u> Pattern, uygulamada sıralı bir şekilde işlenecek olan mesajları ölçeklendirilebilir hale getirmesinden dolayı Queue's, sayaç olabilmesinden dolayı Counters senaryolarında kullanılabilmektedir. </strong>

### Veri Kalıcılığı(Persistence)
Redis verileri memory'de tutan bir sistem olsa da kalıcı verileri destekleyebilen bir sistemdir.Bunun için 'Snapshotting' ve 'Slave' olmak üzere iki yaklaşım benimsenmektedir.
1. 'Snapshotting' belirli aralıklarla alınan snapshot'ların diske kaydedilmesidir.
2. 'Slave' yönteminde ise veriler Slave'lere kaydedilip master'lardaki yük hafifletilerek gerçekleştirilir.

### Pipelining
Redis Pipelining özelliğiyle istenilen verilerin tamamını tek seferde getirerek olabildiğinde hız kazandıran performans sunar.

#### Avantajlar
1. Klasik db'lerdeki CPU kullanımını memory'e kaydırarak CPU maliyetini azaltır.
2. Performans artışı sağlar.
3. Open Source
4. Programlama dili bağımsızdır.
5. Döküman açısından zengindir.
6. Temel veri türlerini destekler.
7. Senkron çalışır bu sebeple aşırı hızlıdır.
8. Dataları memory dışında sabit diske de kaydedebilir.

#### Dezavantajlar

1. Tutulacak veriyi Ram kapasitesi belirler.
2. Relational Db'lerde olduğu gibi raporsal nitelikte karmaşık sorguları desteklemez.
3. Transaction olmadığı için süreçte alınan hatalar telafi edilemez.
   
#### Kullanım alanları

1. Caching
2. Session Storage
3. Queue's
4. Pub/Sub
5. Counter
