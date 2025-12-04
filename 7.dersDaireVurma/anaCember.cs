using UnityEngine;

public class anaCember : MonoBehaviour
{
    public GameObject kucukCember;
    public GameObject donenCember;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(kucukCember,transform.position,transform.rotation);
        }
    }
}
