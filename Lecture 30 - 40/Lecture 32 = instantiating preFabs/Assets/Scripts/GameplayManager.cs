using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] GameObject targetPreFab;
    private void Start()
    {
        SpawnTarget();
    }

    void SpawnTarget()
    {
        Instantiate(targetPreFab);
    }
    
}
