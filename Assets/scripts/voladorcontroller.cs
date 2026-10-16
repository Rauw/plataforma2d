using UnityEngine;

public class voladorcontroller : MonoBehaviour
{
    [SerializeField] private bool volador;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float direccion = 1;
    private bool playerdetected;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerdetected)
        { 
               
            if (transform.tag == "volador")
            {
                transform.Translate(new Vector3(0,direccion,0)* moveSpeed * Time.deltaTime);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerdetected = true;
        }

        if (other.gameObject.tag == "limiteenemigo")
        {
            if (direccion == 1)
            {
                direccion = -1;
            }else 
            {
                direccion = 1;
            }
        }
    }
}
