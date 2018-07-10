using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TombDoorAnim : MonoBehaviour 
{
    public delegate void AnimUpdate();
    public AnimUpdate OnTombUpdate;

    [SerializeField] Animator tombAnim;

    void Awake()
    {
        OnTombUpdate += UpdateTombAnim;    
    }

    void UpdateTombAnim()
    {
        if(!tombAnim.GetBool("canOpen"))
            tombAnim.SetBool("canOpen", true);
        
    }
}
