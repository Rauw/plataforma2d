using UnityEngine;

public class apuntes : MonoBehaviour
{
    //accesibilidad (privado: solo se puede entrar desde este script), (publico : desde todos)
    //tipo variable
    //nombre variable
    //(opcional) valor

    private bool booleano = true; // bool, puede ser true o false (1 o 0)

    public int numentero = 5; // int numeros enteros 

    [SerializeField]

    private float numdecimales = 5.5f; // float numeros decimales falsos (flotante, por que guarda el numero detras de la coma)

    private string cadenasTexto = "cinco"; // string cadena de characters

    private char character  = 'c'; // char solo guarda un character

    private double numDecimal = 5.5; // guarda dos enteros el de alante y el de detras

    private Vector3 vector3D = new Vector3 (2,2,2); // vector de 3 dimensiones (x,y,z)

    private Vector2 vector2D = new Vector2 (5,7); // vector de 2 dimensiones (x,y)

    private Transform trans; // cualquier componente de unity puede ser variable

    private MeshRenderer meshrend; // otro ejemplo

    //accesibilidad, tipo metodo, nombre del metodo, parametros "()"

    // awake se ejecuta antes de todo
    private void Awake()
    { 
        Debug.Log("awake");
    }

    // se ejcuta cuando se activa el objeto
    private void OnEnable ()
    {
		Debug.Log("onebled");
	}

    //se ejecuta cuando se desactiva el objeto
    private void OnDisable()
    {
		Debug.Log("ondisabled");
	}


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		Debug.Log("Update");
	}

    //se ejecuta cada un tiempo fijado en project settings / time
    void FixedUpdate()
    {
		Debug.Log("FixedUpdate");
	}

    // se ejecuta al final del todo del frame 
    void LateUpdate()
    {
		Debug.Log("LateUpdate");
	}


    private void FerranoMola() 
    {
		Debug.Log("Hola Mundo");
	}
}
