using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    public static PlayerData instance;
    public int remainingCredits;
    
    void Awake(){
        instance = this;
    }
    void Start()
    {
        remainingCredits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
