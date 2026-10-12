using UnityEngine;

public class thwompcontroller : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float distanciaCaida = 5f;
    [SerializeField] private float tiempoEspera = 2f;
    private float contador;
    private bool playerdetected;
    private bool bajando;
    private Vector3 posicioninicial;

    void Start()
    {
        posicioninicial = transform.position;
    }

    void Update()
    {
        if (playerdetected)
        {
            if (bajando)
            {
                transform.Translate(Vector3.down * moveSpeed * Time.deltaTime, Space.World);

                if (transform.position.y <= posicioninicial.y - distanciaCaida)
                {
                    transform.position = new Vector3(
                        transform.position.x,
                        posicioninicial.y - distanciaCaida,
                        transform.position.z
                    );

                    bajando = false;
                    contador = tiempoEspera;
                }
            }
            else
            {
                if (!bajando && contador > 0)
                {
                    contador -= Time.deltaTime;
                    return;
                }
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime, Space.World);

                if (transform.position.y >= posicioninicial.y)
                {
                    transform.position = posicioninicial;
                    playerdetected = false;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerdetected)
        {
            playerdetected = true;
            bajando = true;
        }
    }

}