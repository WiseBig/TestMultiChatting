using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BtnManagerLobby : MonoBehaviour
{
    public GameObject openMoney;
    public GameObject panel;
    public Image iamge1;
    public Image iamge2;
    public Image iamge3;
    public Image iamge4;

    private Image[] images; // �̹����� �迭�� ����
    private int currentIndex = 0; // ���� Ȱ��ȭ�� �̹��� �ε���

    private void Start()
    {
        // �̹��� �迭 �ʱ�ȭ
        images = new Image[] { iamge1, iamge2, iamge3, iamge4 };

        // ��� �̹����� ��Ȱ��ȭ ���·� ����
        foreach (Image img in images)
        {
            img.gameObject.SetActive(false);
        }

        // ù ��° �̹����� Ȱ��ȭ
        if (images.Length > 0)
        {
            images[0].gameObject.SetActive(true);
        }
    }
    public void OpenMoney()
    {
        openMoney.gameObject.SetActive(true);
    }
    public void CloseMoney()
    {
        openMoney.gameObject.SetActive(false);
    }
    public void OpenPanel()
    {
        panel.gameObject.SetActive(true);
    }
    public void ClosePanel()
    {
        panel.gameObject.SetActive(false);
    }
    public void NextBtn()
    {
        // ���� �̹��� ��Ȱ��ȭ
        images[currentIndex].gameObject.SetActive(false);

        // ���� �ε����� �̵� (������ �̹������ �ٽ� ó������)
        currentIndex = (currentIndex + 1) % images.Length;

        // ���ο� �̹��� Ȱ��ȭ
        images[currentIndex].gameObject.SetActive(true);
    }
}
