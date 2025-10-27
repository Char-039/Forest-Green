using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class OptionsMenu : MonoBehaviour {
    public Slider volumeSlider;

    void Start()
    {
        volumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 50.0f);
    }

    public void SetVolume(float volume) {
        PlayerPrefs.SetFloat("MasterVolume", volume);
        Debug.Log("Saved Volume: " + volume);
    }

    public void GoToMainMenu() {
        // Returns to main menu scene
        SceneManager.LoadScene("BasicScene");
    }
}