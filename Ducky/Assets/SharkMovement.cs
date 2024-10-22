using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovement : MonoBehaviour
{
    private float x;
    private float y;
    float timer = 0;
    float timerRange;
    Vector3 tempPos;

    public SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        timerRange = Random.Range(4.0f, 10.0f);
    }

    void Update()
    {

        timer += Time.deltaTime;
        if (timer > timerRange)
        {
            timer = 0;
            timerRange = Random.Range(4.0f, 10.0f);
            if (gameObject.transform.position.y < -0.4)
            {
                x = Random.Range(-10.2f, 10.5f);
                y = Random.Range(-0.5f, 0.5f);
                //if (transform.position.y < -2f)
                //{
                //    x = Random.Range(-10.0f, 10.5f);
                //    y = Random.Range(0, 0.2f);
                //}

            }
            else
            {
                x = Random.Range(-10.5f, 10.5f);
                y = Random.Range(-0.2f, 0);
            }
            tempPos = new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y + y, transform.position.z);
            if (tempPos.x < transform.position.x)
            {
                sr.flipX = false;
            }
            else
            {
                sr.flipX = true;
            }
        }



        gameObject.transform.position = Vector3.MoveTowards(transform.position, tempPos, 0.3f * Time.deltaTime);

    }
}
