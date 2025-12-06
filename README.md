# BilgeAdam Automation Assessment  
C# · Selenium WebDriver · NUnit · Page Object Model

## Teknolojiler
- C#
- Selenium
- NUnit
- GitHub Actions CI
- Page Object Model
- JSON Data
- Parallel Test Execution

## Kurulum

1. Depoyu klonlayın:
   git clone https://github.com/EfeBektas/bilgeadam-automation-assessment.git

2. Bağımlılıkları yükleyin.

3. appsettings.json içinde temel ayarları düzenleyin:

{
  "baseUrl": "https://www.saucedemo.com/",
  "browser": "edge",
  "standardUser": {
    "username": "standard_user",
    "password": "secret_sauce"
  },
  "timeouts": {
    "explicit": 10,
    "implicit": 0
  }
}

## Test Senaryoları

### Senaryo 1 – Login & Unauthorized Access  
- Geçerli ve geçersiz login  
- Doğrudan URL ile yetkisiz sayfa erişimi testi  

### Senaryo 2 – Veri Güdümlü Test (DDT)
- JSON’dan ürün listesi okuma  
- Ürünleri sepete ekleme  
- İsim, fiyat ve miktar doğrulama  

### Senaryo 3 – Checkout Akışı
- Ödeme bilgileri doldurma  
- Tax ve total hesaplaması doğrulama  
- Sipariş tamamlanması  
- Sipariş sonrası ürün yeniden ekleme davranış testi  

## CI Pipeline

GitHub Actions pipeline dosyası ".github/workflows/ci.yml" içindedir ve her push/pull request durumunda testleri otomatik çalıştırır:
dotnet restore  
dotnet build  
dotnet test  