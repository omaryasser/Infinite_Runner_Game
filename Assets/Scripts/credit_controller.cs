using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class credit_controller : MonoBehaviour
{

    public Button back;
    void Start()
    {
        back.onClick.AddListener(() => { back_(); });
    }
    public void back_()
    {
        SceneManager.LoadScene("Menu");
    }
}
