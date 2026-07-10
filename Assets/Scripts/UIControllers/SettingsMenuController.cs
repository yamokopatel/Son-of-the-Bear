using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    [Header("Static Containers")]
    [SerializeField] private StaticSettings gameSettings;
    [SerializeField] private StaticLines localization;

    [Header("SETTING FIELDS")]
    [Header("Screen Setting Fields")]
    //titles
    [SerializeField] private Text screenMode_title, screenResolution_title, frameRate_title;
    //dropdowns
    [SerializeField] private Dropdown screenMode_picker, screenResolution_picker, frameRate_picker;

    [Header("Sound Setting Fields")]
    //titles
    [SerializeField] private Text soundVolume_title, musicVolume_title, envVolume_title;
    //sliders
    [SerializeField] private Slider soundVolume_slider, musicVolume_slider, envVolume_slider;
    //percents
    [SerializeField] private Text soundVolume_percent, musicVolume_percent, envVolume_percent;

    [Header("UI Setting Fields")]
    //titles
    [SerializeField] private Text language_title, fontSize_title, highlight_title;
    //pickers
    [SerializeField] private Dropdown language_picker;
    [SerializeField] private Slider fontSize_slider;
    [SerializeField] private Toggle highlight_toggle;
    //size field
    [SerializeField] private Text fontSize_pixels;

    [Header("Controls Setting Fields")]
    //titles
    [SerializeField] private Text controls_title, mouseSense_title;
    //pickers
    [SerializeField] private Dropdown controls_picker;
    [SerializeField] private Slider mouseSense_slider;
    //INFO OUTPUTS
    //buttons
    [SerializeField] private Text forward_btn, right_btn, backward_btn, left_btn, pause_btn, interact_btn, rotClock_btn, rotUnclock_btn;
    //descriptions
    [SerializeField] private Text forward_desc, right_desc, backward_desc, left_desc, pause_desc, interact_desc, rotClock_desc, rotUnclock_desc;
    //sensitivity
    [SerializeField] private Text mouseSense;

    [Header("SETTING PICKERS")]
    [Header("Setting Panels")]
    [SerializeField] private GameObject screenSettingPanel, soundSettingPanel, uiSettingPanel, controlsSettingPanel;
    [Header("Setting Choose Buttons")]
    [SerializeField] private Button screenSettingButton, soundSettingButton, uiSettingButton, controlsButton, creditsButton;

    [Header("SETTING CLOSERS")]
    [SerializeField] private Button closeButton, saveButton;
    [SerializeField] private GameObject mainSettingPanel;


    private GameObject currentSettingPanel;
    void Start()
    {
        PreloadLines();
        PreloadValues();
        soundSettingPanel.SetActive(true);
        currentSettingPanel = soundSettingPanel;
    }
    //preload data and lines
    private void PreloadLines()
    {

    }
    private void PreloadValues()
    {

    }
    //closing buttons functions
    public void SaveAndClose()
    {

    }
    public void Close()
    {

    }
    private void ReloadValues()
    {

    }
    private void InloadValues()
    {

    }
    //servise onUpdate functions

}
