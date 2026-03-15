using UnityEngine;

public class NavigationManager : MonoBehaviour
{
    public GameObject loginPanel;
    public GameObject projectPanel;
    public GameObject floorPanel;
    public LoginUI loginUI;
    public void GoToProjectPanel()
    {
        loginPanel.SetActive(false);
        projectPanel.SetActive(true);
        floorPanel.SetActive(false);
    }

    public void GoToFloorPanel()
    {
        projectPanel.SetActive(false);
        floorPanel.SetActive(true);
    }

    public void BackToProjects()
    {
        floorPanel.SetActive(false);
        projectPanel.SetActive(true);
    }

    public void BackToLogin()
    {
        projectPanel.SetActive(false);
        loginPanel.SetActive(true);
        if(loginUI != null)
        {
            if (!loginUI.rememberMeToggle.isOn)
            {
                loginUI.usernameInput.text = "";
                loginUI.passwordInput.text = "";
            }
        }
            
    }
}