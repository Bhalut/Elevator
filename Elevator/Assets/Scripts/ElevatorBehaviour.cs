using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ElevatorBehaviour : MonoBehaviour 
{
    [SerializeField]float speed;
    [SerializeField][Range(0, 675)]float weightMax;
    [SerializeField][Range(0, 9)]float quantityMax;
    [SerializeField][Range(0, 4)]int target;
    public Transform[] Grounds;

    public float QuantityMax
    {
        get { return quantityMax; }
        set { quantityMax = value; }
    }
	
    public float WeightMax
    {
        get { return weightMax; }
        set { weightMax = value; }
    }

	// Use this for initialization
	void Start () 
	{
        speed = 0.5f;
	}
	
	// Update is called once per frame
	void Update () 
	{
        Movement();
	}

    void Limit()
    {
        if (weightMax > 0 && weightMax <= 675)
        {
            if (quantityMax > 0 && quantityMax <= 9)
            {
                //Subir al ascensor
                Debug.Log(weightMax);
                Debug.Log(quantityMax);
            }
        }else
        {
            //No subir mas
        }
    }


    public void NextStop(int stop)
    {
        switch (stop)
        {
            case 0:
                //piso
                target = 0;
                break;
            case 1:
                //piso
                target = 1;
                break;
            case 2:
                //piso
                target = 2;
                break;
            case 3:
                //piso
                target = 3;
                break;
            case 4:
                //piso
                target = 4;
                break;
            default:
                goto case 0;
        }
    }

    void Movement()
    {
        transform.position = Vector3.Lerp(transform.position, Grounds[target].position, speed * Time.deltaTime);
        if (transform.position == Grounds[target].position)
        {
            
        }
        if (transform.position != Grounds[target].position)
        {
            
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("NPC"))
        {
            if (collision.collider.gameObject.GetComponent<NPC>())
            {
                weightMax += collision.collider.gameObject.GetComponent<NPC>().WeightMax;
                quantityMax++;
                Limit();
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("NPC"))
        {
            if (collision.collider.gameObject.GetComponent<NPC>())
            {
                weightMax -= collision.collider.gameObject.GetComponent<NPC>().WeightMax;
                quantityMax--;
                Limit();
            }
        }
    }
}
