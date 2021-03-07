using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public void playPushUp()
    {
        gameObject.GetComponent<Animator>().Play("Push_Up");
    }
    public void playSquat()
    {
        gameObject.GetComponent<Animator>().Play("Squat");
    }
}
