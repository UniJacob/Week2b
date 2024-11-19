using UnityEngine;

public class MinimapScript : MonoBehaviour
{

    public Camera mainCamera, minimapCam;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateApectRatio()
    {
        minimapCam.orthographicSize = mainCamera.orthographicSize;
        minimapCam.rect = new Rect(0.79f, 0.79f, 0.2f, 0.2f);
    }
}
