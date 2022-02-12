using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] InputField userNameField;

    public void SetUserName()
    {
        DataManager.Instance.userName = userNameField.text;
    }

    public void StartGame()
    {
        SetUserName();
        SceneManager.LoadScene("main");
    }
}
