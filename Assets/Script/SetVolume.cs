using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
   public AudioMixer mixer;
   public void SetLevelMusic (float sliderValue)
   {
       mixer.SetFloat("MusicVol", Mathf.Log10(sliderValue) * 20);
   }
   public void SetLevelSound (float sliderValue)
   {
       mixer.SetFloat("SoundVol", Mathf.Log10(sliderValue) * 20);
   }
}
