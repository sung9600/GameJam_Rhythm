using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InGameUI : MonoBehaviour
{
    public static Slider[] _hpsliders;
    public static TextMeshProUGUI _scoretext;

    private void Awake()
    {
        _hpsliders = new Slider[3];
        GameObject root = GameObject.Find("Others").transform.Find("UI").Find("ScoreSquare").Find("Canvas").gameObject;
        _hpsliders[0] = root.transform.Find("Hearts").Find("Heart1").Find("Slider1").GetComponent<Slider>();
        _hpsliders[1] = root.transform.Find("Hearts").Find("Heart2").Find("Slider2").GetComponent<Slider>();
        _hpsliders[2] = root.transform.Find("Hearts").Find("Heart3").Find("Slider3").GetComponent<Slider>();
        _scoretext = root.transform.Find("ScoreText").GetComponent<TextMeshProUGUI>();
        _scoretext.text = "0";
    }
    public static void changehp(int hp)
    {
        Debug.Log(hp);
        switch (hp)
        {
            case 0:
                _hpsliders[0].value = 1;
                _hpsliders[1].value = 1;
                _hpsliders[2].value = 1;
                break;
            case 1:
                _hpsliders[0].value = 0.5f;
                _hpsliders[1].value = 1;
                _hpsliders[2].value = 1;
                break;
            case 2:
                _hpsliders[0].value = 0;
                _hpsliders[1].value = 1;
                _hpsliders[2].value = 1;
                break;
            case 3:
                _hpsliders[0].value = 0;
                _hpsliders[1].value = 0.5f;
                _hpsliders[2].value = 1;
                break;
            case 4:
                _hpsliders[0].value = 0;
                _hpsliders[1].value = 0;
                _hpsliders[2].value = 1;
                break;
            case 5:
                _hpsliders[0].value = 0;
                _hpsliders[1].value = 0;
                _hpsliders[2].value = 0.5f;
                break;
            case 6:
                _hpsliders[0].value = 0;
                _hpsliders[1].value = 0;
                _hpsliders[2].value = 0;
                break;
        }
    }
    public static void getscore(int score)
    {
        _scoretext.text = score.ToString();
    }

}
