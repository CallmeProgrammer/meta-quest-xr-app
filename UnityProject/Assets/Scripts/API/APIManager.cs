using UnityEngine;

public class APIManager : MonoBehaviour
{
    public static APIManager Instance;

    public string baseURL = "https://xr-backend-omega.vercel.app";

    void Awake()
    {
        Instance = this;
    }

    public string LoginURL()
    {
        return baseURL + "/api/login";
    }

    public string ProjectsURL()
    {
        return baseURL + "/api/projects";
    }

    public string FloorsURL(int projectId)
    {
        return baseURL + "/api/projects/" + projectId + "/floors";
    }
}
