using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorLauncher : MonoBehaviour {

    [SerializeField]
    private float distanceOfOrigin;
    [SerializeField]
    private float numberOfSpawns;
    [SerializeField]
    GameObject meteor;
    [SerializeField]
    private float timeOfNextSpawn;

    private float timer=0.0f;
	// Use this for initialization
	void Start () {
		for(int i=0; i < numberOfSpawns; i++)
        {
            SpawnMeteore();
        }
	}
    void SpawnMeteore()
    {
        Vector3 position = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized * distanceOfOrigin;
        var gameObject = Instantiate(meteor, position, Quaternion.identity);
        gameObject.transform.parent = transform;
    }
	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;
        if (timer >= timeOfNextSpawn)
        {
            SpawnMeteore();
            timer = 0;
        }
	}
}
