using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

[System.Serializable]
public class FloorResponse
{
    public string[] floors;
}

public class FloorDropdownUI : MonoBehaviour
{
    public TMP_Dropdown floorDropdown;

    public void LoadFloors(int projectId)
    {
        StartCoroutine(GetFloors(projectId));
    }

    IEnumerator GetFloors(int projectId)
    {
        string url = APIManager.Instance.FloorsURL(projectId);

        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;

            FloorResponse response =
                JsonUtility.FromJson<FloorResponse>(json);

            floorDropdown.ClearOptions();

            floorDropdown.AddOptions(
                new List<string>(response.floors)
            );
        }
        else
        {
            Debug.Log("Failed to load floors");
        }
    }
    public void OnNextButton()
    {
        string floorName = floorDropdown.options[floorDropdown.value].text;

        Debug.Log("Selected Floor: " + floorName);

        ToastNotification.Instance.Show("Selected Floor: " + floorName);
    }
}
