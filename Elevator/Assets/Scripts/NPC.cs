using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour 
{
    [SerializeField] [Range(65, 100)] float weightMax;

    [SerializeField] float distance;

    ElevatorBehaviour elevator;

    public float WeightMax
    {
        get { return weightMax; }
        set { weightMax = value; }
    }

	// Use this for initialization
	void Start () 
    {
        elevator = FindObjectOfType<ElevatorBehaviour>();
        weightMax = 75;	
	}

    private void OnMouseDrag()
    {
        Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);
        Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (elevator.WeightMax < 675 && elevator.QuantityMax < 9)
        transform.position = objPosition;
    }
}
