using UnityEngine;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    public Button backButton;
    public Toggle setting1toggle;
    public Toggle setting2toggle;
    public Toggle setting3toggle;

    void Awake()
    {
        if (!Application.isMobilePlatform)
        {
            setting1toggle.isOn = PlayerPrefs.GetInt("Setting1") == 1;
            setting2toggle.isOn = PlayerPrefs.GetInt("Setting2") == 1;
            setting3toggle.isOn = PlayerPrefs.GetInt("Setting3") == 1;
        }
        else
        {
            setting1toggle.isOn = false;
            setting2toggle.isOn = true;
            setting3toggle.isOn = PlayerPrefs.GetInt("Setting3") == 1;
            setting1toggle.interactable = false;
            setting2toggle.interactable = false;
            PlayerPrefs.SetInt("Setting1", 0);
            PlayerPrefs.SetInt("Setting2", 1);
            PlayerPrefs.Save();
        }
        backButton.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
        });

        setting1toggle.onValueChanged.AddListener((bool change) =>
        {
            if (Application.platform != RuntimePlatform.Android && Application.platform != RuntimePlatform.IPhonePlayer)
            {
                Screen.fullScreen = change;
                PlayerPrefs.SetInt("Setting1", change ? 1 : 0);
            }
        });
        setting2toggle.onValueChanged.AddListener((bool change) =>
        {
            if (!Application.isMobilePlatform)
            {
                PlayerPrefs.SetInt("Setting2", change ? 1 : 0);
            }
        });
        setting3toggle.onValueChanged.AddListener((bool change) =>
        {
            PlayerPrefs.SetInt("Setting3", change ? 1 : 0);
        });
    }
}
