using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Camera cam;

    public GameObject ending;

    public Rigidbody2D rb;
    public SpriteRenderer sr;
    private string spriteNames = "Sprites/DuckySpritesheet1";
    private Sprite[] duckSprites;


    private bool rightfoot = false;
    public bool upsideDown = false;


    public float thrust = 1;
    public Color darkDuck;
    public Color lightDuck;

    public float progress;

    [FMODUnity.EventRef]
    public string athmo;
    [FMODUnity.EventRef]
    public string paddle;
    [FMODUnity.EventRef]
    public string turn1;
    [FMODUnity.EventRef]
    public string turn2;
    [FMODUnity.EventRef]
    public string quak;
    [FMODUnity.EventRef]
    public string music1;
    [FMODUnity.EventRef]
    public string music2;

    FMOD.Studio.EventInstance musicIntance;
    //FMOD.Studio.ParameterInstance musicFade;
    float musicFade;

    FMOD.Studio.EventInstance athmoInstance;
    //FMOD.Studio.ParameterInstance overunder;
    float overunder;

    private bool musicPlaying = false;
    private bool music2Playing = false;



    // Start is called before the first frame update
    void Start()
    {
        cam.GetComponent<Camera>();
        duckSprites = Resources.LoadAll<Sprite>(spriteNames);
        sr.sprite = duckSprites[0];
        athmoInstance = FMODUnity.RuntimeManager.CreateInstance(athmo);
        //athmoInstance.getParameter("OverUnder", out overunder);
        athmoInstance.start();

        musicIntance = FMODUnity.RuntimeManager.CreateInstance(music1);
        //musicIntance.getParameter("MusicFade", out musicFade);


    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x < 97f)

        {
            progress = gameObject.transform.position.x;
            
            if (Input.GetKeyDown(KeyCode.Q))
            {
                FMODUnity.RuntimeManager.PlayOneShotAttached(quak, gameObject);
                StartCoroutine(Quak());
            }


            if (Input.GetKeyDown(KeyCode.D))
            {
                if (rightfoot == false)
                {
                    rb.AddForce(new Vector2(thrust, 0), ForceMode2D.Impulse);
                    rightfoot = true;
                    StartCoroutine(PaddleRight());
                }
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                if (rightfoot)
                {
                    rb.AddForce(new Vector2(thrust, 0), ForceMode2D.Impulse);
                    rightfoot = false;
                    StartCoroutine(PaddleLeft());
                }
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                upsideDown = !upsideDown;
                StartCoroutine(FlipDuck(upsideDown));


            }

            if (progress < 10)
            {

            }

            if (progress >= 30 && progress < 40)
            {
                float temp = 255 - (10 - (40 - progress));
                sr.color = new Color(temp /* 23*/, temp /* 21*/, temp /* 53*/);
                

                //for (float f = 1f; f >= 0; f -= 0.1f)
                //{
                //    Color c = renderer.material.color;
                //    c.a = f;
                //    renderer.material.color = c;
                //}
            }

            if (progress >= 20 && !musicPlaying)
            {
                musicIntance.start();
                musicPlaying = true;
            }

            if (progress <= 40)
            {
                cam.orthographicSize = 1 + progress / 20;
            }

            if (progress >= 60)
            {
                cam.orthographicSize = 1 + (100 - progress) / 20;
            }

            if (progress > 80 && progress < 85)
            {
                //musicFade.setValue((progress-80) / 5);
                musicIntance.setParameterByName("MusicFade", 0);
            }

            if (progress > 95 && !music2Playing)
            {
                FMODUnity.RuntimeManager.PlayOneShot(music2);
                music2Playing = true;
            }

            if (progress > 96.9f) 
            {
                StartCoroutine(Ending());
            }

        }
    }

    private IEnumerator FlipDuck(bool down)
    {
        sr.flipY = !sr.flipY;

        if (down)
        {
            
            for (float f = 0.5f; f >= -0.5f; f -= 0.1f)
            {
                cam.transform.position = new Vector3(cam.transform.position.x, f, cam.transform.position.z);
                yield return null;
                //overunder.setValue(1);
                athmoInstance.setParameterByName("OverUnder", 1);
                
            }
            FMODUnity.RuntimeManager.PlayOneShotAttached(turn1, gameObject);

        } else
        {
            for (float f = -0.5f; f <= 0.5f; f += 0.1f)
            {
                cam.transform.position = new Vector3(cam.transform.position.x, f, cam.transform.position.z);
                yield return null;
                //overunder.setValue(0);
                athmoInstance.setParameterByName("OverUnder", 0);
            }
            FMODUnity.RuntimeManager.PlayOneShotAttached(turn2, gameObject);
        }

    }

    private IEnumerator Quak()
    {
        sr.sprite = duckSprites[4];
        yield return new WaitForSeconds(0.2f);
        sr.sprite = duckSprites[0];
    }

    private IEnumerator PaddleRight()
    {

        sr.sprite = duckSprites[1];
        yield return new WaitForSeconds(0.2f);
        sr.sprite = duckSprites[0];
        FMODUnity.RuntimeManager.PlayOneShotAttached(paddle, gameObject);


    }

    private IEnumerator PaddleLeft()
    {

        sr.sprite = duckSprites[3];
        yield return new WaitForSeconds(0.2f);
        sr.sprite = duckSprites[0];
        FMODUnity.RuntimeManager.PlayOneShotAttached(paddle, gameObject);

    }

    private IEnumerator Ending()
    {
        yield return new WaitForSeconds(3);
        ending.SetActive(true);
    }



}
