using UnityEngine;

public class CameraAspect : MonoBehaviour
{


    void Awake()
    {
        float height = Screen.currentResolution.height;
        float width = Screen.currentResolution.width;

        Camera.main.aspect = width / height;
    }
}
