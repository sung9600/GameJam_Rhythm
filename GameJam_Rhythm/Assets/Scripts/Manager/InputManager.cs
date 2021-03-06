using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            float _diffTime = Mathf.Abs(GameManager.Instance._perfectTimes[0] - Time.time);
            if (_diffTime < 0.5f)
            {
                Debug.Log("Perfect");

            }
            else
            {
                Debug.Log("Bad");
            }
            GameManager.Instance._perfectTimes.RemoveAt(0);
        }
    }
}
