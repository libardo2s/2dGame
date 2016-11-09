using UnityEngine;
using System.Collections;

public class SpawScript : MonoBehaviour {

    public GameObject[] obj;
    public float spawnMin = 1f;
    public float spawnMax = 2f;

	// Use this for initialization
	void Start () {
        Spaw();
	}

    void Spaw()
    {
        Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
        //Invoke("Spaw", Random.Range(spawnMin, spawnMax));
    }
}
