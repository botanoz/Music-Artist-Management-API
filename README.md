# Music Artist Management API

## Description
The Music Artist Management API allows adding, retrieving, updating, and deleting music artists and tracks. Built with C#, ASP.NET, and EF8. Developed for a Bahçeşehir University Wissen Akademie assignment.

## Features
- Add, retrieve, update, delete music and artists.

## Technologies Used
- C#
- ASP.NET Core
- Entity Framework 8

## Getting Started
1. Clone the repository:
   git clone https://github.com/botanoz/MusicArtistManagementAPI.git

2. Navigate to the project directory:
   cd MusicArtistManagementAPI

3. Restore dependencies:
   dotnet restore

4. Update `appsettings.json` with your database connection string.

### Usage
1. Apply migrations and update the database:
   dotnet ef database update

2. Run the application:
   dotnet run

## API Endpoints
- GET /api/artists: List all artists.
- POST /api/artists: Add a new artist.
- PUT /api/artists/{id}: Update an artist.
- DELETE /api/artists/{id}: Delete an artist.
- GET /api/music: List all tracks.
- POST /api/music: Add a new track.
- PUT /api/music/{id}: Update a track.
- DELETE /api/music/{id}: Delete a track.

## Contributing
Pull requests are welcome. For major changes, please open an issue first.

## License
This project is licensed under the MIT License.

---

# Music Artist Management API

## Açıklama
Music Artist Management API, müzik sanatçılarını ve parçalarını eklemeyi, listelemeyi, güncellemeyi ve silmeyi sağlar. C#, ASP.NET ve EF8 kullanılarak geliştirilmiştir. Bahçeşehir Üniversitesi Wissen Akademie ödevi olarak geliştirilmiştir.

## Özellikler
- Müzik ve sanatçı ekleme, listeleme, güncelleme ve silme.

## Kullanılan Teknolojiler
- C#
- ASP.NET Core
- Entity Framework 8

## Başlarken
1. Depoyu klonlayın:
   git clone https://github.com/botanoz/MusicArtistManagementAPI.git

2. Proje dizinine gidin:
   cd MusicArtistManagementAPI

3. Bağımlılıkları geri yükleyin:
   dotnet restore

4. `appsettings.json` dosyasındaki veritabanı bağlantı dizgisini güncelleyin.

### Kullanım
1. Migrations uygulayın ve veritabanını güncelleyin:
   dotnet ef database update

2. Uygulamayı çalıştırın:
   dotnet run

## API Endpoints
- GET /api/artists: Tüm sanatçıları listeleyin.
- POST /api/artists: Yeni bir sanatçı ekleyin.
- PUT /api/artists/{id}: Bir sanatçıyı güncelleyin.
- DELETE /api/artists/{id}: Bir sanatçıyı silin.
- GET /api/music: Tüm müzik parçalarını listeleyin.
- POST /api/music: Yeni bir müzik parçası ekleyin.
- PUT /api/music/{id}: Bir müzik parçasını güncelleyin.
- DELETE /api/music/{id}: Bir müzik parçasını silin.

## Katkıda Bulunma
Pull request'ler kabul edilir. Büyük değişiklikler için lütfen önce bir konu açın.

## Lisans
Bu proje MIT Lisansı altında lisanslanmıştır.
