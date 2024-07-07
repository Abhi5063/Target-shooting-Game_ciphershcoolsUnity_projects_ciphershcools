using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] GameObject targetPreFab;
    private void Start()
    {
        InvokeRepeating("SpawnTarget", 1f, 1f);
    }

    void SpawnTarget()
    {
        float xPos = Random.Range(-7.5f, 7.5f);
        float yPos = Random.Range(-4f, 4f);

        Vector3 randomtargetPos = new Vector3 (xPos, yPos,0); 

        Instantiate(targetPreFab,randomtargetPos, Quaternion.identity);
    }
    
}
