## Kısım 10 : Veri Türleri

<string>Rediste veri türleri en fazla 512mb olacak şekilde key - value formatında tutulabilir.</string>

### Redis String
Metinsel türlerle birlikte her türlü veriyi karşılayabilir.Binary olarak resim,pdf vs gibi dosyaları da tutabilir.Sınırlama olmayan bir veri türüdür.

1. Ekleme => SET ad şafak
2. Okuma => GET ad
3. Karakter Aralığı Okuma => GETRANGE ad 0 2
4. Arttırılabilir/Azaltılabilir Değer Oluşturma
5. Üzerine Ekleme : APPEND ad ali
   

### Redis List

Değerleri koleksiyonel olarak tutar.Koleksiyonun başına veya sonuna ekleme yapılabilir

1. Başa veri ekleme => LPUSH ad ahmet
2. Verileri listeleme => LRANGE ad 0 2
3. Sona veri ekleme => RPUSH ad ayşe
4. Data çıkarma LPOP ve RPOP ile yapılabilir.
5. Indexe göre datayı getirme => LINDEX ad 2


### Redis Set
Redis List'in unique versiyonudur.Veriler rastgele bir düzende eklenmektedir.

1. Ekleme : SADD color blue
2. Silme SREM color white


### Redis Sorted Set

Redis Set'in düzenli bir şekilde eklenebilir versiyonudur.Veri istenilen bir sıraya eklenebilir.

1. Ekleme => ZADD vehicles 2 car
2. Getir => ZRANGE vehicles 0 2 
3. Silme => ZREM vehicles 3
   
### Redis Hash
key-value formatında veri tutan türdür.

1. Ekleme => HMSET dictionary pen kalem
2. Getir => HMGET dictionary pen
3. Silme => HMDEL dictionary pen
4. Tümünü Getir => HGETALL dictionary

<strong>
Redis için powershell'de Türkçe karakter kullanımı redis-cli -h localhost -p 1453 --raw komutu ile aktif hale getirilebilir.
</strong>