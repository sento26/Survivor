using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Start is called before the first frame update

    public Camera camera;
    public GameObject Enemy1;

    int sideScreen; //lado de la pantalla
    float sideValueRandom;  //punto del lado entre 0 - 1
    float sideValueConverted;   // Punto exacto sacado con regla de 3

    float cameraHeight; //altura de la camara
    float cameraWidth;  //Anchura de la camara
    float cameraAspectRatio;    //Ratio de aspecto de la camara

    public float margenEnemy = 2;

    public int lvl = 1;
    public int numberEnemies = 0;
    public int numberTotalEnemies = 20;

    public Transform player;

    void Start()
    {
        cameraAspectRatio = camera.aspect; 
        cameraHeight = camera.orthographicSize * 2;
        cameraWidth = cameraHeight * cameraAspectRatio;
    }

    // Update is called once per frame
    void Update()
    {
        if(numberEnemies <= numberTotalEnemies)
        {
            EnemySpawnLevel();
            numberEnemies++;
        }

    }

    public void EnemySpawnLevel()
    {
        sideScreen = Random.Range(0, 4);
        sideValueRandom = Random.Range(0f, 1f);

        switch (sideScreen)
        {
            case 0:
                {
                    sideValueConverted = (cameraWidth * sideValueRandom) - cameraWidth / 2;
                    Instantiate(Enemy1, new Vector3(sideValueConverted, 1f, cameraHeight / 2 + margenEnemy), Quaternion.identity).GetComponent<EnemyActions>().SetPlayerTransform(player);
                    break;
                }

            case 1:
                {
                    sideValueConverted = (cameraHeight * sideValueRandom) - cameraHeight / 2;
                    Instantiate(Enemy1, new Vector3(cameraWidth / 2 + margenEnemy, 1f, sideValueConverted), Quaternion.identity).GetComponent<EnemyActions>().SetPlayerTransform(player);

                    break;
                }

            case 2:
                {
                    sideValueConverted = (cameraWidth * sideValueRandom) - cameraWidth / 2;
                    Instantiate(Enemy1, new Vector3(sideValueConverted, 1f ,- (cameraHeight / 2 + margenEnemy)), Quaternion.identity).GetComponent<EnemyActions>().SetPlayerTransform(player);
                    break;
                }

            case 3:
                {
                    sideValueConverted = (cameraHeight * sideValueRandom) - cameraHeight / 2;
                    Instantiate(Enemy1, new Vector3(-(cameraWidth / 2 + margenEnemy), 1f, sideValueConverted), Quaternion.identity).GetComponent<EnemyActions>().SetPlayerTransform(player);
                    break;
                }
        }
    }
}
