using UnityEngine;
using System.Collections;

public class VillagerSpawner : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        Invoke("Spawn", 1000);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Spawn()
    {

        //Instantiate()

        Invoke("Spawn", 1000);
    }
}
