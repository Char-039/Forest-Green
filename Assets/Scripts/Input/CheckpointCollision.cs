using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckpointCollision : MonoBehaviour {

    void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Checkpoint1")) {
            SceneManager.LoadScene("LevelSelectScene");
        }
    }
}
