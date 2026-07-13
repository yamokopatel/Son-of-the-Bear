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
        LoadLines();
        LoadValues();
        soundSettingPanel.SetActive(true);
        currentSettingPanel = soundSettingPanel;
    }
    //preload data and lines
    private void LoadLines()
    {
        //TITLES
        //screen
        screenMode_title.text = localization.GetLine("sttngs_screen_ttl_mode");
        screenResolution_title.text = localization.GetLine("sttngs_screen_ttl_resolution");
        frameRate_title.text = localization.GetLine("sttngs_screen_ttl_framerate");
        //sound
        soundVolume_title.text = localization.GetLine("sttngs_audio_ttl_sound");
        musicVolume_title.text = localization.GetLine("sttngs_audio_ttl_music");
        envVolume_title.text = localization.GetLine("sttngs_audio_ttl_env");
        //ui
        language_title.text = localization.GetLine("sttngs_ui_ttl_lang");
        fontSize_title.text = localization.GetLine("sttngs_ui_ttl_fsize");
        highlight_title.text = localization.GetLine("sttngs_ui_ttl_highlight");
        //controls
        controls_title.text = localization.GetLine("sttngs_controls_ttl_controls");
        mouseSense_title.text = localization.GetLine("sttngs_controls_ttl_mouse");
        //VALUES
        //screen
        screenMode_picker.options[0].text = localization.GetLine("sttngs_screen_mode_dd_fs");
        screenMode_picker.options[1].text = localization.GetLine("sttngs_screen_mode_dd_wfs");
        screenMode_picker.options[2].text = localization.GetLine("sttngs_screen_mode_dd_w");
        //ui
        highlight_toggle.GetComponentInChildren<Text>().text = localization.GetLine("sttngs_ui_desc_highlight");
        //controls
        forward_desc.text = localization.GetLine("sttngs_controls_desc_forward");
        right_desc.text = localization.GetLine("sttngs_controls_desc_right");
        backward_desc.text = localization.GetLine("sttngs_controls_desc_backward");
        left_desc.text = localization.GetLine("sttngs_controls_desc_left");
        pause_desc.text = localization.GetLine("sttngs_controls_desc_pause");
        interact_desc.text = localization.GetLine("sttngs_controls_desc_interact");
        rotClock_desc.text = localization.GetLine("sttngs_controls_desc_clockrot");
        rotUnclock_desc.text = localization.GetLine("sttngs_controls_desc_unclockrot");
    }
    private void LoadValues()
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
    public void SwitchSettingPanel(GameObject newSettingPanel)
    {
        currentSettingPanel.SetActive(false);
        newSettingPanel.SetActive(true);
        currentSettingPanel = newSettingPanel;
    }
}
