using UnityEngine;
using TMPro;

public class ProjectSelection : MonoBehaviour
{
    public TMP_Dropdown projectDropdown;
    public FloorDropdownUI floorUI;
    public NavigationManager navigationManager;
    //public void OnNextButton()
    //{
    //    int projectId = projectDropdown.value + 1;

    //    navigationManager.GoToFloorPanel();

    //    floorUI.LoadFloors(projectId);
    //}
    public void OnNextButton()
    {
        int projectId = projectDropdown.value + 1;

        string projectName = projectDropdown.options[projectDropdown.value].text;

        ToastNotification.Instance.Show("Project Selected: " + projectName);

        navigationManager.GoToFloorPanel();

        floorUI.LoadFloors(projectId);
    }
}
