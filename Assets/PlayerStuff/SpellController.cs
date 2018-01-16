using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {

    public SpellBase[] spells;

    private int currentSpell = 0;


    private void Start()
    {
        if (spells.Length > 0)
        {
            spells[currentSpell].SelectSpell();
        }
    }

    // Update is called once per frame
    void Update () {

        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            SwitchSpell(0);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SwitchSpell(1);
        }


        if (Input.GetKeyDown(KeyCode.Q) && spells.Length > 0)
        {
            spells[currentSpell].CastSpell(gameObject);
        }
	}

    private void SwitchSpell(int spell)
    {
        spells[currentSpell].DeselectSpell();
        currentSpell = spell;
        spells[currentSpell].SelectSpell();
    }
}
