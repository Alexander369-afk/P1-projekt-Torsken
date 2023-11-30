using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torsken : MonoBehaviour
{
    public float spd = 8f;
    private Rigidbody2D rb;
    public static int sceneCount = 1;
    //private bool sceneFourExecuted = false;
    [SerializeField] private int sceneCountCheck = 6;
    public GameObject Spil1;
    private int erSpil1Done = 0;
    public GameObject spil1starter;

    private void Awake()
    {
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //fra CHATGPT --> 

    IEnumerator CountDownTimer(float timer)
    {
        //float timer = 5f; // Set the initial timer value to 5 seconds
        Debug.Log("Timer koerer");

        while (timer > 0f)
        {
            // Decrease the timer by the time elapsed since the last frame
            timer -= Time.deltaTime;

            // Wait for the next frame
            yield return null;
        }

        sceneCount = sceneCount + 1;
        //Debug.Log(sceneCount);
    }
    //indtil her
    bool IsColliding()
    {
        // Check if colliding with any Collider
        Collider2D collider = Physics2D.OverlapBox(transform.position, transform.localScale, 0);
        return collider != null;
    }

    void Update()
    {
        if (sceneCountCheck == sceneCount)
        {
            Debug.Log("scene count is " + sceneCount);
            sceneCountCheck++;
        }

        /**
        sceneCount 1: Torsken svoemmer hen til bakterie
        sceneCount 2: Torsken stopper ved bakterie og timer starter
        sceneCount 3: Timer er igang + snakker med bakterie
        sceneCount 4: Timer stopper og torsken svoemmer hurtigt mod sten (CUT SCENE)
        sceneCount 5: Torsken stopper ved stenen og spil 1 starter
        sceneCount 6: Spillet bliver forklaret
        sceneCount 7: SPIL 1 STARTER!!!!
        sceneCount 8: SPIL 1 I GANG
        sceneCount 9: Svoemmer op til vandmaend
        sceneCount 10:
        sceneCount 11:
        sceneCount 12:
        sceneCount 13:
        sceneCount 14:
        sceneCount 15:
        **/


        if (sceneCount == 1)
        {
            transform.Translate(Vector2.right * spd * Time.deltaTime);
            bool i = BakterieStop.nxtScnBak;
            if (i == true)
            {
                Debug.Log("Box Collider 1");
                sceneCount++;
            }

        }

        if (sceneCount == 2)
        {
            StartCoroutine(CountDownTimer(5f));
            sceneCount++;
        }

        /*if (sceneCount == 3)
        {

        }*/

        if (sceneCount == 4)
        {
            spd = 15f;
            transform.Translate(new Vector2(spd * Time.deltaTime, 0.01f));

            transform.Translate(Vector2.right * spd * Time.deltaTime);
            bool i = BaktiereSpil.nxtScnSpl1;
            if (i == true)
            {
                Debug.Log("Box Collider 2");
                sceneCount++;
            }
        }

        if (sceneCount == 5) {
            Debug.Log("Ankommet til sten + forklar spillet");
            StartCoroutine(CountDownTimer(4f));

            //spil1starter = Instantiate(Spil1);                                //Starter spil 1
            spil1starter.SetActive(true);

            sceneCount++;

        }

        if (sceneCount == 7) {
            //spd = 2;
            Debug.Log("Spillet er i gang");
            //transform.Translate(Vector2.right * spd * Time.deltaTime);

            sceneCount++;
        }

        if (sceneCount == 8)
        {
            //erSpil1Done = Path.spil1done;
            spd = 3;
            transform.Translate(Vector2.right * spd * Time.deltaTime);      //Spiller spil 1

            bool i = VandmaendStop.nxtScnVnmd;
            if (i == true)
            {
                Debug.Log("Box Collider 3");

                Destroy(spil1starter);                                       //Slutter spil 1
                StartCoroutine(CountDownTimer(3f));
                sceneCount++;
            }
        }

        if (sceneCount == 10)
        {
            StartCoroutine(CountDownTimer(3f));

            sceneCount++;
        }

        if (sceneCount == 11) {
            spd = 3f;
            transform.Translate(new Vector2(spd * Time.deltaTime, -0.01f));
        }

        if (sceneCount == 12)
        {
            StartCoroutine(CountDownTimer(3f));
            sceneCount++;

        }

        if (sceneCount == 14)
        {
            spd = 1.5f;
            transform.Translate(new Vector2(spd * Time.deltaTime, 0.03f));     //Svoemmer op til vandmaend
        }

    }

    private void FixedUpdate()
    {

    }
}