## Messaging

Projeyi çekip "docker-compose -f docker-compose.yml -f docker-compose.override.yml up -d" komutu hem sql hem api ayağa kaldırılabilir.
Tablolar otomatik oluşacaktır.
MS-SQL ve .Net Core kullanılmıştır.
Unit test için NUnit kullanılmıştır.

# Register İçin
POST - http://localhost:8000/api/auth/register
JSON - {
    "email" : "TEST@gmail.com",
    "UserCode": "TEST1",
    "password" : "TEST1",
    "firstName" : "TEST1",
    "lastName" : "TEST1"
}
# Login için 
POST - http://localhost:8000/api/auth/login
JSON - {
    "email" : "test",
    "password" : "test"
}
# Mesaj Gönderimi için
POST - http://localhost:8000/api/message/send
JSON - {
    "receiverUserCode": "TEST",
    "senderUserCode": "TEST1",
    "message": "selam"
}
# Bloklama için
POST - http://localhost:8000/api/UserBlockedUser/block
JSON - {
    "userToBlock" : "TEST",
    "currentUserId" : 1
}

### ErrorLog ve UserActivity'ler apiCall ile değil DB kayıt atarak çalışmaktadır. Aynı isimli tablolardan select ile kayıtlar elde edilebilir.
