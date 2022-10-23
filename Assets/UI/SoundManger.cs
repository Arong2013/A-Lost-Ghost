using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]
public class Sound
{
    public string soundname;
    public AudioClip clip;
}
public class SoundManger : MonoBehaviour
{
    #region Singleton

    public static SoundManger instance;
    public void Awake()
    {
        instance = this;
    }
    #endregion

    //[FoldoutGroup("BGM")]
    [SerializeField]
    private List<Sound> BGM;
    //  [FoldoutGroup("BGM")]
    [SerializeField]
    AudioSource BGMplayer;
    // [FoldoutGroup("BGM")]
    [SerializeField]
    Slider BGMbar;
    // [FoldoutGroup("BGM")]
    [SerializeField]
    Text BGMtext;

    // [FoldoutGroup("SFX")]
    [SerializeField]
    List<Sound> SFX;
    // [FoldoutGroup("SFX")]
    [SerializeField]
    List<AudioSource> SFXplayer;
    // [FoldoutGroup("SFX")]
    [SerializeField]
    Slider SFXbar;
    //[FoldoutGroup("SFX")]
    [SerializeField]
    Text SFXtext;

    public void BGMplay(string name)
    {
        for (int i = 0; i < BGM.Count; i++)
        {
            if (BGM[i].soundname == name)
            {
                BGMplayer.clip = BGM[i].clip;
                BGMplayer.Play();
                break;
            }
        }

    }

    public void BGM_POS(bool what)
    {
        if (what)
            BGMplayer.Play();
        else
            BGMplayer.Stop();
    }

    public void Set_BGM_Volume()
    {
        BGMplayer.volume = BGMbar.value * 1 / 100;
        int Volume = (int)BGMbar.value;
       // BGMtext.text = Volume.ToString();
    }



    public void SFXplay(string name)
    {
        for (int i = 0; i < SFX.Count; i++)
        {
            if (SFX[i].soundname == name)
            {
                for (int x = 0; x < SFXplayer.Count; x++)
                {
                    if (!SFXplayer[x].isPlaying)
                    {
                        SFXplayer[x].clip = SFX[i].clip;
                        SFXplayer[x].Play();
                        return;
                    }
                }
            }
        }
    }
    public void Set_SFX_Volume()
    {
        for (int i = 0; i < SFXplayer.Count; i++)
        {
            SFXplayer[i].volume = SFXbar.value * 1 / 100;
        }

        int Volume = (int)SFXbar.value;
       // SFXtext.text = Volume.ToString();
    }
}
