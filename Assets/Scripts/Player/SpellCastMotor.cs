using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellCastMotor : MonoBehaviour
{
    [SerializeField] GameObject spell;
    [SerializeField] Transform SpellSpawnPoint;
    [SerializeField] float spellDelayTime = .5f;
    float fireTime = 0;
    public void Fire(float fire)
    {
        if (fire != 0 && Time.time - fireTime > spellDelayTime)
        {
            GameObject newSpell = Instantiate(spell, SpellSpawnPoint);
            newSpell.transform.parent = null;
            fireTime = Time.time;
        }else if (fire == 0)
        {
            fireTime = 0;
        }
    }
}
