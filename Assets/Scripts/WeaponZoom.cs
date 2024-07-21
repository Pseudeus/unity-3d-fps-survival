using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private Camera cameraComp;
    [SerializeField] private ushort baseFieldOfView = 60;
    [SerializeField] private byte multiplier = 2;
    [SerializeField] private byte zoomOutSensivility = 2;
    [SerializeField] private byte zoomInSensivility = 1;
    [SerializeField] private FirstPersonController fpsController; 
    private float t;

    private void Start()
    {
        cameraComp = GetComponentInChildren<Camera>();
        fpsController = GetComponent<FirstPersonController>();
    }

    private void Update()
    {
        if(Input.GetMouseButton(1))
        {
            cameraComp.fieldOfView = Mathf.Lerp(baseFieldOfView, baseFieldOfView / multiplier, t);
            t = (t < 1) 
              ? (t += 4f * Time.deltaTime) 
              : 1;

            fpsController.m_MouseLook.XSensitivity = zoomInSensivility;
            fpsController.m_MouseLook.YSensitivity = zoomInSensivility;
        }
        else
        {
            if (t <= float.Epsilon) return;
            cameraComp.fieldOfView = Mathf.Lerp(baseFieldOfView, baseFieldOfView / multiplier, t);
            t = (t > 0)
              ? (t -= 4f * Time.deltaTime)
              : 0;

            fpsController.m_MouseLook.XSensitivity = zoomOutSensivility;
            fpsController.m_MouseLook.YSensitivity = zoomOutSensivility;
        }
    }
}
