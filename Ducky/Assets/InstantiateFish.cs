using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateFish : MonoBehaviour
{
    public GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        for (float i = 5; i < 30; i += 3f)
        {
            for (float j = -0.2f; j > -2; j -= 1f)
            {
                Instantiate(prefab, new Vector3(i, j, 0), Quaternion.identity);
            }
        }

        for (float i = 45; i < 70; i += 3f)
        {
            for (float j = -0.2f; j > -2; j -= 1f)
            {
                Instantiate(prefab, new Vector3(i, j, 0), Quaternion.identity);
            }
        }

        for (float i = 70; i < 85; i += 2f)
        {
            for (float j = -0.2f; j > -3; j -= 0.8f)
            {
                Instantiate(prefab, new Vector3(i, j, 0), Quaternion.identity);
            }
        }


    }

   
}
