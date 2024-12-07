using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoginManager : MonoBehaviourPunCallbacks
{
    public InputField NicknameInput;
    public InputField CodeInput;
    public Text ErrorMessage;
    public Text NickMessage;

    public void Connect()
    {
        if (!string.IsNullOrEmpty(NicknameInput.text))
        {
            PhotonNetwork.NickName = NicknameInput.text;
        }
        else
        {
            NickMessage.gameObject.SetActive(true);
            StartCoroutine(HideErrorMessage());
            return;// 닉네임이 비어있으면 기본값 설정
        }
        if (CodeInput.text != "1234")
        {
            ErrorMessage.gameObject.SetActive(true);
            StartCoroutine(HideErrorMessage());
            return;
        }
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster()
    {
        // 마스터 서버에 연결되면 로비 씬으로 이동
        PhotonNetwork.JoinLobby();
        SceneManager.LoadScene("LobbyScene");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Successfully joined the lobby!");
    }
    private IEnumerator HideErrorMessage()
    {
        yield return new WaitForSeconds(2f);  // 2초 대기
        ErrorMessage.gameObject.SetActive(false);
        NickMessage.gameObject.SetActive(false);
    }
}
