## Redis Replication Managing Redis

Redis sunucusundaki verilerin güvencesini sağlayabilmek için kullanılan yöntemdir.
Fiziksel ya da başka bir problem meydana geldiğinde bizim için kritik olabilecek verileri korumak amacıyla yaparız. 

### Replication Davranışı Nedir ?

Bir Redis sunucusundaki tüm verisel yapının farklı bir sunucu tarafında birebir modellenmesidir/aynalanmasıdır.

#### Temel Terminolojiler
- Master: Veri sunucusu (Replikası alınacak/modellenecek orjinal server)
- Slave : Master'ın replikasını alan sunucuya denir.

Replication özelliğiyle master ile slave arasında bir bağlantı kurulur ve master'da yapılan tüm değişiklikler anlık olarak slave(replika)'e aktarılır.Bu bağlantı koptuğunda otomatik olarak yeniden sağlanır ve verisel güvence sağlanmaya çalışılır.
Aradaki bağlantının kopması gibi durumlar söz konusu olabilir.Bu gibi konulardan dolayı Mikro düzeyde de olsa veri tutarsızlığı yaşanabilir.

Master'da yaşanabilecek olası arıza, kesinti veya diğer durumlarda slave sunucular otomatik olarak devreye girer ve hizmetimiz kesintisiz bir şekilde devam eder.

<strong>
Eğer master ve slave arasında verisel tutarlılık/eşitlik tam olarak gerçekleşmemişse Redis master ile slave arasındaki veri eşitliğini sağlamak için talepte bulunur ve güncel verinin aktarılmasını sağlar.Bu süreçte kaynak tüketimi devam eder, ekstra maliyet yaratır.
Replication oldukça maliyetli bir işlemdir.Veri güvencesinin önemli olduğu durumlarda işi neredeyse garantiye alır.
</strong>
Bir master'ın birden fazla replikasyonu olabilir.Slave sayısı arttıkça master'ın kaynak tüketimi de artacaktır.
Birden fazla slave olması; yüksek kullanılabilirlik, yedekleme ve kurtarma, veri ölçeklendirme ve coğrafi olarak dağıtılmış sistemler gibi senaryolarda yararlı çalışmalar gerçekleştirilebilir.

Slave kesinlikle master üzerinde değişiklik yapamaz/yapmamalıdır.Readonly modunda çalışmalıdır.
Create, Update, Delete işlemleri sadece master üzerinde yapılmalıdır.Read işlemleri ise slave'ler üzerinden yapılabilir. Böylece master'ın yükü azaltılmış olacaktır.
Slave'lerde yapılan değişikliği master'a yansıtılamaz, redis desteklemez.
Slave sunucular test süreçlerinde kullanılabilir,bu sayede canlı verilerde bozulmaz olmaz.Riskler minimize edilmiş olur.

### Uygulama : 

2 adet redis sunucuyu up edelim.

```bash
docker run --name redis-master -d -p 6379:6379 redis
docker run --name redis-slave -d -p 6380:6379 redis
```

Master sunucumuzun ip adresini öğrenelim.

```bash
docker inspect -f "{{.NetworkSettings.IPAddress}}" redis-master 
```

Slave ile master arasındaki replication ilişkisini oluşturalım. Container'deki port ile erişmeliyiz.

```bash
docker exec -it redis-slave redis-cli slaveof 172.17.0.2 6379
```

İki sunucu arasında master-slave ilişkisi oluşturuldu. Artık master üzerinde yapılan değişiklikler slave'e anlık olarak aktarılacaktır.
Herhangi bir sunucunun replication bilgisini edinmek için aşağıdaki komutu kullanabiliriz.

```bash
> docker exec -it redis-master redis-cli 
> info replication
```
Herhangi bir slave sunucusunun hangi master üzerinden replikasyon aldığını öğrenmek için aşağıdaki komutu kullanabiliriz.

```bash
> docker exec -it redis-slave redis-cli 
> info replication 
```

RedisInsight üzerinden testleri yaptığımızda Master üzerinde yapılan değişikliklerin Slave'e anlık olarak aktarıldığını görebiliriz.
Aynı şekilde slave'e yeni bir key eklemeye çalışırsak hata alırız çünkü yukarıda belirttiğimiz gibi slave READONLY'dir.

