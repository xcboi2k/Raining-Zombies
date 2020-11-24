using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    void Update()
    {
        Destroy(gameObject, 10f);
    }
}
