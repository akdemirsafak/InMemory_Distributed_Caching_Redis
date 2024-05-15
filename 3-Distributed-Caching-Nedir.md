## Kısım 3 : Distributed Cache

### Nedir ?

Cache'lenecek dataların uygulamanın  up olduğu sunucuda değil başka bir cache servisinde/sunucuda tutulmasıdır.
Birden fazla instance'ı olan uygulamalar arası veri tutarsızlığının önüne geçilmiş olur.Çünkü tüm instance'lar aynı cache'den beslenir.
In-Memory caching yapılanması kullanılan sunucularda yaşanabilecek herhangi bir problemde tüm cache'ler silinirken distributed caching kullanıldığında cache'leme uygulama sunucusundan bağımsız bir serviste yapıldığı için daha güvenli olur. Performans açısından In-Memory daha iyidir. 