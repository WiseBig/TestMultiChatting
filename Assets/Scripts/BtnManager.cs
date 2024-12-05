    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;

    public class BtnManager : MonoBehaviour
    {
        public GameObject openIntroduction;
        public GameObject openLogin;

        private void Start()
        {
            openIntroduction.gameObject.SetActive(false);
            openLogin.gameObject.SetActive(false);
        }
        public void BtnOpenIntroduction()
        {
            openIntroduction.gameObject.SetActive(true);
        }
        public void BtnCloseIntroduction()
        {
            openIntroduction.gameObject.SetActive(false);
        }
        public void BtnOpenLogin()
        {
            openLogin.gameObject.SetActive(true);
        }
        public void BtnCloseLogin()
        {

        openLogin.gameObject.SetActive(false);
        }
    }
