using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SattingManager : MonoBehaviour
{
    [Header("Element")]
    [SerializeField] private Sprite ButtonOnSprite;
    [SerializeField] private Sprite ButtonOffSprite;
    [SerializeField] private Image SoundImage;
    [SerializeField] private Image VibrationImage;
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private VibrationManager vibrationManager;
    private bool SoundState= true;
    private bool VibrationState= true;
    // Start is called before the first frame update
    private void Awake() {
        SoundState = PlayerPrefs.GetInt("sound",1) == 1;
        VibrationState = PlayerPrefs.GetInt("vibration",1) == 1;
    }
    void Start()
    {
        Setup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Setup()
    {
        if(SoundState)
            EnabledSound();
        else
            DisabledSound();
        
        if(VibrationState)
            EnableVibration();
        else 
            DisableVibration();
    }


    public void SoundStateChange()
    {
        if(SoundState)
            DisabledSound();
        else
            EnabledSound();
        
        SoundState = !SoundState;

        PlayerPrefs.SetInt("sound", SoundState? 1:0);
    }
    public void vibrationStateChange()
    {
        if(VibrationState)
            DisableVibration();
        else
            EnableVibration();
        
        VibrationState =!VibrationState;
        PlayerPrefs.SetInt("vibration", SoundState? 1:0);

    }
    private void EnabledSound()
    {
        SoundImage.sprite = ButtonOnSprite;
        soundManager.EnabledSound();
    }
    private void DisabledSound()
    {
        SoundImage.sprite = ButtonOffSprite;
        soundManager.DisabledSound();
    }

    private void EnableVibration()
    {
        VibrationImage.sprite = ButtonOnSprite;
        vibrationManager.EnableVibration();
    }
    private void DisableVibration()
    {
        VibrationImage.sprite = ButtonOffSprite;
        vibrationManager.DisableVibration();
    }

}
