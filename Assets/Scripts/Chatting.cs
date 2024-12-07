using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Chatting : MonoBehaviour
{
    public Text[] ChatText;
    public InputField ChatInput;
    public void Send()
    {
        // 채팅 메시지 입력이 비어있지 않을 경우 처리
        if (!string.IsNullOrEmpty(ChatInput.text))
        {
            // ChatRPC 메서드를 직접 호출 (로컬에서만 사용)
            ChatRPC(PhotonNetwork.NickName + " : " + ChatInput.text);
            ChatInput.text = ""; // 입력 필드 초기화
        }
    }

    // 채팅 메시지를 표시하는 메서드
    void ChatRPC(string msg)
    {
        bool isInput = false; // 새로운 메시지가 빈칸에 들어갔는지 확인
        for (int i = 0; i < ChatText.Length; i++)
        {
            if (ChatText[i].text == "") // 빈칸을 찾음
            {
                isInput = true;
                ChatText[i].text = msg; // 빈칸에 메시지 추가
                break;
            }
        }

        if (!isInput) // 모든 칸이 채워져 있다면 메시지를 위로 이동
        {
            for (int i = 1; i < ChatText.Length; i++)
                ChatText[i - 1].text = ChatText[i].text;

            ChatText[ChatText.Length - 1].text = msg; // 마지막 칸에 새로운 메시지 추가
        }
    }
}
