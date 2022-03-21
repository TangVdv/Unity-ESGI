using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PokemonUI : MonoBehaviour
{

    public Text currentValueText;
    public Text maxValueText;

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
        currentValueText.text = i.ToString();
    }

    public string getPokemon()
    {
        return currentValueText.text;
    }
}
