using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    public ParticleSystem ps;

    public void Play()
    {
        ps.Play();
        StartCoroutine("Stop");
    }

    IEnumerator Stop()
    {
        yield return new WaitForSeconds(0.5f);
        ps.Stop();
    }
}
