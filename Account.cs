using System;

class Account
{
    private int _index = 0; // Hesap işlemlerini takip etmek için bir indeks
    private double balance; // Hesap bakiyesi

    // Property (Özellik): Hesap bakiyesini kontrol eder
    private double Balance
    {
        get { return balance; } // Bakiye okunduğunda
        set
        {
            if (value < 0)
            {
                Console.WriteLine("Bakiye yetersiz!"); // Bakiye negatifse uyarı mesajı verir
            }
            else
            {
                balance = value; // Bakiye pozitifse günceller
            }
        }
    }

    public string FirstName { get; set; } // Hesap sahibinin adı
    public string LastName { get; set; }  // Hesap sahibinin soyadı

    public string FullName { get { return FirstName + " " + LastName; } }  // Hesap sahibinin tam adı

    private string[] Activities { get; }  // Hesap işlemlerini saklamak için bir dizi
    public DateTime AccountDate { get; }   // Hesap oluşturulma tarihi

    public Account()
    {
        AccountDate = DateTime.Now;  // Hesap oluşturulma tarihini belirler
        Activities = new string[16];  // Hesap işlemlerini saklamak için dizi oluşturur
    }

    // Para yatırma işlemi
    public void Deposit(float value)
    {
        Balance += value; // Bakiyeyi artırır

        Activities[_index] = string.Format("{0} tarihinde {1} birim yatırıldı. Yeni bakiye: {2}", DateTime.Now, value, Balance);
        _index++; // İşlemi Activities dizisine kaydeder ve indeksi artırır
    }

    // Para çekme işlemi
    public void Withdraw(float value)
    {
        if (value < 50 || value > 10000)
        {
            Console.WriteLine("50 birimden az veya 10,000 birimden fazla çekemezsiniz!"); // Belirtilen sınırlamaları kontrol eder
        }
        else
        {
            var amount = Balance - value;
            if (amount < 0)
            {
                Console.WriteLine("Yetersiz bakiye! Çekilemez: " + value.ToString()); // Yetersiz bakiye uyarısı
            }
            else
            {
                Balance = amount; // Bakiyeyi günceller

                Activities[_index] = string.Format("{0} tarihinde {1} birim çekildi. Yeni bakiye: {2}", DateTime.Now, value, Balance);
                _index++; // İşlemi Activities dizisine kaydeder ve indeksi artırır
            }
        }
    }

    // Hesap bilgilerini görüntüleme
    public void CheckAccount()
    {
        Console.WriteLine(string.Format("Oluşturulma Tarihi: {0}, Adı Soyadı: {1}, Bakiye: {2}", AccountDate, FullName, Balance));
    }

    // Hesap işlemlerini listeleme
    public void AccountActivities()
    {
        Console.WriteLine("Hesap İşlemleri:");
        for (int i = 0; i < _index; i++)
        {
            Console.WriteLine(Activities[i]);
        }
    }
}