using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanctonMovement : MonoBehaviour
{

    private float x;
    private float y;
    float timer = 0;
    Vector3 tempPos;

    public SpriteRenderer sr;
    private string spriteNames = "Sprites/PlanctonSheet1";
    private Sprite[] plancSprites;


    // Start is called before the first frame update
    void Start()
    {
        timer = Random.Range(0, 0.5f);
        plancSprites = Resources.LoadAll<Sprite>(spriteNames);
        sr.sprite = plancSprites[Random.Range(0, 16)];
        int colorR = Random.Range(0, 6);
        switch (colorR)
        {
            case 0:
                sr.color = new Color(0, 0, 255, 255);
            break;
            case 1:
                sr.color = new Color(0, 255, 255, 255);
                break;
            case 2:
                sr.color = new Color(0, 255, 0, 255);
                break;
            case 3:
                sr.color = new Color(255, 255, 0, 255);
                break;
            case 4:
                sr.color = new Color(255, 0, 0, 255);
                break;
            case 5:
                sr.color = new Color(255, 0, 255, 255);
                break;
            default:
                sr.color = new Color(255, 255, 255, 255);
                break;

        }

    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if (timer > 0.5)
        {
            timer = 0;
            if (gameObject.transform.position.y < -0.4)
            {
                x = Random.Range(-0.2f, 0.2f);
                y = Random.Range(-0.2f, 0.2f);
               

            }
            else
            {
                x = Random.Range(-0.2f, 0);
                y = Random.Range(-0.2f, 0);
            }
            tempPos = new Vector3(gameObject.transform.position.x + x, gameObject.transform.position.y + y, transform.position.z);

        }

        

        gameObject.transform.position =  Vector3.MoveTowards(transform.position, tempPos, 0.05f*Time.deltaTime);

    }
}
