using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    public float _moveSpd = 5f;

    void Start()
    {
        StartCoroutine("Move");
    }

    IEnumerator Move()
    {
        yield return null;
        while (true)
        {
            transform.Translate(Vector3.right * _moveSpd * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
