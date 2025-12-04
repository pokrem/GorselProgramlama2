using UnityEngine;

public class kucukCemberKod : MonoBehaviour
{   
    Rigidbody2D rigidbody2D;
    bool carpiMi = false;
    public int hiz;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()

    {
        if (!carpiMi)
        {
            rigidbody2D.MovePosition(rigidbody2D.position*Vector2.up*hiz*Time.deltaTime);
        }
        

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("donenCember"))
        {
            
            carpiMi = true;
            transform.SetParent(other.transform);
        }

        if(other.gameObject.CompareTag("kucukCember")){
            
        Debug.Log("oyun bitti");
        
    }
    }
    
}
