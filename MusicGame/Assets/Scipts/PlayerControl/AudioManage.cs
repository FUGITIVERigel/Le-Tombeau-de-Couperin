using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class AudioManage : MonoBehaviour
{
    [SerializeField]public List<AudioStruct> audioStructs;
    public AudioSource audioSource;
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayAudio(AudioStruct.ActionType actionType,int index){
        foreach(AudioStruct audioStruct in audioStructs){
            if(audioStruct.actionType==actionType){
                AudioClip audioClip = Resources.Load<AudioClip>("Audio/"+audioStruct.audioType[index]);
                audioSource.PlayOneShot(audioClip);
            }
        }
    }
}
