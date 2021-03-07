using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Note"))
        {
            //Debug.Log("Trigger Destroy"); 
            if (GameManager.Instance.Notes.Contains(other.gameObject))
                GameManager.Instance.Notes.Remove(other.gameObject);
            GameManager.Instance.Bad();
            Destroy(other.gameObject);
        }
    }
}
