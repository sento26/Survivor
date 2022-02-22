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

    void Start()
    {
        cameraAspectRatio = camera.aspect; 
        cameraHeight = camera.orthographicSize * 2;
        cameraWidth = cameraHeight * cameraAspectRatio;
    }

    // Update is called once per frame
    void Update()
    {
        sideScreen = Random.Range(0, 3);
        sideValueRandom = Random.Range(0f, 1f);

        print(sideValueRandom);

        switch (sideScreen)
        {
            case 0:
                {
                    sideValueConverted = (cameraWidth * sideValueRandom) - cameraWidth / 2;
                    Instantiate(Enemy1, new Vector3(sideValueConverted, cameraHeight / 2 + margenEnemy, 0f), Quaternion.identity);
                    break;
                }
                /*
            case 1:
                {
                    sideValueConverted = (cameraWidth * sideValueRandom);
                    Instantiate(Enemy1, new Vector3(10.2f, sideValueConverted, 0f), Quaternion.identity);
                    break;
                }

            case 2:
                {
                    sideValueConverted = (cameraHeight * sideValueRandom);
                    Instantiate(Enemy1, new Vector3(sideValueConverted, -5.5f, 0f), Quaternion.identity);
                    break;
                }

            case 3:
                {
                    sideValueConverted = (cameraWidth * sideValueRandom);
                    Instantiate(Enemy1, new Vector3(-10.2f, sideValueConverted, 0f), Quaternion.identity);
                    break;
                }
                */
        }

    }
}
