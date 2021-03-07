using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScene : MonoBehaviour
{
    public GameObject ScoreTransfer;
    public bool success;
    int[] _sum; //Perfet Good Bad 순서
    public int Rank = 0; // 1:F 2:C 3:B 4:A
    public Sprite[] sprites;
    private void Awake()
    {
        _sum = new int[3];
        ScoreTransfer = GameObject.Find("ScoreTransfer");
        _sum = ScoreTransfer.GetComponent<ScoreTransfer>().sum;
        success = ScoreTransfer.GetComponent<ScoreTransfer>().success;
        CalculateRank();
        GameObject.Find("Canvas").transform.Find("Perfect").Find("Text").GetComponent<TextMeshProUGUI>().text = _sum[0].ToString();
        GameObject.Find("Canvas").transform.Find("Good").Find("Text").GetComponent<TextMeshProUGUI>().text = _sum[1].ToString();
        GameObject.Find("Canvas").transform.Find("Bad").Find("Text").GetComponent<TextMeshProUGUI>().text = _sum[2].ToString();
    }
    private void LateUpdate()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R");
            SceneManager.LoadScene(0);
        }

    }

    public void CalculateRank()
    {
        if (_sum[2] < 2 && _sum[1] < 10)
        {
            Rank = 4;
        }
        else if (_sum[2] < 4)
        {
            Rank = 3;
        }
        else if (success)
        {
            Rank = 2;
        }
        else
        {
            Rank = 1;
        }
        GameObject.Find("Canvas").transform.Find("Rank").GetComponent<Image>().sprite = sprites[Rank - 1];
        CheckAchievements();
    }
    public void CheckAchievements()
    {
        //최초 A
        if (PlayerPrefs.GetInt("FirstA") == 0 && Rank == 4)
        {
            PlayerPrefs.SetInt("FirstA", 1);
        }
        //최초 클리어
        if (PlayerPrefs.GetInt("FirstClear") == 0 && (Rank != 1))
        {
            PlayerPrefs.SetInt("FirstClear", 1);
        }
        //최초 클리어 실패
        if (PlayerPrefs.GetInt("FirstF") == 0 && Rank == 1)
        {
            PlayerPrefs.SetInt("FirstF", 1);
        }
        //최초 bad 0개
        if (PlayerPrefs.GetInt("BadCount0") == 0 && _sum[2] == 0)
        {
            PlayerPrefs.SetInt("BadCount0", 1);
        }
    }
}
