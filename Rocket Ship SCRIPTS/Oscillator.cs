using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    Vector3 endPosition;
    [SerializeField]Vector3 movementVector;
     float movementFactor;
    [SerializeField] float Speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
       startingPosition = transform.position;
        endPosition = startingPosition+movementVector;
        
    }

    // Update is called once per frame
    void Update()
    {
        movementFactor = Mathf.PingPong(Time.time*Speed ,1f);
        transform.position = Vector3.Lerp(startingPosition, endPosition, movementFactor);

    } 
}
