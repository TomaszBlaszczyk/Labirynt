using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    private Rigidbody rBody;
    //public float distance;
    [SerializeField] private float minDistance;
    [SerializeField] private float maxDistance;
    //public float speed;
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;
    private float currentWallX;
    public bool isActive;
    float rVarDist;
    private void Start()
    {
        rBody = GetComponent<Rigidbody>();
        Active();
    }
    private void Update()
    {
        if (rBody.position.x >= (rVarDist+currentWallX))
        {
            rBody.velocity = Vector3.zero;
        }
    }
    public void Active()
    {
        rVarDist = Random.Range(minDistance, (maxDistance + 1));//Random value for distance
        float rVarSpeed = Random.Range(minDistance, (maxDistance + 1));//Random value for speed
        currentWallX = rBody.position.x;//


        rBody.velocity = new Vector3(rVarSpeed,0);
        print("rBody velocity = " + rBody.velocity+"\n rVarDist = "+rVarDist+" currentWallX = "+currentWallX);
      
    
        //while (currentWallX)
        //{
            
        //}
        
    }
  
}