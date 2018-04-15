using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow_Move : MonoBehaviour {

    private Vector3 posONE;
    private Vector3 posTWO;
    private Vector3 arrowSwitch;

    [SerializeField] private float speed;

    [SerializeField] private Transform childTransform;

    [SerializeField] private Transform transformB;

    
    // Use this for initialization
    void Start () {

        posONE = childTransform.localPosition;
        posTWO = transformB.localPosition;

        arrowSwitch = posTWO;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
	}

    private void Move()
    {
        childTransform.localPosition = 
            Vector3.MoveTowards(childTransform.localPosition, arrowSwitch, speed * Time.deltaTime);

        if (Vector3.Distance(childTransform.localPosition, arrowSwitch) <=0.1)
        {
            ReverseMove();
        }
    }

    private void ReverseMove()
    {
        arrowSwitch = arrowSwitch != posONE ? posONE : posTWO;
    }
}
