using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{

    private BackgroundController background;
    private CameraController cameraController;
    private PlayerController playerController;

    // added: advance phase, wrap and update sprite
    public void AdvancePhase()
    {

        Debug.Log("Advancing background phase.");
        background = FindFirstObjectByType<BackgroundController>();
        background.AdvancePhase();

        Debug.Log("Reload Background.");
        cameraController = FindFirstObjectByType<CameraController>();
        cameraController.Reload();

        Debug.Log("Reload Player.");
        playerController = FindFirstObjectByType<PlayerController>();
        playerController.Reload();   
        
    }
}
