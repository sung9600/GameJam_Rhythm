using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LobbyScene : MonoBehaviour
{
    public void To1P()
    {
        SceneManager.LoadScene("1Pscene");
    }
    public void ToAchievement()
    {
        SceneManager.LoadScene("Achievement");
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit(); // 어플리케이션 종료
#endif
    }
}
