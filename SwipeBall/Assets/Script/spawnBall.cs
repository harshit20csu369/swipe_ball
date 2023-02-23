using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnBall : MonoBehaviour
{

    [SerializeField]
    GameObject ball;

    public void Spawn()
    {
        Instantiate(ball, new Vector3(1f, 1f, -15f), Quaternion.identity);
    }
}
