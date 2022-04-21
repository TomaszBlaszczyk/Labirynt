using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crystal : MonoBehaviour
{
    private Animator animator;
    private GameObject crystalObject;
    void Start()
    {
        animator = GetComponent<Animator>();
        crystalObject = GetComponent<GameObject>(); 
    }

    void Update()
    {
        animator.SetTrigger("Rotate");
    }

    public void CrystalController()
    {
        
    }
}
