using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;

[System.Serializable]
public class Project
{
    public int id;
    public string name;
}

[System.Serializable]
public class ProjectResponse
{
    public Project[] projects;
}

public class ProjectDropdownUI : MonoBehaviour
{
    public TMP_Dropdown projectDropdown;

    private List<Project> projectList = new List<Project>();

    void Start()
    {
        StartCoroutine(GetProjects());
    }

    IEnumerator GetProjects()
    {
        string url = APIManager.Instance.ProjectsURL();

        UnityWebRequest request = UnityWebRequest.Get(url);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string json = request.downloadHandler.text;

            ProjectResponse response =
                JsonUtility.FromJson<ProjectResponse>(json);

            projectList = new List<Project>(response.projects);

            PopulateDropdown();
        }
        else
        {
            Debug.Log("Failed to load projects");
        }
    }

    void PopulateDropdown()
    {
        projectDropdown.ClearOptions();

        List<string> options = new List<string>();

        foreach (var project in projectList)
        {
            options.Add(project.name);
        }

        projectDropdown.AddOptions(options);
    }

    public int GetSelectedProjectID()
    {
        int index = projectDropdown.value;
        return projectList[index].id;
    }
}
