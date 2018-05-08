using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    private List<SpawnPoint> _spawnPoints;
    [SerializeField] private List<BlendInObject> BlendInObjects;

	// Use this for initialization
	void Start ()
    {
        _spawnPoints = new List<SpawnPoint>(gameObject.GetComponentsInChildren<SpawnPoint>());
        int totalObjCount = _spawnPoints.Count;
        int blendInObjCount = BlendInObjects.Count;

        while (totalObjCount >= 0)
        {
            // Chose a random spawn point and random object to spawn
            int spawnPointIndex = UnityEngine.Random.Range(0, _spawnPoints.Count);
            SpawnPoint randPt = _spawnPoints[spawnPointIndex];

            int randObjectIndex = UnityEngine.Random.Range(0, BlendInObjects.Count);
            BlendInObject randObj = BlendInObjects[randObjectIndex];

            Instantiate(randObj, randPt.transform);
            
            // Get rid of just used spawn point
            _spawnPoints.RemoveAt(spawnPointIndex);
            totalObjCount--;
        }

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
