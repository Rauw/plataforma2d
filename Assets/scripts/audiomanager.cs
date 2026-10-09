using UnityEngine;

public class audiomanager : MonoBehaviour
{
    
    private AudioSource MusicSource;
    private AudioSource ambientSource;
    private AudioSource[] SfxSource; //array
    public static audiomanager instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            MusicSource = gameObject.AddComponent<AudioSource>();
            ambientSource = gameObject.AddComponent<AudioSource>();
            SfxSource = new AudioSource[4];
            
           // for // segun un indice numerico que va incrementando
           for (int i = 0; i < SfxSource.Length; i++)
           {
               SfxSource[i] = gameObject.AddComponent<AudioSource>();
           }
            
           // foreach //repasa una array o lista entera con duplicados de su contenido
          /* foreach (AudioSource source in SfxSource)
           {
               source=gameObject.AddComponent<AudioSource>();
           } */

           // while // ejecuta su contenido hasta que se cumple una condicion
           /*int j = 0;
           while (j < SfxSource.Length)
           {
               SfxSource[j] = gameObject.AddComponent<AudioSource>();
               j++;
           }*/
           
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMusic(AudioClip _clip)
    {
        MusicSource.clip = _clip;
        MusicSource.loop = true;
        MusicSource.Play();
        
    }

    public void stopMusic()
    {
        MusicSource.Stop();
    }

    public void PlayAmbient(AudioClip _clip)
    {
        ambientSource.clip = _clip;
        ambientSource.loop = true;
        ambientSource.Play();
        
    }

    public void StopAmbient()
    {
        ambientSource.Stop();
    }

    public void PlaySfx(AudioClip _clip)
    {
        for (int i = 0; i < SfxSource.Length; i++)
        {
            if(SfxSource[i].isPlaying==false)
            {
                SfxSource[i].clip = _clip;
                SfxSource[i].Play();
                break;
            }
        }
        
    }
}
