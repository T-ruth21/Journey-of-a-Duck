using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasticBagMovement : MonoBehaviour
{
    private float x;
    private float y;
    float timer = 0;
    Vector3 tempPos;

    public SpriteRenderer sr;
    private string spriteNames = "Sprites/PlasticSheet1";
    private Sprite[] plancSprites;


    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0, 0.5f);
        plancSprites = Resources.LoadAll<Sprite>(spriteNames);
        sr.sprite = plancSprites[Random.Range(0, 4)];
        

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > 2)
        {
            timer = 0;
            if (gameObject.transform.position.y < -0.5)
            {
                x = Random.Range(-0.5f, 0.5f);
                y = Random.Range(-0.5f, 0.5f);


            }
            else
            {
                x = Random.Range(-0.5f, 0.5f);
                y = Random.Range(-0.1f, 0.1f);
            }
            tempPos = new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y + y, transform.position.z);

        }



        gameObject.transform.position = Vector3.MoveTowards(transform.position, tempPos, 0.01f * Time.deltaTime);

    }
}
