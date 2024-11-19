using UnityEngine;

public class MainCameraScript : MonoBehaviour
{
    public MinimapScript MiniMapScript;
    public MageScript PlayerScript;
    private float baseAspectRatio, lastAspectRatio, baseorthographicSize;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastAspectRatio = (float)Screen.width / Screen.height;
        baseAspectRatio = lastAspectRatio;
        baseorthographicSize = Camera.main.orthographicSize;
        MiniMapScript.UpdateApectRatio();
    }

    // Update is called once per frame
    void Update()
    {
        float currAspectRatio = (float)Screen.width / Screen.height;
        if (!Mathf.Approximately(currAspectRatio, lastAspectRatio))
        {
            if (Mathf.Approximately(currAspectRatio, baseAspectRatio))
            {
                Camera.main.orthographicSize = baseorthographicSize;
                Debug.Log("Original orthographicSize");
            }
            else
            {
                Camera.main.orthographicSize /= currAspectRatio;
                Debug.Log("Screen rotated");
            }
            
            lastAspectRatio = currAspectRatio;
            MiniMapScript.UpdateApectRatio();
            PlayerScript.SetBorders();
        }
    }
}
