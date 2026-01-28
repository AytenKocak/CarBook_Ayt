#  CarBook Project - Advanced .NET 8 Web API

Bu proje, **Onion Architecture**  ve **CQRS & Mediator** tasarým desenleri üzerine inþa edilmiþ, modern 
bir araç kiralama sistemi backend çalýþmasýdýr.

## Neden Bu Mimari?
Projede katmanlar arasý baðýmlýlýðý minimize etmek ve sürdürülebilirliði artýrmak için:
-  SingleResponsibility Principle (SRP)
- **Application Katmaný:** Tüm iþ mantýðý ve Handler yapýlarý burada toplandý.
- **Domain Katmaný:** Varlýklar (Entities) ve çekirdek yapýlar izole edildi.
- **Persistence:** Veritabaný iþlemleri Repository Pattern ile soyutlandý.

## Teknik Yapý
- **MediatR:** Command ve Query yönetimi için.
- CQRS
- **FluentValidation:** kod çalýþmadan doðrulama mekanizmasý.
- **Entity Framework Core:** Veri eriþimi için.
- Dto
-Repository Pattern




---
**Geliþtirici:** Ayten
*"Kodda hata varsa, kokusunu alýrým; MediatR varsa, düzeni kurarým."*