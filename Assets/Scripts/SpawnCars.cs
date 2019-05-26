using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCars : MonoBehaviour
{
    public GameObject carPrefab;
    public float respawnTime = 5.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,
            Screen.height, Camera.main.transform.position.z));
        StartCoroutine(carSpawn());
    }

    private void spawnCar()
    {
        GameObject c = Instantiate(carPrefab) as GameObject;
        c.transform.position = new Vector2(screenBounds.x * 2, -260f);
    }

   IEnumerator carSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnCar();
        }
        
    }
}
