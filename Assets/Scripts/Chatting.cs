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
        // ä�� �޽��� �Է��� ������� ���� ��� ó��
        if (!string.IsNullOrEmpty(ChatInput.text))
        {
            // ChatRPC �޼��带 ���� ȣ�� (���ÿ����� ���)
            ChatRPC(PhotonNetwork.NickName + " : " + ChatInput.text);
            ChatInput.text = ""; // �Է� �ʵ� �ʱ�ȭ
        }
    }

    // ä�� �޽����� ǥ���ϴ� �޼���
    void ChatRPC(string msg)
    {
        bool isInput = false; // ���ο� �޽����� ��ĭ�� ������ Ȯ��
        for (int i = 0; i < ChatText.Length; i++)
        {
            if (ChatText[i].text == "") // ��ĭ�� ã��
            {
                isInput = true;
                ChatText[i].text = msg; // ��ĭ�� �޽��� �߰�
                break;
            }
        }

        if (!isInput) // ��� ĭ�� ä���� �ִٸ� �޽����� ���� �̵�
        {
            for (int i = 1; i < ChatText.Length; i++)
                ChatText[i - 1].text = ChatText[i].text;

            ChatText[ChatText.Length - 1].text = msg; // ������ ĭ�� ���ο� �޽��� �߰�
        }
    }
}
