using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

///<summary> 
///     This class sets a timer in game, that will keep counting down in real time.0
///         
///     Explanation:

/// 		
///     Usage:

/// 		
///     Integration:

///
///     Implement Later: 
/// 
/// </summary>
///
/// 
public class MechExtraWorldStatTimer : MonoBehaviour
{

    public static MechExtraWorldStatTimer instance;
    public float currentCountDownTimer = 100f;
    public Text StatTimerText;
    public Slider StatTimerSlider;
    public Image StatTimerImg;

    public bool isPauseTimer;
    

    private float initCountDownTimer;
    private void Awake()
    {
        initCountDownTimer = currentCountDownTimer;
        if(!instance )
            instance = this;
    }

    void Update()
    {
        if(!isPauseTimer)
            currentCountDownTimer -= Time.deltaTime;
        
        if(StatTimerText)
            StatTimerText.text = Mathf.RoundToInt(currentCountDownTimer).ToString();
        if(StatTimerSlider)
            StatTimerSlider.value = currentCountDownTimer / initCountDownTimer;
        if(StatTimerImg)    
            StatTimerImg.fillAmount = currentCountDownTimer / initCountDownTimer;

    }

    public void ResetTimer(float newtimerValue, float newMaxValue)
    {
        isPauseTimer = true;
        currentCountDownTimer = newtimerValue;
        initCountDownTimer = newMaxValue;
        isPauseTimer = false;
    }
    
}