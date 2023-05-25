using UnityEngine;
using System.Collections.Generic;
using System;
[System.Serializable]
public struct AudioStruct
{
    public enum ActionType{
        Run,
        Jump,
        AirJump,
        Dash,
        Glide,
        BedJump,
        Climb,
        Wind,
    }
    public enum AudioType{
        
    }
    public ActionType actionType;
    public List<AudioType> audioType;
    public AudioStruct(ActionType actionType, List<AudioType> audioType){
        this.actionType = actionType;
        this.audioType = audioType;
    }
}

