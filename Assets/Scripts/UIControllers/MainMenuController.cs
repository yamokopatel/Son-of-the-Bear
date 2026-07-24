using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [Header("Static Containers")]
    [SerializeField] private StaticSettings gameSettings;
    [SerializeField] private StaticLines localization;
    [Header("Buttons")]
    [SerializeField] private Button newGameButton;
    [SerializeField] private Button loadGameButton, settingsButton, quitButton;
    [Header("Cildren Panels")]
    [SerializeField] private GameObject loadGamePanel;
    [SerializeField] private GameObject settingMenuPanel;
    [Header("Game Title")]
    [SerializeField] private Text gameTitle;
    [SerializeField] private float titleRorationSpeed;
    private bool titleUnclockRotation;
    private bool isChildPanelOpened;
    void Start()
    {
        gameSettings.LoadSettings(); gameSettings.UseSettings();
        LoadLines();
        titleUnclockRotation = true; isChildPanelOpened = false;
    }
    void FixedUpdate()
    {
        RotateTitle(titleRorationSpeed);
        if (isChildPanelOpened)
        {
            if (!CheckChildPanelOpen())
            {
                newGameButton.interactable = true; loadGameButton.interactable = true;
                settingsButton.interactable = true; quitButton.interactable = true;
                isChildPanelOpened = false;
            }
        }
    }
    //starter function
    public void LoadLines()
    {
        LoadLine(newGameButton, "main_btn_newgame"); LoadLine(loadGameButton, "main_btn_loadgame");
        LoadLine(settingsButton, "main_btn_settings"); LoadLine(quitButton, "main_btn_quitgame");
    }
    //every tick functions
    private void RotateTitle(float speed)
    {
        float z = gameTitle.rectTransform.eulerAngles.z;
        if (titleUnclockRotation)
        {
            gameTitle.rectTransform.rotation = Quaternion.Euler(0, 0, z + speed);
            if(z > 4 && z < 180)
            {
                titleUnclockRotation = false;
            }
        }
        else
        {
            gameTitle.rectTransform.rotation = Quaternion.Euler(0, 0, z - speed);
            if (z < 356 && z > 180)
            {
                titleUnclockRotation = true;
            }
        }
    }
    private bool CheckChildPanelOpen()
    {
        if (loadGamePanel.activeSelf || settingMenuPanel.activeSelf)
        {
            return true;
        }
        return false;
    }
    //UI functions
    public void OpenChildPanel(GameObject panel)
    {
        panel.SetActive(true);
        isChildPanelOpened = true;
        newGameButton.interactable = false; loadGameButton.interactable = false;
        settingsButton.interactable = false; quitButton.interactable = false;
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    /*public void LoadGame()
    {

    }*/
    //DRY function
    private void LoadLine(Button textField, string localId)
    {
        textField.GetComponentInChildren<Text>().text = localization.GetLine(localId);
    }
}
