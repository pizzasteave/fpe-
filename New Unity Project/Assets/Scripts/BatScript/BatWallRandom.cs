using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatWallRandom : MonoBehaviour
{
    public GameObject bat; 
    public Vector3 spawnValues; 
    public float spawnWait ;
    public float destroyTime;
    public int startWait;
    public bool stop;

    
    private void Start()
    {
        StartCoroutine(WaitSpawner());

    }



    IEnumerator WaitSpawner()
    {
        yield return new WaitForSeconds(startWait); 
        while(!stop)
        {
            Vector3 spawnPostion = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(0, spawnValues.y), 1);
           GameObject oldBat1 =Instantiate(bat, spawnPostion + gameObject.transform.TransformPoint(0, 0, 0), bat.transform.rotation );
          
            yield return new WaitForSeconds(destroyTime); 
            Destroy(oldBat1);
            yield return new WaitForSeconds(spawnWait);
    

        }

    }

   
}
