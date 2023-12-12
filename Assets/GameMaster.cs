using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    void ScriptMaster(Collider2D other)
    {
        if (other.CompareTag("Minispil2E"))
        {
            isScriptActive = true;
        }
        else if (other.CompareTag("Minispil3E"))
        {
            isScriptActive = false;
        }
    }
}

