using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class kusKontrol : MonoBehaviour
{

    public Sprite[] kusSprites;
    SpriteRenderer spriteRenderer;
    bool ileriHareket = true;
    int kusSayacHareket = 0;
    float kusAnimasyonZaman = 0;
    Rigidbody2D rigidbody_;
    public TextMeshProUGUI sayacText;
    int sayacPuan = 0;
    bool oyunDevamEdiyor = true;
    public GameObject oyunKontrol;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody_ = GetComponent<Rigidbody2D>();
        oyunKontrol = GameObject.FindGameObjectWithTag("oyunKontrol");
    }

    void Update()
    {
        KusAnimasyon();
        KusHareket();
    }
    void KusAnimasyon()
    {
        kusAnimasyonZaman += Time.deltaTime;
        if (kusAnimasyonZaman > 0.1f)
        {
            kusAnimasyonZaman = 0;
            if (ileriHareket)
            {

                spriteRenderer.sprite = kusSprites[kusSayacHareket];
                kusSayacHareket++;
                if (kusSayacHareket == 3)
                {
                    kusSayacHareket--;
                    ileriHareket = false;
                }
            }
            else
            {
                spriteRenderer.sprite = kusSprites[kusSayacHareket];
                kusSayacHareket--;
                if (kusSayacHareket == 0)
                {
                    kusSayacHareket++;
                    ileriHareket = true;
                }
            }
        }
    }
    void KusHareket()
    {
        if (Input.GetMouseButton(0) && oyunDevamEdiyor)
        {
            rigidbody_.linearVelocity = new Vector2(0,0);
            rigidbody_.AddForce(new Vector2(0, 20));
        }
        if (rigidbody_.linearVelocity.y > 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 20);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, -20);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "puan")
        {
            sayacPuan++;
            sayacText.text = "Puan: " + sayacPuan;
        }
        if (other.gameObject.tag == "engel")
        {
            oyunDevamEdiyor = false;
            oyunKontrol.GetComponent<oyunKontrol>().OyunBitti();
        }
    }
}
 