using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FX : MonoBehaviour
{
    public GameObject clickFX;
    public GameObject glowFX;
    public GameObject glowParticleFX;
    public GameObject origin;

    private void Update()
    {
        if(GetComponentInParent<Repository>().commandList.Count > 0)
        {
            if (!glowParticleFX.GetComponent<ParticleSystem>().isPlaying && !glowFX.GetComponent<ParticleSystem>().isPlaying)
            {
                glowFX.GetComponent<ParticleSystem>().Play();
                glowParticleFX.GetComponent<ParticleSystem>().Play();
            }
        }
        else
        {
            if(!glowParticleFX.GetComponent<ParticleSystem>().isStopped && !glowFX.GetComponent<ParticleSystem>().isStopped)
            {
                glowParticleFX.GetComponent<ParticleSystem>().Stop();
                glowFX.GetComponent<ParticleSystem>().Stop();
            }
        }
    }


    public void SpawnClickedVFX()
    {
        if(clickFX != null)
        {
            AudioManager.instance.Play("compile");
            var vfx = Instantiate(clickFX, origin.transform.position, Quaternion.identity) as GameObject;
            vfx.transform.SetParent(origin.transform);

            var ps = vfx.GetComponent<ParticleSystem>();
            Destroy(vfx, ps.main.duration + ps.main.startLifetime.constantMax);
        }
        if(glowFX != null)
        {

        }
    }
}
