using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectLogic : MonoBehaviour {
    public void goToLevelOne() {
        SceneManager.LoadScene("MirrorTest");
    }
}
