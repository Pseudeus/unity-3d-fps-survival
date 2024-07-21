using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private Canvas GameOverCanvas;
    [SerializeField] private FirstPersonController fpsControler;

    private void Start()
    {
        GameOverCanvas.enabled = false;
        fpsControler = GetComponent<FirstPersonController>();
    }

    public void HandleDeath()//called form PlayerHealth by string reference
    {
        GameOverCanvas.enabled = true;
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        fpsControler.enabled = false;
    }
}
