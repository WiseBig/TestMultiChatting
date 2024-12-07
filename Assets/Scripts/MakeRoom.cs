using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MakeRoom : MonoBehaviourPunCallbacks
{
    public InputField RoomInput;

    public void CreateRoom()
    {
        // �� �̸� ���� (�� �Է� �� �⺻ �̸� "Room" ���)
        string roomName = string.IsNullOrEmpty(RoomInput.text) ? "Room" : RoomInput.text;

        // �� ���� ��û
        RoomOptions options = new RoomOptions { MaxPlayers = 2 };
        PhotonNetwork.CreateRoom(roomName, options);
    }

    public override void OnCreatedRoom()
    {
        Debug.Log("Room created successfully!");
        SceneManager.LoadScene("ChattingRoomScene");
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogWarning($"Room creation failed: {message}");
        // �� ���� ���� �� �˸��� ǥ���ϰų� �ٽ� �õ��� �� ����
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogWarning($"Random room join failed: {message}");
        // ������ ���� ���� �� ó�� (��: ���ο� �� ����)
        CreateRoom();
    }
}
