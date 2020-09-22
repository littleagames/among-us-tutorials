using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimonTask : MonoBehaviour
{
    public List<GameObject> _simonDisplay;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonPressed(int index)
    {
        Debug.Log($"Button Presssed: {index}");
    }
}
