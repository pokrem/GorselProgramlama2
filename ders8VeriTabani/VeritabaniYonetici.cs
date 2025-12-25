using UnityEngine;
using TMPro;
using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using System.Collections.Generic;

public class VeritabaniYonetici : MonoBehaviour
{
    [Header("UI Elemanlarý")]
    public TMP_InputField gorevInput;
    public TMP_InputField saatInput;
    public TMP_InputField dakikaInput;
    public GameObject gorevPrefab;
    public Transform listeIcerik;

    private string baglantiYolu;
    private float kontrolZamanlayici = 1f; // Her saniye kontrol etsin

    [Header("Alarm Ayarlarý")]
    public GameObject alarmPanel;
    public TMP_Text alarmMetni;

    void Awake()
    {
        string dosyaYolu = Path.Combine(Application.persistentDataPath, "Gorevler.db");
        baglantiYolu = "URI=file:" + dosyaYolu;
        VeritabaniOlustur();
        ListeyiYenile(); // Oyun açýldýðýnda eski görevleri getir
    }

    void Update()
    {
        kontrolZamanlayici -= Time.deltaTime;
        if (kontrolZamanlayici <= 0)
        {
            AlarmKontrolEt();
            kontrolZamanlayici = 1f;
        }
    }

    void VeritabaniOlustur()
    {
        using (var baglanti = new SqliteConnection(baglantiYolu))
        {
            baglanti.Open();
            using (var komut = baglanti.CreateCommand())
            {
                // En saðlam yazým þekli budur kanka:
                komut.CommandText = "CREATE TABLE IF NOT EXISTS Gorevler (" +
                                    "id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                                    "baslik TEXT, " +
                                    "saat TEXT, " +
                                    "caldi INTEGER DEFAULT 0);";
                komut.ExecuteNonQuery();
            }
        }
    }

    public void GorevEkleButon()
    {
        // Saat ve Dakika tek haneliyse baþýna 0 ekleyelim (Örn: 9:5 -> 09:05)
        string s = saatInput.text.PadLeft(2, '0');
        string d = dakikaInput.text.PadLeft(2, '0');
        string baslik = gorevInput.text;
        string tamSaat = s + ":" + d;

        using (var baglanti = new SqliteConnection(baglantiYolu))
        {
            baglanti.Open();
            using (var komut = baglanti.CreateCommand())
            {
                komut.CommandText = $"INSERT INTO Gorevler (baslik, saat, caldi) VALUES ('{baslik}', '{tamSaat}', 0)";
                komut.ExecuteNonQuery();
            }
        }

        gorevInput.text = "";
        saatInput.text = "";
        dakikaInput.text = "";

        ListeyiYenile(); // ÝÞTE BU: Eklendiði an listeyi tazeler
    }

    public void ListeyiYenile()
    {
        foreach (Transform child in listeIcerik) { Destroy(child.gameObject); }

        using (var baglanti = new SqliteConnection(baglantiYolu))
        {
            baglanti.Open();
            using (var komut = baglanti.CreateCommand())
            {
                komut.CommandText = "SELECT * FROM Gorevler";
                using (IDataReader okuyucu = komut.ExecuteReader())
                {
                    while (okuyucu.Read())
                    {
                        string baslik = okuyucu["baslik"].ToString();
                        string saat = okuyucu["saat"].ToString();
                        GameObject yeniGorev = Instantiate(gorevPrefab, listeIcerik);
                        yeniGorev.GetComponentInChildren<TMP_Text>().text = $"{baslik} - {saat}";
                    }
                }
            }
        }
    }

    void AlarmKontrolEt()
    {
        string suAn = System.DateTime.Now.ToString("HH:mm");

        using (var baglanti = new SqliteConnection(baglantiYolu))
        {
            baglanti.Open();
            using (var komut = baglanti.CreateCommand())
            {
                // Saati gelen ve henüz çalmamýþ (caldi=0) görevleri bul
                komut.CommandText = $"SELECT * FROM Gorevler WHERE saat = '{suAn}' AND caldi = 0";
                using (IDataReader okuyucu = komut.ExecuteReader())
                {
                    if (okuyucu.Read())
                    {
                        string baslik = okuyucu["baslik"].ToString();
                        AlarmTetikle(baslik);

                        // Ayný görevin tekrar tekrar çalmamasý için iþaretle
                        using (var updateKomut = baglanti.CreateCommand())
                        {
                            updateKomut.CommandText = $"UPDATE Gorevler SET caldi = 1 WHERE saat = '{suAn}'";
                            updateKomut.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
    }

    void AlarmTetikle(string gorevAdi)
    {
        alarmMetni.text = gorevAdi + " zamaný geldi!";
        alarmPanel.SetActive(true);
    }

    public void AlarmKapat()
    {
        alarmPanel.SetActive(false);
    }

    // Tüm görevleri veritabanýndan ve ekrandan siler
    public void VeritabaniniSifirla()
    {
        using (var baglanti = new SqliteConnection(baglantiYolu))
        {
            baglanti.Open();
            using (var komut = baglanti.CreateCommand())
            {
                // 'DELETE FROM TabloAdi' tabloyu tamamen boþaltýr
                komut.CommandText = "DELETE FROM Gorevler";
                komut.ExecuteNonQuery();

                // ID sayacýný da sýfýrlamak istersen (opsiyonel):
                komut.CommandText = "DELETE FROM sqlite_sequence WHERE name='Gorevler'";
                komut.ExecuteNonQuery();
            }
        }

        // Ekranda görünen listeyi de temizlemek için listeyi yeniliyoruz
        ListeyiYenile();
    }
}