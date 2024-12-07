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
        // 방 이름 설정 (빈 입력 시 기본 이름 "Room" 사용)
        string roomName = string.IsNullOrEmpty(RoomInput.text) ? "Room" : RoomInput.text;

        // 방 생성 요청
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
        // 방 생성 실패 시 알림을 표시하거나 다시 시도할 수 있음
    }

    public void JoinRandomRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.LogWarning($"Random room join failed: {message}");
        // 무작위 입장 실패 시 처리 (예: 새로운 방 생성)
        CreateRoom();
    }
}
