using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using UnityEngine.UI;

public class LoginUI : MonoBehaviour
{
    public TMP_InputField usernameInput;
    public TMP_InputField passwordInput;
    public NavigationManager navigationManager;
    public Toggle rememberMeToggle;
    public GameObject invalidUsername;
    public GameObject invalidPassword;
    public void Login()
    {
        invalidUsername.SetActive(false);
        invalidPassword.SetActive(false);

        if (string.IsNullOrEmpty(usernameInput.text) && string.IsNullOrEmpty(passwordInput.text))
        {
            invalidUsername.SetActive(true);
            invalidPassword.SetActive(true);
            return;
        }

        if (string.IsNullOrEmpty(usernameInput.text))
        {
            invalidUsername.SetActive(true);
            return;
        }

        if (string.IsNullOrEmpty(passwordInput.text))
        {
            invalidPassword.SetActive(true);
            return;
        }

        StartCoroutine(LoginRequest());

    
    }

    public void ExitApp()
    {
        Application.Quit();
    }
    IEnumerator LoginRequest()
    {
        string url = APIManager.Instance.LoginURL();

        string json =
            "{\"username\":\"" + usernameInput.text +
            "\",\"password\":\"" + passwordInput.text + "\"}";

        UnityWebRequest request = new UnityWebRequest(url, "POST");
        byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);

        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string response = request.downloadHandler.text;

            if (response.Contains("\"success\":true"))
            {
                ToastNotification.Instance.Show("Login Successful");
                navigationManager.GoToProjectPanel();
            }
            else if (response.Contains("\"error\":\"username\""))
            {
                invalidUsername.SetActive(true);
            }
            else if (response.Contains("\"error\":\"password\""))
            {
                invalidPassword.SetActive(true);
            }
        }
        else
        {
            Debug.Log("Login Failed");
        }
    }
}
