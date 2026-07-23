using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuController : MonoBehaviour
{
    [Header("Static Containers")]
    [SerializeField] private StaticSettings gameSettings;
    [SerializeField] private StaticLines localization;
    [SerializeField] private LangDictionary langDictionary;

    [Header("Other panels")]
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameLoadMenu;

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
    [SerializeField] private Button screenSettingButton, soundSettingButton, uiSettingButton, controlsSettingButton, creditsButton;

    [Header("SETTING CLOSERS")]
    [SerializeField] private Button closeButton, saveButton;
    [SerializeField] private GameObject mainSettingPanel;


    private GameObject currentSettingPanel;
    void Start()
    {
        langDictionary.Initialize();
        LoadLines();
        LoadValues();
        soundSettingPanel.SetActive(true);
        currentSettingPanel = soundSettingPanel;
        //event listeners, инспектор, какого-то хрена не видит функции
        soundVolume_slider.onValueChanged.AddListener((val) => UpdateSliderOutput(soundVolume_percent, soundVolume_slider, true));
        musicVolume_slider.onValueChanged.AddListener((val) => UpdateSliderOutput(musicVolume_percent, musicVolume_slider, true));
        envVolume_slider.onValueChanged.AddListener((val) => UpdateSliderOutput(envVolume_percent, envVolume_slider, true));
        fontSize_slider.onValueChanged.AddListener((val) => UpdateSliderOutput(fontSize_pixels, fontSize_slider, true));
        mouseSense_slider.onValueChanged.AddListener((val) => UpdateSliderOutput(mouseSense, mouseSense_slider, false));
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
        screenMode_picker.RefreshShownValue();
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
        //BUTTONS
        //panel switch
        screenSettingButton.GetComponentInChildren<Text>().text = localization.GetLine("sttngs_main_btn_screen");
        soundSettingButton.GetComponentInChildren<Text>().text = localization.GetLine("sttngs_main_btn_audio");
        uiSettingButton.GetComponentInChildren<Text>().text = localization.GetLine("sttngs_main_btn_ui");
        controlsSettingButton.GetComponentInChildren<Text>().text = localization.GetLine("sttngs_main_btn_controls");
        creditsButton.GetComponentInChildren<Text>().text = localization.GetLine("sttngs_main_btn_credits");
        //closing
        closeButton.GetComponentInChildren<Text>().text = localization.GetLine("sttngs_main_btn_close");
        saveButton.GetComponentInChildren<Text>().text = localization.GetLine("sttngs_main_btn_save");
    }
    private void ReloadLines()
    {
        LoadLines();
        mainMenu.GetComponent<MainMenuController>().LoadLines();
        //reloading for save loading menu
    }
    private void LoadValues()
    {
        LoadScreenMode(); LoadScreenResolution(); LoadFramerate();
        LoadVolume(soundVolume_slider, gameSettings.GetSoundVolume(), soundVolume_percent); 
        LoadVolume(musicVolume_slider, gameSettings.GetMusicVolume(), musicVolume_percent);
        LoadVolume(envVolume_slider, gameSettings.GetEnvironmentVolume(), envVolume_percent);
        LoadLanguage(); LoadFontSize(); LoadHighlight();
        LoadMouseSensitivity(); LoadControls();
    }
    //closing buttons functions
    public void Close(bool save)
    {
        mainSettingPanel.SetActive(false);
        soundSettingPanel.SetActive(true);
        currentSettingPanel = soundSettingPanel;
        if (save)
        {
            InloadValues();
            gameSettings.SaveSettings(); gameSettings.UseSettings();
            ReloadLines();
        }
        else
        {
            LoadValues();
        }
    }
    private void InloadValues()
    {
        InloadScreenMode(); InloadScreenResolution(); InloadFrameRate();
        InloadVolumes();
        InloadLanguage(); InloadFontSize(); InloadHighlight();
        InloadControls(); InloadMouseSensitivity();
    }
    //servise onUpdate functions
    public void SwitchSettingPanel(GameObject newSettingPanel)
    {
        currentSettingPanel.SetActive(false);
        newSettingPanel.SetActive(true);
        currentSettingPanel = newSettingPanel;
    }
    public void ShowControlsButtons()
    {
        switch (controls_picker.value)
        {
            case 1:
                forward_btn.text = "W"; right_btn.text = "D"; backward_btn.text = "S"; left_btn.text = "A";
                pause_btn.text = "Esc"; rotClock_btn.text = "E"; rotUnclock_btn.text = "Q"; interact_btn.text = "F";
                break;
            case 2:
                forward_btn.text = "Z"; right_btn.text = "D"; backward_btn.text = "S"; left_btn.text = "Q";
                pause_btn.text = "Esc"; rotClock_btn.text = "E"; rotUnclock_btn.text = "A"; interact_btn.text = "F";
                break;
        }
    }
    public void UpdateSliderOutput(Text output, Slider slider, bool isInt)
    {
        if(isInt)
        {
            output.text = Mathf.RoundToInt(slider.value).ToString();
        }
        else
        {
            output.text = (Mathf.Round(slider.value * 100f) / 100f).ToString("0.##");
        }
    }
    //value loading functions
    private void LoadScreenMode()
    {
        screenMode_picker.value = gameSettings.GetScreenMode() switch
        {
            "fullscreen" => 0,
            "fullscreen window" => 1,
            "windowed" => 2,
            _ => 2
        };
        screenMode_picker.RefreshShownValue();
    }
    private void LoadScreenResolution()
    {
        bool foundResolution = false;
        for (int a = 0; a < screenResolution_picker.options.Count; a++)
        {
            if (screenResolution_picker.options[a].text == gameSettings.GetScreenResolution())
            {
                screenResolution_picker.value = a;
                foundResolution = true;
                break;
            }
        }
        if (!foundResolution)
        {
            screenResolution_picker.AddOptions(new List<string> { gameSettings.GetScreenResolution() });
            screenResolution_picker.value = (screenResolution_picker.options.Count - 1);
        }
        screenResolution_picker.RefreshShownValue();
    }
    private void LoadFramerate()
    {
        bool foundFramerate = false;
        if(gameSettings.GetFrameRate() == -1)
        {
            frameRate_picker.value = 0;
            foundFramerate = true;
        }
        else
        {
            for(int a = 1; a < frameRate_picker.options.Count; a++)
            {
                if (frameRate_picker.options[a].text.Equals(gameSettings.GetFrameRate().ToString()))
                {
                    frameRate_picker.value = a;
                    foundFramerate = true;
                    break;
                }
            }
        }
        if (!foundFramerate)
        {
            frameRate_picker.AddOptions(new List<string> { gameSettings.GetFrameRate().ToString() });
            frameRate_picker.value = (frameRate_picker.options.Count - 1);
        }
        frameRate_picker.RefreshShownValue();
    }
    private void LoadVolume(Slider volumeSlider, float savedVolume, Text volumePercent)
    {
        int inSliderValue = (int) (savedVolume * 100);
        volumeSlider.value = inSliderValue;
        volumePercent.text = inSliderValue.ToString();
    }
    private void LoadLanguage()
    {
        for(int a = 0; a < language_picker.options.Count; a++)
        {
            if (language_picker.options[a].text == langDictionary.GetLangByCode(gameSettings.GetLangCode()))
            {
                language_picker.value = a;
                break;
            }
        }
        language_picker.RefreshShownValue();
    }
    private void LoadFontSize()
    {
        int fontSize = gameSettings.GetFontSize();
        fontSize_slider.value = fontSize;
        fontSize_pixels.text = fontSize.ToString();
    }
    private void LoadHighlight()
    {
        highlight_toggle.isOn = gameSettings.GetHighlight();
    }
    private void LoadMouseSensitivity()
    {
        float sensitivity = gameSettings.GetMouseSensitivity();
        mouseSense_slider.value = sensitivity;
        mouseSense.text = sensitivity.ToString();
    }
    private void LoadControls()
    {
        int controls = gameSettings.GetControls();
        controls_picker.value = controls;
        ShowControlsButtons();

    }
    //value inloading functions
    private void InloadScreenMode()
    {
        gameSettings.SetScreenMode(screenMode_picker.value switch
        {
            0 => "fullscreen",
            1 => "fullscreen window",
            2 => "windowed",
            _ => "windowed"
        });
    }
    private void InloadScreenResolution()
    {
        gameSettings.SetScreenResolution(screenResolution_picker.options[screenResolution_picker.value].text);
    }
    private void InloadFrameRate()
    {
        if (frameRate_picker.value != 0)
        {
            gameSettings.SetFrameRate(int.Parse(frameRate_picker.options[frameRate_picker.value].text));
        }
        else
        {
            gameSettings.SetFrameRate(-1);
        }
    }
    private void InloadVolumes()
    {
        gameSettings.SetSoundVolume(((float)soundVolume_slider.value) / 100);
        gameSettings.SetMusicVolume(((float)musicVolume_slider.value) / 100);
        gameSettings.SetEnvironmentVolume(((float)envVolume_slider.value) / 100);
    }
    private void InloadLanguage()
    {
        gameSettings.SetLangCode(langDictionary.GetCodeByLang(language_picker.options[language_picker.value].text));
    }
    private void InloadFontSize()
    {
        gameSettings.SetFontSize((int)fontSize_slider.value);
    }
    private void InloadHighlight()
    {
        gameSettings.SetHighlight(highlight_toggle.isOn);
    }
    private void InloadMouseSensitivity()
    {
        float sense = (Mathf.Round(mouseSense_slider.value * 100) / 100);
        gameSettings.SetMouseSensitivity(sense);
    }
    private void InloadControls()
    {
        gameSettings.SetControls(controls_picker.value);
    }
}
