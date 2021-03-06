using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    // Start is called before the first frame update
    public float _perfectTime;
    public float _minBorder;
    public float _maxBorder;

    void Start()
    {
        _perfectTime = Time.time;
        _minBorder = _perfectTime - 0.5f;
        _maxBorder = _perfectTime + 0.5f;
        StartCoroutine("Move");
    }


    IEnumerator Move()
    {
        yield return null;
        while (true)
        {
            transform.Translate(Vector3.left * 3f * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }
}
