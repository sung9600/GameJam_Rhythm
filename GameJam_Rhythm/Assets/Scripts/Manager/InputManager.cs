using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Transform textpos;
    public Transform textpos2;
    public static Transform[] judge;
    public static LayerMask layerMask;
    public float maxDistance = 3f;
    public float perfectDist = 0.75f;
    public float goodDist = 1.75f;
    public GameObject target = null;
    public GameObject target2 = null;
    // Update is called once per frame

    private void Awake()
    {
        layerMask = 1 << LayerMask.GetMask("Note");
        judge = new Transform[2];
        judge[0] = GameObject.Find("Judge").transform;
        judge[1] = GameObject.Find("Judge2").transform;
    }
    // private void OnDrawGizmos()
    // {
    //     Debug.DrawRay(judge[0].transform.position, Vector3.left * 1f, Color.red);
    //     Debug.DrawRay(judge[1].transform.position, Vector3.left * 1f, Color.red);
    // }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            RaycastHit[] hit;
            hit = Physics.RaycastAll(judge[0].position, Vector3.left, maxDistance);
            float xPos = 0f;
            foreach (RaycastHit hitt in hit)
            {
                if (hitt.transform.position.x > xPos)
                {
                    target = hitt.transform.gameObject;
                    xPos = hitt.transform.position.x;
                }
            }
            if (target != null && target.CompareTag("Note"))
            {
                float dist = (judge[0].position.x - target.transform.position.x);
                if (dist < perfectDist && dist > -perfectDist)//Perfect
                {
                    GameManager.Instance.Perfect();
                    GameManager.Instance.Score();
                    Destroy(GameManager.Resource.Instantiate("UI/text_Perfect", textpos), 0.5f);
                }
                else if (dist < goodDist) //good
                {
                    GameManager.Instance.Good();
                    GameManager.Instance.Score();
                    Destroy(GameManager.Resource.Instantiate("UI/text_Good", textpos), 0.5f);
                }
                else//bad
                {
                    GameManager.Instance.Bad();
                    Destroy(GameManager.Resource.Instantiate("UI/text_Bad", textpos), 0.5f);
                }
                Destroy(target);
                GameManager.Instance.Score();
                target = null;
            }
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            RaycastHit[] hit;
            hit = Physics.RaycastAll(judge[1].position, Vector3.left, maxDistance);
            float xPos = 0f;
            foreach (RaycastHit hitt in hit)
            {
                if (hitt.transform.position.x > xPos)
                {
                    target2 = hitt.transform.gameObject;
                    xPos = hitt.transform.position.x;
                }
            }
            if (target2 != null && target2.CompareTag("Note"))
            {
                float dist = (judge[1].position.x - target2.transform.position.x);
                if (dist < perfectDist && dist > -perfectDist)//Perfect
                {
                    GameManager.Instance.Perfect();
                    GameManager.Instance.Score();
                    Destroy(GameManager.Resource.Instantiate("UI/text_Perfect", textpos2), 0.5f);
                }
                else if (dist < goodDist) //good
                {
                    GameManager.Instance.Good();
                    GameManager.Instance.Score();
                    Destroy(GameManager.Resource.Instantiate("UI/text_Good", textpos2), 0.5f);
                }
                else//bad
                {
                    GameManager.Instance.Bad();
                    Destroy(GameManager.Resource.Instantiate("UI/text_Bad", textpos2), 0.5f);
                }
                Destroy(target2);
                target2 = null;
            }
        }
    }
}
