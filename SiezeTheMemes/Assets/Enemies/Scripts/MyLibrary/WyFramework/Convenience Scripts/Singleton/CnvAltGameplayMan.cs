using System;
using UnityEngine;
public class CnvAltGameplayMan
{
    public static CnvAltGameplayMan instance;

    public GameplayState gameplayState;

    public enum GameplayState{
         GAME_PAUSE,
         GAME_RUNNING,
         GAME_ENDLOSE,
         GAME_ENDWIN
        
    }
    
    void Awake()
    {
        if (instance != null) {
            instance = this;
        }

    }

    // enum Game State
    
}
