using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject ball;
    Vector3 offset;
    public float lerpRate;

    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        offset = ball.transform.position - transform.position; //diffrence betwen the ball and the camera
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameOver)
        {
            Follow(); 
        }
    }

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset; //position of the ball, and comes back with the camera the value of the offset
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime); //goes from one value (pos) to another value (targetPos) with a rate
        transform.position = targetPos;
    }


}
