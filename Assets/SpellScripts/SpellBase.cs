using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellBase : MonoBehaviour {

    public float coolDown = 1.0f;
    public ParticleSystem particleSys;

    protected float heat = 0;
    protected bool spellSelected = false;




	virtual public bool CastSpell(GameObject caster)
    {
        if(heat <= 0)
        {
            heat = coolDown;
            particleSys.Stop();
            return true;
        }
        return false;
    }

    virtual public void Update()
    {
        if(heat > 0)
        {
            heat -= Time.deltaTime;
            if (heat <= 0 && spellSelected)
            {
                particleSys.Play();
            }
        }
    }

    virtual public void SelectSpell()
    {
        if(particleSys)
        {
            if(heat <= 0)
            {
                particleSys.Play();
            }
            spellSelected = true;
        }
    }

    virtual public void DeselectSpell()
    {
        if (particleSys)
        {
            particleSys.Stop();
            spellSelected = false;
        }
    }

}
