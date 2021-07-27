using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PuzzleGameScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool isInRightPosition;
    public bool isSelected;


    // Start is called before the first frame update
    void Start()
    {
        RightPosition = transform.position;
        transform.position = new Vector3(Random.Range(2f, 12f), Random.Range(0f, 9f), 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, RightPosition) < 0.5f)
        {
            if (!isSelected)
            {
                if (!isInRightPosition)
                {
                    transform.position = RightPosition;
                    isInRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }

            }

        }
    }
}
