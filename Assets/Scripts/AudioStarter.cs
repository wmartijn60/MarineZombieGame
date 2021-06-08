using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioStarter : MonoBehaviour
{
    bool audioResumed = false;
    
    void Update()
    {
        if (FMODUnity.RuntimeManager.HasBanksLoaded && !audioResumed) {
            ResumeAudio();
            audioResumed = true;
        }
    }

    public void ResumeAudio() {
        var result = FMODUnity.RuntimeManager.CoreSystem.mixerSuspend();
        Debug.Log(result);
        result = FMODUnity.RuntimeManager.CoreSystem.mixerResume();
        Debug.Log(result);
        //audioResumed = true;
        GetComponent<FMODUnity.StudioEventEmitter>().Stop();
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
    }
}
