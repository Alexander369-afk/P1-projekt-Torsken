using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flash : MonoBehaviour
{
    [SerializeField] private Material whiteFlashMat;
    [SerializeField] private float restoreDefaultMatTime = .2f;

    private Material defaultMat;
    private SpriteRenderer spriteRendere;

    private void Awake()
    {
        spriteRendere = GetComponent<SpriteRenderer>();
        defaultMat = spriteRendere.material;
    }

    public IEnumerator FlashRoutine()
    {
        spriteRendere.material = whiteFlashMat;
        yield return new WaitForSeconds(restoreDefaultMatTime);
        spriteRendere.material = defaultMat;
    }
}
