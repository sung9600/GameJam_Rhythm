using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class AcheievementScene : MonoBehaviour
{
    public void ToLobby()
    {
        SceneManager.LoadScene("Lobby");
    }
    private void Awake()
    {
        Color32 Reveal = new Color32(255, 255, 255, 0);
        GameObject canvas = GameObject.Find("Canvas");
        if (PlayerPrefs.GetInt("FirstA") != 0)
        {
            canvas.transform.Find("TrophyImages").Find("FirstA").Find("Image").GetComponent<Image>().color = Reveal;
        }
        if (PlayerPrefs.GetInt("FirstClear") != 0)
        {
            canvas.transform.Find("TrophyImages").Find("FirstClear").Find("Image").GetComponent<Image>().color = Reveal;
        }
        if (PlayerPrefs.GetInt("FirstF") != 0)
        {
            canvas.transform.Find("TrophyImages").Find("FirstF").Find("Image").GetComponent<Image>().color = Reveal;
        }
        if (PlayerPrefs.GetInt("BadCount0") != 0)
        {
            canvas.transform.Find("TrophyImages").Find("BadCount0").Find("Image").GetComponent<Image>().color = Reveal;
        }
    }

}
