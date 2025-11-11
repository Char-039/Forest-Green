using UnityEngine;
using UnityEngine.SceneManagement;


public class CheckpointCollision : MonoBehaviour {

    public float activationPeriod = 1.0f;

    private float currTime = 0.0f;
    private bool isActive = false;

    void OnTriggerStay(Collider other) {
        if(other.gameObject.CompareTag("Checkpoint1")) {
            currTime += Time.deltaTime;

            if (currTime >= activationPeriod && !isActive) {
                isActive = true;
                SceneManager.LoadScene("LevelSelectScene");
            }
        }
    }

    void OnTriggerExit(Collider other) {
        if(other.gameObject.CompareTag("Checkpoint1")) {
            currTime = 0.0f;
            isActive = false;
        }
    }
}
