using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);

        // Play different sounds based on the damage value
        if (damage == 1)
        {
            FindObjectOfType<AudioManager>().Play("LowPitchBu");
        }
        else if (damage == 5)
        {
            FindObjectOfType<AudioManager>().Play("HighPitchBu");
        }
    }
}
