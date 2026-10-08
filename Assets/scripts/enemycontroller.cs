using System;
using UnityEngine;

public class enemycontroller : MonoBehaviour
{
    [SerializeField] private bool tonto;
    [SerializeField] private float moveSpeed;
    private bool playerdetected;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerdetected) //=(playerdetected==true)
        {
            transform.Translate(Vector3.back * moveSpeed * Time.deltaTime);
            if (!tonto) // = (tonto == false)
            {
                                                                                       
            }
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerdetected = true;
        }

        if (other.gameObject.tag == "limiteenemigo" && tonto == false)
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            transform.eulerAngles += new Vector3(0, 180, 0);
        }
    }
}
