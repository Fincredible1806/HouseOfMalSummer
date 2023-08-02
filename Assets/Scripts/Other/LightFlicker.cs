using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light flickerLight;

    public float MinTime;
    public float MaxTime;
    public float Timer;

    public AudioSource AS;
    public AudioClip LightAudio;
    // Start is called before the first frame update
    void Start()
    {
        TimeSet();
    }



    // Update is called once per frame
    void Update()
    {
        FlickerLight();
    }

    void FlickerLight()
    {
        if (Timer > 0)
            Timer -= Time.deltaTime;

        if(Timer<=0)
        {
            flickerLight.enabled = !flickerLight.enabled;
            TimeSet();
            AS.Play();
        }
    }

    private void TimeSet()
    {
        Timer = Random.Range(MinTime, MaxTime);
    }
}
