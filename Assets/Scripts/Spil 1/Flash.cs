using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Code from https://www.gamedev.tv/courses/unity-2d-rpg-combat/lectures/45669213

public class Flash : MonoBehaviour
{
    //Two SerializeField both can be changed in the unity inspector
    // This holds a material
    [SerializeField] private Material whiteFlashMat;

    //This controlls the time for when the flash should end.
    [SerializeField] private float restoreDefaultMatTime;

    //Material class set to defaultMat
    private Material defaultMat;
    //Render a sprite 
    private SpriteRenderer spriteRendere;


    //Method when the script starts
    private void Awake()
    {
        // Sets the spriteRendere to the gameobjects sprite rendere
        spriteRendere = GetComponent<SpriteRenderer>();

        // Sets the defaultMat to the Gameobjects material
        defaultMat = spriteRendere.material;
    }

    // Method called FlashRoutine
    public IEnumerator FlashRoutine()
    {
        //Change the GameObjects material to the whitelash material
        spriteRendere.material = whiteFlashMat;
        //Will wait for x amount set in the unity inspector, before running next code 
        yield return new WaitForSeconds(restoreDefaultMatTime);
        //Changes the material back
        spriteRendere.material = defaultMat;
    }
}
