using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour
{
    [SerializeField] private GameObject popUpContainer;
    [SerializeField] private Button continueButton;
    [SerializeField] private Button restartButton;
    private bool isAllowedPause = true;


    private void Update()
    {
        if (!isAllowedPause) return;

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ManagePopUp(!IsActivePopUp(), true);
        }
    }

    public void ShowPopUpRestart()
    {
        isAllowedPause = false;
        ManagePopUp(true, false);
        restartButton.Select();
    }

    private void ManagePopUp(bool isEnabledPopUp, bool isPausePopUp)
    {
        Time.timeScale = isEnabledPopUp ? 0f : 1f;
        popUpContainer.SetActive(isEnabledPopUp);
        continueButton.gameObject.SetActive(isPausePopUp);
        continueButton.Select();
    }

    public void ButtonContinue() //Button OnClick Event
    {
        ManagePopUp(!IsActivePopUp(), true);
    }
    public void ButtonRestart() //Button OnClick Event
    {
        Time.timeScale = 1f;
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    public void ButtonQuit() //Button OnClick Event
    {
        Application.Quit();
    }

    private bool IsActivePopUp()
    {
        return popUpContainer.activeSelf;
    }
}
