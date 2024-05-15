## Kısım 1 : Caching Nedir?

Veri akışını güçlendirmek ve kullanıcılarla etkileşim sürecinde hız ve performans açısından maliyeti düşürmek için Cache'leme tekniği kullanılır.

Veritabanındaki yükü azaltabilmek ve yapılan isteklerin büyük çoğunluğunu daha dinamik bir şekilde karşılayabilmek için Caching mekanizması kullanılmaktadır.Bu mekanizma uygulamalara erişimci sayısı arttıkça kullanılan kaynakların yetersizliğinin önüne geçmeyi de amaçlar ki bu ekstra kaynak gereksinimleri karşımıza maliyet olarak çıkacaktır.

Caching çok sık kullanılan dataların her talepte sistemi tekrar tekrar yormaksızın daha hızlı elde edilmesi ve işlenebilmesi için veritabanı dışındaki farklı alanlara kaydedilmesi tekniğidir.

Caching doğru yer ve zamanda kullanıldığında uygulama performansını arttırır ve ölçeklenebilirlik sağlar.Uygulamadaki trafik yoğunluğuna göre 100 veya 1.000.000 kişide aynı oransallıkla performans sağlar ve deneyimi iyileştirir.

### Caching Durumlarında Dikkat Edilmesi Gerekenler

- Cache edilmiş veriler orjinal verilerin kopyasıdır.
- Veritabanındaki orjinal verilerde olabilecek modifikasyonlar cache'lenmiş verilerle veritabanındaki verilerin tutarlılığı bozulacaktır.Bu sebeple cache'deki datalar belirli zaman aralıklarıyla veritabanından yeniden elde edilmelidir.Bu işlemin yapılmaması veritabanında yapılan değişiklikten bir haber olan Cache mekanizmasının verinin değişmemiş halini döndürmesiyle sonuçlanır.Bu sebeple cache'de tutulacak veriler için expiration time belirleriz.

### Caching Çeşitleri Nelerdir ?

1. Local Caching ( In-Memory Caching )
   Uygulamanın bulunduğu bilgisayar üzerinde bulunan caching türüdür.Private Caching de denir.

2. Global Caching ( Distributed Caching )
   Birden fazla sunucu üzerine dağıtık olarak kurulmuş bir bütün olarak çalışan caching sistemidir. Public Caching de denir.
