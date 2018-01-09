using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellController : MonoBehaviour {

    public SpellBase[] spells;


    private void Start()
    {
        spells = new SpellBase[4];
        spells[0] = new LeapSpell();
    }

    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Q) && spells.Length > 0)
        {
            spells[0].CastSpell(gameObject);
        }
	}
}
