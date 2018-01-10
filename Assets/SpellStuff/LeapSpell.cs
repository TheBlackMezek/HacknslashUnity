using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeapSpell : SpellBase {

    public float spellLength = 0.5f;
    public float rushSpeed = 10.0f;

    private float rushTime = 0;
    private CharacterController cc;




    private void FixedUpdate()
    {
        if(rushTime > 0)
        {
            rushTime -= Time.fixedDeltaTime;

            Vector3 moveVec = cc.transform.forward;
            moveVec *= rushSpeed * Time.fixedDeltaTime;
            
            cc.GetComponent<CharacterController>().Move(moveVec);
        }
    }



    public override bool CastSpell(GameObject caster)
    {
        if(rushTime <= 0 && base.CastSpell(caster))
        {
            cc = caster.GetComponent<CharacterController>();
            rushTime = spellLength;
            return true;
        }
        return false;
    }

}
