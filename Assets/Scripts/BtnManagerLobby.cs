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

    private Image[] images; // 이미지를 배열로 관리
    private int currentIndex = 0; // 현재 활성화된 이미지 인덱스

    private void Start()
    {
        // 이미지 배열 초기화
        images = new Image[] { iamge1, iamge2, iamge3, iamge4 };

        // 모든 이미지를 비활성화 상태로 설정
        foreach (Image img in images)
        {
            img.gameObject.SetActive(false);
        }

        // 첫 번째 이미지만 활성화
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
        // 현재 이미지 비활성화
        images[currentIndex].gameObject.SetActive(false);

        // 다음 인덱스로 이동 (마지막 이미지라면 다시 처음으로)
        currentIndex = (currentIndex + 1) % images.Length;

        // 새로운 이미지 활성화
        images[currentIndex].gameObject.SetActive(true);
    }
}
