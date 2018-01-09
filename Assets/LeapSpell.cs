using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LeapSpell : SpellBase {
    

    public override void CastSpell(GameObject caster)
    {

        Vector3 moveVec = caster.transform.forward;
        moveVec *= 50;

        caster.GetComponent<CharacterController>().Move(moveVec);
    }

}
