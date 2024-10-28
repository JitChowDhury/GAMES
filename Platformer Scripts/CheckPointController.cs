using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointController : MonoBehaviour
{
    public static CheckPointController Instance;

    private CheckPoint[] checkPoints;
    public Vector3 spawnPoint;
    // Start is called before the first frame update
    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        checkPoints = FindObjectsOfType<CheckPoint>();
        spawnPoint = PlayerController.instance.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DeactivateCheckPoint()
    {
        for (int i = 0; i < checkPoints.Length; i++)
        {
            checkPoints[i].resetCheckPoint();
        }
    }

    public void setSpawnPoint(Vector3 newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;

    }
}
