
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//
// modified 2020-08-04
//

public class SFXVolumeController : MonoBehaviour
{
    // reference to audio controller script
    private AudioController audioController;

    private Text sfxVolumeControlText;


    // Start is called before the first frame update
    private void Start()
    {
        audioController = AudioController.instance;

        sfxVolumeControlText = GetComponent<Text>();

        GetComponentInParent<Slider>().onValueChanged.AddListener(SFXVolumeControl);
    }


    public void SFXVolumeControl(float sfxVolume)
    {
        audioController.SetSFXVolume(sfxVolume);

        sfxVolumeControlText.text = (sfxVolume * 10).ToString("0");
    }


} // end of class
