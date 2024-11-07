using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class collentive : MonoBehaviour
{
    public GameObject originalPrefab;
    public float fromX;
    public float toX;
    public float fromZ;
    public float toZ;

    public int collectiblesCount = 10;



    public void Awake()
    {
        for (int i = 0; i < collectiblesCount; i++)
        {



            Instantiate(
                originalPrefab,
                new Vector3(Random.Range(0, 15), 0, Random.Range(1, 19)),
                Quaternion.identity,
                transform
                );

        }


    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(
            new Vector3(fromX, 0.5f, fromZ),
            new Vector3(fromX, 0.5f, toZ)
            );
        Gizmos.DrawLine(
            new Vector3(fromX, 0.5f, fromZ),
            new Vector3(toX, 0.5f, fromZ)
            );
        Gizmos.DrawLine(
          new Vector3(toX, 0.5f, toZ),
          new Vector3(toX, 0.5f, fromZ)

          );
     Gizmos.DrawLine(
            new Vector3(toX, 0.5f, toZ),
            new Vector3(fromX, 0.5f, toZ)


            );
    }

}

