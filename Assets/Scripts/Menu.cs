using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public Button exitBtn;
    public Button playBtn;
    public Button settingsBtn;

    void Awake()
    {
        if (!Application.isMobilePlatform)
        {
            exitBtn.onClick.AddListener(() => Application.Quit());
        }
        else
        {
            exitBtn.gameObject.SetActive(false);
        }

        playBtn.onClick.AddListener(() => LoadScene("Game"));
        settingsBtn.onClick.AddListener(() => LoadScene("Settings"));
    }

    void LoadScene(string scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(scene);
    }
}