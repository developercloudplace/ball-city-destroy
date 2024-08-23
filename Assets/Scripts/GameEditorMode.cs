using Unity.Mathematics;
using UnityEngine;

public class GameEditorMode : MonoBehaviour
{
    public GameObject CanvasGamePlayer;
    public GameObject CameraGamePlayerMode;
    public GameObject CameraEditorMode;
    public GameObject CanvasEditorMode;
    public GameObject EditorMode;
    public GameObject Player;

    [ContextMenu("StartGameMode")]
    public void StartGameMode()
   {
       CanvasGamePlayer.SetActive(true);
       CameraGamePlayerMode.SetActive(true);
       CameraEditorMode.SetActive(false);
       CanvasEditorMode.SetActive(false);
       EditorMode.SetActive(false);
       Instantiate(Player, new Vector3(0, 0.06f, 0),quaternion.identity);
   }
}
