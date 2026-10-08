using System;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float JumpForce;

    private bool isGrounded = true;
    [SerializeField]
    private GameObject tochitosPrefab;

   

    private Vector3 startPos;

     
    
    private Rigidbody rb;

    private LevelManager lm;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lm = GameObject.Find("LevelManager").GetComponent<LevelManager>();
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKey(KeyCode.D))
       {
           transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.World);
           transform.eulerAngles = Vector3.zero;
           
       }
       
       if(Input.GetKey(KeyCode.A))
       {
           transform.Translate(Vector3.back * speed * Time.deltaTime,  Space.World);
           transform.eulerAngles = new Vector3(0,180,0);
       }

       if (Input.GetKeyDown(KeyCode.W) && isGrounded==true)
       {
           rb.AddForce(Vector3.up * JumpForce);
           isGrounded = false;
       }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground" || collision.gameObject.tag == "tocho")
        {
            isGrounded = true;
        }

        if (collision.gameObject.tag == "tocho")
        {
            if (collision.GetContact(0).normal == Vector3.down)
            {
                //  instantiate (objeto a instaciar, posicion, rotacion, (opcional) el transform del padre)
                GameObject clone = Instantiate(tochitosPrefab,collision.transform.position, collision.transform.rotation);
               Destroy(collision.gameObject); 
               Destroy(clone, 2);
            }
            
            
        }

        if (collision.gameObject.tag == "platform")
        {
            transform.parent = collision.transform;
            isGrounded = true;
        }

        if (collision.gameObject.tag == "enemy")
        {
           if (collision.GetContact(0).normal.y > 0.5f)
            {
                //muere el enemy
                Destroy(collision.gameObject);
                rb.AddForce(Vector3.up * JumpForce * 0.5f);
            }
            else
            {
                //muere el player
                muerteplayer();
            }
        }

        if (collision.gameObject.tag == "win")
        {
            lm.finishlevel();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "platform")
        {
            transform.parent = null;
        }    
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            GameManager.instance.gameData.totalCoins +=1;
            lm.UpdateCoinsText();
            Destroy(other.gameObject);
            
        }

        if (other.gameObject.tag == "death")
        {
            //quitamos 1 vida
            
            muerteplayer();
        }

        if (other.gameObject.tag == "champi")
        {
            transform.localScale = new Vector3(2,2,2);
            
            Destroy(other.gameObject);
        }
    }

    private void muerteplayer()
    {
        GameManager.instance.gameData.totalLives -= 1;
        if (GameManager.instance.gameData.totalLives < 0)
        {
            lm.ActivePanelGameOver();
        }
        else
        {
            transform.position = startPos;
            lm.UpdatelivesText();
            transform.localScale = new Vector3(1,1,1);
        }
    }
}
