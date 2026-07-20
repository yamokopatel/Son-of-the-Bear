using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

[CreateAssetMenu(fileName = "StaticSettings", menuName = "Scriptable Objects/StaticSettings")]
public class StaticSettings : ScriptableObject
{
    [SerializeField] private StaticLines staticLines;

    [Header ("Screen settings")]
    [SerializeField] private string screenMode = "fullscreen";
    [SerializeField] private string screenResolution = "1920x1080";
    [SerializeField] private int frameRate = -1;

    [Header ("UI settings")]
    [SerializeField] private string langCode = "en";
    [SerializeField] private int fontSize = 16;
    [SerializeField] private bool highlight = false;

    [Header ("Sound settings")]
    [SerializeField] private float soundVolume = 1f;
    [SerializeField] private float musicVolume = 1f;
    [SerializeField] private float environmentVolume = 1f;

    [Header ("Controls settings")]
    [SerializeField] private float mouseSensitivity = 0.4f;
    [SerializeField] private int controls = 0; //0 = qwerty

    public void SaveSettings()
    {
        //Screen
        PlayerPrefs.SetString("Setting_ScreenMode", screenMode);
        PlayerPrefs.SetString("Setting_ScreenResolution", screenResolution);
        PlayerPrefs.SetInt("Setting_FrameRate", frameRate);
        //UI
        PlayerPrefs.SetString("Setting_LangCode", langCode);
        PlayerPrefs.SetInt("Setting_FontSize", fontSize);
        PlayerPrefs.SetInt("Setting_Highlight", (highlight ? 1 : 0));
        //Sound
        PlayerPrefs.SetFloat("Setting_SoundVolume", soundVolume);
        PlayerPrefs.SetFloat("Setting_MusicVolume", musicVolume);
        PlayerPrefs.SetFloat("Setting_EnvironmentVolume", environmentVolume);
        //Controls
        PlayerPrefs.SetFloat("Setting_MouseSensitivity", mouseSensitivity);
        PlayerPrefs.SetInt("Setting_Controls", controls);

        PlayerPrefs.Save();
    }

    public void LoadSettings()
    {
        if (PlayerPrefs.HasKey("Setting_ScreenResolution"))
        {
            //Screen
            screenMode = PlayerPrefs.GetString("Setting_ScreenMode");
            screenResolution = PlayerPrefs.GetString("Setting_ScreenResolution");
            frameRate = PlayerPrefs.GetInt("Setting_FrameRate");
            //UI
            langCode = PlayerPrefs.GetString("Setting_LangCode");
            fontSize = PlayerPrefs.GetInt("Setting_FontSize");
            highlight = PlayerPrefs.GetInt("Setting_Highlight") == 1;
            //Sound
            soundVolume = PlayerPrefs.GetFloat("Setting_SoundVolume");
            musicVolume = PlayerPrefs.GetFloat("Setting_MusicVolume");
            environmentVolume = PlayerPrefs.GetFloat("Setting_EnvironmentVolume");
            //Controls
            mouseSensitivity = PlayerPrefs.GetFloat("Setting_MouseSensitivity");
            controls = PlayerPrefs.GetInt("Setting_Controls");
        }
        else
        {
            SaveSettings();
        }
    }
    public void UseSettings()
    {
        //настройка разрешения
        string[] res = screenResolution.Split("x");
        int width = int.Parse(res[0]);
        int height = int.Parse(res[1]);
        //UI и UX
        staticLines.LoadLocalLines(langCode);
        //настройка режима
        FullScreenMode mode = screenMode switch
        {
            "fullscreen" => FullScreenMode.ExclusiveFullScreen,
            "fullscreen window" => FullScreenMode.FullScreenWindow,
            "windowed" => FullScreenMode.Windowed,
            _ => FullScreenMode.Windowed
        };
        Screen.SetResolution(width, height, mode);
        //настройка фпс
        if (frameRate != -1)
        {
            QualitySettings.vSyncCount = 0;
        }
        else
        {
            QualitySettings.vSyncCount = 1;
        }
        Application.targetFrameRate = frameRate;
    }

    //Getters
    public string GetScreenMode() => screenMode;
    public string GetScreenResolution() => screenResolution;
    public int GetFrameRate() => frameRate;
    public string GetLangCode() => langCode;
    public int GetFontSize() => fontSize;
    public bool GetHighlight() => highlight;
    public float GetSoundVolume() => soundVolume;
    public float GetMusicVolume() => musicVolume;
    public float GetEnvironmentVolume() => environmentVolume;
    public float GetMouseSensitivity() => mouseSensitivity;
    public int GetControls() => controls;
    public StaticLines GetStaticLines() => staticLines;

    //Setters
    public void SetScreenMode(string screenMode) => this.screenMode = screenMode;
    public void SetScreenResolution(string screenResolution) => this.screenResolution = screenResolution;
    public void SetFrameRate(int frameRate) => this.frameRate = frameRate;
    public void SetLangCode(string langCode) => this.langCode = langCode;
    public void SetFontSize(int fontSize) => this.fontSize = fontSize;
    public void SetHighlight(bool highlight) => this.highlight = highlight;
    public void SetSoundVolume(float soundVolume) => this.soundVolume = soundVolume;
    public void SetMusicVolume(float musicVolume) => this.musicVolume = musicVolume;
    public void SetEnvironmentVolume(float environmentVolume) => this.environmentVolume = environmentVolume;
    public void SetMouseSensitivity(float mouseSensitivity) => this.mouseSensitivity = mouseSensitivity;
    public void SetControls(int controls) => this.controls = controls;
}
