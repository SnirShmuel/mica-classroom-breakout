using UnityEngine;
using UnityEngine.SceneManagement;
 
public class SaveAndRestorePosition : MonoBehaviour
{
    void Start() // Check if we've saved a position for this scene; if so, go there.
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		Debug.Log("Restroing " + sceneIndex);
        if (SavedPositionManager.savedPositions.ContainsKey(sceneIndex))
        {
			Debug.Log(SavedPositionManager.savedPositions[sceneIndex]);
            transform.position = SavedPositionManager.savedPositions[sceneIndex];
        }
    }
 
    void OnDestroy() // Unloading scene, so save position.
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
		Debug.Log("Saving " + sceneIndex);
        SavedPositionManager.savedPositions[sceneIndex] = transform.position;
    }
}	