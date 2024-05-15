## Kısım 4 : On-Demand Caching, Pre-Populate Caching, Absolute Time ve Sliding Time

### On-Demand Caching Nedir?
Dataların kullanıcıdan request geldikten sonra cache'lenmesidir.

### Pre-Populate Caching Nedir?
Dataların uygulama up olduğunda cache'lenmesidir. Genellikle statik veriler için tercih edilir.Güncellenme ihtimali çok çok az olan datalar için kullanılır.Örneğin countries.

------------------------------

Dataların ne kadar süreliğine cache'de kalacağını belirlerken Absolute Time ve Sliding Time tercihlerinde bulunabiliriz.

### Absolute Time Nedir ?

Cache'deki datanın ne kadar süre tutulacağına dair net ömrün belirlenmesidir.Belirtilen süre dolduğunda cache temizlenir.

### Sliding Time

Cache'lenmiş data'ya bellekte belirtilen süre içerisinde erişim isteği gelmesi durumunda cache'in süresinin uzatılması durumudur.
Eğer belirtilen süre içerisinde istek gelmezse cache temizlenir.

Cache'de uzun süreli tutulan dataların veritabanında değişikliğe uğraması durumunda cache'de datanın yeni hali yer almayacaktır.Bu durumun önüne geçebilmek için datanın ömrü hem Absolute hem de Sliding yaklaşımlarıyla belirlenmelidir.

Örnek;
Sliding time olarak 2 dakika,Absolute Time olarak ise 10dk olarak belirlenen cache ömrü  2 dk içerisinde erişim isteği gelirse ömrü 2 dk daha uzayacaktır.Eğer 2 dk içerisinde istek gelmezse ya da sliding son periyottaysa artık cache silinecektir.
