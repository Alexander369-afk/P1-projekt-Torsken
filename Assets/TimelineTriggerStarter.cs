// https://stackoverflow.com/questions/76324857/how-to-start-the-timeline-when-the-player-enters-the-trigger-area

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TimelineTriggerStarter : MonoBehaviour
{
    public string cutsceneKey;
    void OnTriggerEnter2D(Collider2D other)
    {
        CutsceneManager.Instance.StartCutscene(cutsceneKey);
    }
}