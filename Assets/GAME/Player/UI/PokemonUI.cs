using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonUI : MonoBehaviour
{

    public Text currentValueText;
    public Text maxValueText;
    static private int i;

    public BossUI BUI;
    public TriggerCollision TColl_Cave;
    public TriggerCollision TColl_Cliff;

    void Start()
    {
        TriggerBoss();
    }

    public void SetMaxPokemon(string pokemon)
    {
        maxValueText.text = pokemon;
        currentValueText.text = i.ToString();
    }

    public void TriggerBoss()
    {
        if (i >= 10)
        {
            BUI.changeColor(false, "Boss_cave");
            TColl_Cave.TriggerIsActive(TColl_Cave.name);
        }
        if (i >= 20)
        {
            BUI.changeColor(false, "Boss_cliff");
            TColl_Cliff.TriggerIsActive(TColl_Cliff.name);
        }
    }

    public void AddPokemon()
    {
        if (i < 20)
        {
            int.TryParse(currentValueText.text, out i);
            i += 1;
            TriggerBoss();

            currentValueText.text = i.ToString();
        }
    }

    public string getPokemon()
    {
        return currentValueText.text;
    }
}
