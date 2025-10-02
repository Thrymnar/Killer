using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controll : MonoBehaviour
{
    private int n1;
    private int n2;
    public GameObject obj1;
    public GameObject obj2;
    void Start()
    {
        n1 = 100;
        n2 = 100;
    }
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Barrier"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Character1"))
        {
            n1 = n1 - 50;
            Destroy(gameObject);
            if (n1 == 0)
            {
                Destroy(obj1);
                Debug.Log(n1);
            }
        }
        if (other.CompareTag("Character2"))
        {
            n2 = n2 - 50;
            Destroy(gameObject);
            if (n2 == 0)
            {
                Destroy(obj2);
                Debug.Log(n2);
            }
        }
    }
}
