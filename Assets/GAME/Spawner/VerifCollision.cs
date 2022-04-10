using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerifCollision : MonoBehaviour
{
    // Trigger = boite de collision ou collider 
    public ChanseySpawner spawner;
    public int hasChanseySpawned = 0;


    // Start is called before the first frame update

    void Start()
    {

    }

    void OnTriggerEnter(Collider col) // se lit qd col entre ds la boite de collision (le trigger) de l'objet à qui le script est associé
                                      // col correspond à l'objet qui entre dans la zone
    {
        if (col.name == "PlayerCharacter" && hasChanseySpawned == 0)        // col porte le nom de Cube
        {
            spawner.spawnChansey();
            ++hasChanseySpawned;
            //print("le cube est entré dans la zone verte");
        }
    }

    /*
    void OnTriggerExit(Collider col) //se lit qd l'objet cube sort de la boite de collision (le trigger)
    {
        if (col.name == "Cube")
        {
            print("le cube est sorti de la zone verte");
        }
    }


    void OnTriggerStay(Collider col) //se lit qd l'objet cube est dans la boite de collision (lue à chaque frame)
    {
        if (col.name == "Cube")
        {
            print("le cube est dans la zone verte");
        }
    }
    */

    // Update is called once per frame
    private void Update()
    {




    }
}
