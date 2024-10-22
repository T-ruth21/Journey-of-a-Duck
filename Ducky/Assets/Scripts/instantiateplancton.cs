using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instantiateplancton : MonoBehaviour
{
    public GameObject prefab;
    


    // Start is called before the first frame update
    void Start()
    {
        for (float i = 30; i < 40; i += 2f)
        {
            for (float j = -0.2f; j > -4; j -= 2f)
            {
                Instantiate(prefab, new Vector3(i, j, 0), Quaternion.identity);
            }
        }

        for (float i = 40; i < 60; i+= 0.5f)
        {
            for (float j = -0.2f; j > -4 ; j -= 0.5f)
            {
                Instantiate(prefab, new Vector3(i, j, 0), Quaternion.identity);
            }
        }

        for (float i = 60; i < 70; i += 2f)
        {
            for (float j = -0.2f; j > -4; j -= 2f)
            {
                Instantiate(prefab, new Vector3(i, j, 0), Quaternion.identity);
            }
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
