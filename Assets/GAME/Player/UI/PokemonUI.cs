using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonUI : MonoBehaviour
{

    public Text currentValueText;
    public Text maxValueText;

    public BossUI BUI;
    public TriggerCollision TColl_Cave;
    public TriggerCollision TColl_Mountain;
    public TriggerCollision TColl_Cliff;

    public void SetMaxPokemon(string pokemon)
    {
        maxValueText.text = pokemon;
        currentValueText.text = "0";
    }

    public void AddPokemon()
    {
        int i;
        int.TryParse(currentValueText.text, out i);
        i += 1;
        if (i == 10)
        {
            BUI.changeColor(false, "Boss_cave");
            TColl_Cave.TriggerIsActive(TColl_Cave.name);
        }
        else if (i == 20)
        {
            BUI.changeColor(false, "Boss_cliff");
            TColl_Cliff.TriggerIsActive(TColl_Cliff.name);
        }
        else if (i == 30)
        {
            BUI.changeColor(false, "Boss_mountain");
            TColl_Mountain.TriggerIsActive(TColl_Mountain.name);
        }
        currentValueText.text = i.ToString();
    }

    public string getPokemon()
    {
        return currentValueText.text;
    }
}
