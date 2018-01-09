using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushSpell : SpellBase {

    public float wallLifetime = 1.0f;
    public GameObject pushWall;



    public override bool CastSpell(GameObject caster)
    {
        if(base.CastSpell(caster))
        {
            GameObject wall = Instantiate(pushWall);
            wall.transform.position = transform.position;
            wall.transform.rotation = transform.rotation;
            Destroy(wall, wallLifetime);
            return true;
        }
        return false;
    }

}
