using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnButton : MonoBehaviour
{
    public GameObject myObject;
    
    public void spawnItem()
    {
         Instantiate(myObject);
    }
}
