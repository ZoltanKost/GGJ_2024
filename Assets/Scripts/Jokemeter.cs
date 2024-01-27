using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jokemeter : MonoBehaviour
{
    [SerializeField] private float jokeMeterValue;
    [Serialziefield] private GameObject jokemeterImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (JokeMeterValue < 100)
        {
            jokeMeterValue += 1;
        }
        jokemeterImage.Transform.height = jokeMeterValue;
    }
}
