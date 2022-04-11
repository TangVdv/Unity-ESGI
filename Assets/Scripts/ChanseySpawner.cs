using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChanseySpawner : MonoBehaviour
{

    public GameObject Chansey;

    // Start is called before the first frame update
    void Start()
    {
        
        //Instantiate(Chansey, transform.position, transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnChansey()
    {
        Instantiate(Chansey, transform.position, transform.rotation);

    }
}
