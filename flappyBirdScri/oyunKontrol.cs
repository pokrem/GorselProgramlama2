using UnityEngine;

public class oyunKontrol : MonoBehaviour
{
    public GameObject Gokyuzu1;
    public GameObject Gokyuzu2;

    private Rigidbody2D rigidbbody1_;
    private Rigidbody2D rigidbbody2_;

    public float arkaPlanHiz = -1.5f;

    private float uzunluk;

    public GameObject engel;
    public int kacAdetEngel = 5;
    GameObject[] engeller;

    public float zamanSayac;
    int sayac = 0;

    void Start()
    {
        if (Gokyuzu1 != null && Gokyuzu2 != null)
        {
            rigidbbody1_ = Gokyuzu1.GetComponent<Rigidbody2D>();
            rigidbbody2_ = Gokyuzu2.GetComponent<Rigidbody2D>();

            if (rigidbbody1_ != null)
                rigidbbody1_.linearVelocity = new Vector2(arkaPlanHiz, 0);

            if (rigidbbody2_ != null)
                rigidbbody2_.linearVelocity = new Vector2(arkaPlanHiz, 0);

            BoxCollider2D collider = Gokyuzu1.GetComponent<BoxCollider2D>();
            if (collider != null)
            {
                uzunluk = collider.size.x * Gokyuzu1.transform.localScale.x;
            }
            else
            {
                Debug.LogError("Gokyuzu1 objesinde BoxCollider2D bulunamadı! Döngü çalışmayabilir.");
            }
        }
        else
        {
            Debug.LogError("Gökyüzü objelerinden biri veya ikisi atanmamış! Lütfen Hiyerarşi'den atayın.");
        }


        engeller = new GameObject[kacAdetEngel];

        for (int i = 0; i < engeller.Length; i++)
        {

            Vector3 poz = new Vector3(-20 + i * 6f, Random.Range(-1.5f, 1.5f), 0f);
            engeller[i] = Instantiate(engel, poz, Quaternion.identity);


            Rigidbody2D rigidbodyEngel = engeller[i].GetComponent<Rigidbody2D>();
            if (rigidbodyEngel == null)
                rigidbodyEngel = engeller[i].AddComponent<Rigidbody2D>();

            rigidbodyEngel.gravityScale = 0;
            rigidbodyEngel.linearVelocity = new Vector2(arkaPlanHiz, 0);
        }
    }

    void Update()
    {
        ArkaPlanHareket();
        EngelHareket();
    }

    void ArkaPlanHareket()
    {
        if (Gokyuzu1 != null && uzunluk > 0 && Gokyuzu1.transform.position.x <= -uzunluk)
        {
            Gokyuzu1.transform.position += new Vector3(uzunluk * 2f, 0, 0);
        }

        if (Gokyuzu2 != null && uzunluk > 0 && Gokyuzu2.transform.position.x <= -uzunluk)
        {
            Gokyuzu2.transform.position += new Vector3(uzunluk * 2f, 0, 0);
        }
    }
    void EngelHareket()
    {
        zamanSayac += Time.deltaTime;
        if (zamanSayac >= 1)
        {
            zamanSayac = 0;
            float Yekseni = Random.Range(-0.1f, 1.24f); 
            engeller[sayac].transform.position = new Vector3(5.13f, Yekseni);
            sayac++;
            if (sayac == 5) {
                sayac = 0;
            }
        }
    }
    public void OyunBitti()
    {
        rigidbbody1_.linearVelocity = new Vector2(0, 0);
        rigidbbody2_.linearVelocity = new Vector2(0, 0);


        for (int i = 0; i < engeller.Length; i++)
        {
            Rigidbody2D rigidbodyEngel = engeller[i].GetComponent<Rigidbody2D>();
            if (rigidbodyEngel != null)
            {
                rigidbodyEngel.linearVelocity = new Vector2(0, 0);
            }
        }
    }
}