using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformSpawner : MonoBehaviour
{

    public GameObject platform;
    public GameObject diamond;

    Vector3 lastPos;
    float size;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;
        
        for(int i = 0; i < 20; i++)
        {
            SpawnPlatforms();
        }
        
    }

    public void StarSpawning()
    {
        InvokeRepeating("SpawnPlatforms", 0.1f, 0.2f); //waits 0.1 seconds and then each 0.2 seconds it will call the function
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver) {
            CancelInvoke("SpawnPlatforms");
        }

    }

    void SpawnPlatforms()
    {
        

       int rand = Random.Range(0, 6); //0 to 5
       
        if(rand < 3)
        {
            SpawnX();
        }
        if (rand >= 3)
        {
            SpawnZ();
        }

    }

    void SpawnX()
    {
        Vector3 pos = lastPos; //take the postition of the last platform
        pos.x += size; //increments the position to stay on the side of the last one
        lastPos = pos; //updates the las platform position
        Instantiate(platform, pos,Quaternion.identity); //clone the object platform in the position pos, with no rotation.        

        SpawnDiamond(pos);

    }
    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(platform, pos, Quaternion.identity); //clone the object platform in the position pos, with no rotation.

        SpawnDiamond(pos);
    }

    void SpawnDiamond(Vector3 pos)
    {
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond,new Vector3 (pos.x,pos.y+1,pos.z), diamond.transform.rotation);
        }
    }
}
