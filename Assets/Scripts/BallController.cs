using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public GameObject particle;

    [SerializeField] //Even private we can see the variable speen in the unity
    private float speed;
    Rigidbody rb;
    bool started;
    bool gameOver;

    private void Awake() //this function is called before the game start
    {
        rb = GetComponent<Rigidbody>(); 
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0)) //-> left click of the mouse, touch screen
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;

                GameManager.instance.StartGame();
            }
        }

       // Debug.DrawRay(transform.position, Vector3.down, Color.red); //if you want to see where your ray is.

        if (!Physics.Raycast(transform.position, Vector3.down, 1f)) //verify if it's colliding with other game objec down
        {                                                           //ray it's like a line set with the position of the ball, and down the ball with maxPosition 1
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0); //makes fall down

            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            FindObjectOfType<platformSpawner>().gameOver = true;

            GameManager.instance.GameOver();
            
        }

        if (Input.GetMouseButtonDown(0) && !gameOver) //-> left click of the mouse, touch screen
        {
            SwichDirection();
        }
    }

    void SwichDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        } else if (rb.velocity.x > 0){
            rb.velocity = new Vector3(0, 0, speed);
        }
    }


    //detring the diamonds
    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(part, 3f);
        }
    }
}
