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
            return;// �г����� ��������� �⺻�� ����
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
        // ������ ������ ����Ǹ� �κ� ������ �̵�
        PhotonNetwork.JoinLobby();
        SceneManager.LoadScene("LobbyScene");
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Successfully joined the lobby!");
    }
    private IEnumerator HideErrorMessage()
    {
        yield return new WaitForSeconds(2f);  // 2�� ���
        ErrorMessage.gameObject.SetActive(false);
        NickMessage.gameObject.SetActive(false);
    }
}
