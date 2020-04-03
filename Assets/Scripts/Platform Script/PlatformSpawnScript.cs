using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnScript : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject platformPrefab;
    public GameObject spikePlatformPrefab;
    public GameObject[] movingPlatforms;
    public GameObject breakablePlatformPrefab;

    public float platformSpawnTimer = 2f;
    private float currentPlatformSpawnTimer;

    private int platformSpawnCount;

    public float min_X = -2f, max_X = 2f;

    void Start()
    {
        currentPlatformSpawnTimer = platformSpawnTimer;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnPlatform();
    }
    
    void SpawnPlatform(){

        currentPlatformSpawnTimer += Time.deltaTime;

        if(currentPlatformSpawnTimer >= platformSpawnTimer){
            platformSpawnCount++;

            Vector3 temp = transform.position;
            temp.x = Random.Range(min_X, max_X);

            GameObject newPlatform = null;

            if(platformSpawnCount<2){
                newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
            } else if(platformSpawnCount == 2){

                if(Random.Range(0,2)>0){
                    newPlatform = Instantiate(platformPrefab, temp, Quaternion.identity);
                }else{
                    newPlatform = Instantiate(
                        movingPlatforms[Random.Range(0,movingPlatforms.Length)],
                         temp, Quaternion.identity);                         
                }
            } else if(platformSpawnCount == 3){
                if(Random.Range(0,2)>0){
                    newPlatform = Instantiate(platformPrefab,
                    temp, Quaternion.identity);
                }else{
                    newPlatform = Instantiate(spikePlatformPrefab,
                    temp, Quaternion.identity);                         
                }

            } else if(platformSpawnCount == 4){
                if(Random.Range(0,2)>0){
                    newPlatform = Instantiate(platformPrefab,
                    temp, Quaternion.identity);
                }else{
                    newPlatform = Instantiate(breakablePlatformPrefab,
                    temp, Quaternion.identity);                         
                }
                platformSpawnCount = 0;//resets  spawntime and helps..
                //...in avoiding null reference error
            }   
            
            if(newPlatform){
                newPlatform.transform.parent = transform;
            }//so that we dont get null reference error coz of line 42
            
             

            currentPlatformSpawnTimer = 0f;

        } //spawn platform ends here




    }





    
}
