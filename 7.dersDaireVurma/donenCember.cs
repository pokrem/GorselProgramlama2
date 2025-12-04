using UnityEngine;

public class donenCemberC : MonoBehaviour
{
    public int hiz;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
     transform.Rotate(0,0,hiz*Time.deltaTime);
    }
}
