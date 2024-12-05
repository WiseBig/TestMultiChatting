using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveScene : MonoBehaviour
{
    public void Enter()
    {
        SceneManager.LoadScene("LobbyScene");
    }
    public void EnterChattingRoom()
    {
        SceneManager.LoadScene("ChattingRoomScene");
    }
    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
