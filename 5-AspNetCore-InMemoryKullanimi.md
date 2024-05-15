
## Kısım 5 : .Net Core'da In-Memory Cache Kullanımı

### Cache Priority

Cache'de depolanan veriler belleği yük olarak zorladığında yeni veriler için sistem tarafından var olan veriler silinmek istenebilir.Böyle bir durumda cache'den silinecek olan verilerin önceliklerini ve hangilerin kalıcı olacağını Priority değeri ile belirleriz.

Priority değeri ; Low, Normal, High ve NeverRemove olmak üzere dört değer alır.
1. Low : Önem derecesi düşük dataları belirtir.İlk silinecek datalardır.
2. Normal
3. Hight : Önemli verilerdir Cache'den en son silinmesi gereken datalardır.
4. NeverRemove : Kesinlikle silinmemesi gereken datalardır.Sınıra gelinen bir memory'de Priority değeri NeverRemove olan datalarla sınır aşılırsa Exception fırlatılır.

#### RegisterPostEvictionCallback Olayı
Cache'lenmiş bir datanın hangi sebeepten dolayı memory'den silindiğine dair bilgi edinmemizi sağlayan olayı fırlatan fonksiyondur.
 Key parametresi Cache'lenmiş datanın key'ini,value parametresi değerini, reason parametresi ise silinme sebebini döndürür.
