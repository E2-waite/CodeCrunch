using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_FX : MonoBehaviour
{
    public GameObject clickFX;
    public GameObject glowFX;
    public GameObject origin;


    public void SpawnClickedVFX()
    {
        if(clickFX != null)
        {
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
