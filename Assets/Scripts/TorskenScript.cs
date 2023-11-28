using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torsken : MonoBehaviour
{
    public float spd = 8f;
    private Rigidbody2D rb;
    public static int sceneCount = 1;
    private bool sceneFourExecuted = false;
    [SerializeField] private int sceneCountCheck = 1;
    public GameObject Spil1;

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
        Debug.Log("Timer k�rer");

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
        if(sceneCountCheck == sceneCount)
        {
            Debug.Log("scene count is " + sceneCount);
            sceneCountCheck++;
        }

        /**
        sceneCount 1: Torsken sv�mmer hen til bakterie
        sceneCount 2: Torsken stopper ved bakterie og timer starter
        sceneCount 3: Timer er igang + snakker med bakterie
        sceneCount 4: Timer stopper og torsken sv�mmer hurtigt mod sten (CUT SCENE)
        sceneCount 5: Torsken stopper ved stenen og spil 1 starter
        sceneCount 6: Spillet bliver forklaret
        sceneCount 7: SPIL 1 STARTER!!!!
        sceneCount 8: SPIL 1 DONE
        sceneCount 9: Sv�mmer op til vandm�nd
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
        }

        if (sceneCount == 2)
        {
            StartCoroutine(CountDownTimer(5f));
            sceneCount = sceneCount + 1;
        }

        /**if (sceneCount == 3)
        { 
            
        }**/

        if (sceneCount == 4)
        {
            spd = 15f;
            transform.Translate(new Vector2(spd * Time.deltaTime, 0.005f));

        }

        if (sceneCount == 5)
        {
            Debug.Log("Ankommet til sten + forklar spillet");
            StartCoroutine(CountDownTimer(4f));
            sceneCount = sceneCount + 1;
        }

        /*if (sceneCount == 6)
        {

        }*/

        if (sceneCount == 7)
        {
            spd = 2;
            Debug.Log("Spillet er i gang");
            transform.Translate(Vector2.right * spd * Time.deltaTime);

            GameObject spil1starter = Instantiate(Spil1);
            spil1starter.SetActive(true);                                   //Starter spil 1

            sceneCount = sceneCount + 1;
        }

        if(sceneCount == 8)
        {
            spd = 3;
            transform.Translate(Vector2.right * spd * Time.deltaTime);      //Spiller spil 1
        }

        if (sceneCount == 10)
        {
            spd = 1.5f;
            transform.Translate(Vector2.right * spd * Time.deltaTime);      //Sv�mmer op til vandm�nd
            StartCoroutine(CountDownTimer(2f));

            GameObject spil1starter = Instantiate(Spil1);
            spil1starter.SetActive(false);                                   //Slutter spil 1
        }

        //Debug.Log(sceneCount);

    }

    private void FixedUpdate()
    {
        if (IsColliding() && sceneCount == 1)
        {
            sceneCount = sceneCount + 1;
        }

        if (IsColliding() && sceneCount == 4)
        {
            sceneCount = sceneCount + 1;
        }

        if (IsColliding() && sceneCount == 9)
        {
            sceneCount = sceneCount + 1;
        }
        /**for (int i = 0; i < sceneCount; i++)

        {
            Debug.Log("Scene count is " + sceneCount);
        }**/
    }
}