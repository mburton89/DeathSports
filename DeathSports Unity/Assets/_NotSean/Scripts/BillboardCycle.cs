using UnityEngine;
using System.Collections;

public class BillboardCycle : MonoBehaviour
{

    Color[] colors;
    Renderer thisRend; //Renderer of our Cube
    float transitionTime = 5f; // Amount of time it takes to fade between colors

    Material m_Material;

    void Start()

    {
        thisRend = GetComponent<Renderer>(); // grab the renderer component on our cube
         colors = new Color[6]; // We will randomize through this array

        //initialize our array indexes with colors
        colors[0] = Color.white;
        colors[1] = Color.black;
        colors[2] = Color.red;
        colors[3] = Color.green;
        colors[4] = Color.blue;
        colors[5] = Color.magenta;

        m_Material = GetComponent <Renderer>().material;

        StartCoroutine(ColorChange());
    }

    void Update()

    {

    }

    IEnumerator ColorChange()

    {
        //Infinite loop will ensure our coroutine runs all game
        while (true)
        {
            Color newColor = colors[(Random.Range(0, 5))]; // Assign newColor to a random color from our array
            float transitionRate = 0; //Create and set transitionRate to 0. This is necessary for our next while loop to function
            
            while (transitionRate < 1)
            {
                //this next line is how we change our material color property. We Lerp between the current color and newColor
                thisRend.material.SetColor("_Color", Color.Lerp(thisRend.material.color, newColor, Time.deltaTime * transitionRate));
                transitionRate += Time.deltaTime / transitionTime; // Increment transitionRate over the length of transitionTime
                yield return null; // wait for a frame then loop again
            }
            yield return null; // wait for a frame then loop again
        }
    }
}