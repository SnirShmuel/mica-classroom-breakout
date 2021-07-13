using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DragAndDropScript : MonoBehaviour
{
    public GameObject SelectedPiece;
    int OrderInLayer = 1;
    private bool isFinish = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Check if piece was selected
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(hit.transform.CompareTag("Puzzle"))
            {
                if (!hit.transform.GetComponent<PuzzleGameScript>().isInRightPosition)
                {
                    SelectedPiece = hit.transform.gameObject;
                    SelectedPiece.GetComponent<PuzzleGameScript>().isSelected = true;
                    SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OrderInLayer;
                    OrderInLayer++;
                }
                
            }
        }

        // Drop piece
        if (Input.GetMouseButtonUp(0))
        {
            if (SelectedPiece != null)
            {
                SelectedPiece.GetComponent<PuzzleGameScript>().isSelected = false;
                SelectedPiece = null;
            }
            
        }


        if(SelectedPiece != null)
        {
            Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
        }

        checkWin();

        
        // Check win
        if (isFinish)
        {
            Application.Quit();
        }
    }

    private void checkWin()
    {
        bool isInPlace = true;
        for (int i = 0; i < 36; i++)
        {
            if (!GameObject.Find("Piece (" + i + ")").GetComponent<PuzzleGameScript>().isInRightPosition)
            {
                isInPlace = false;
            }
        }

        if (isInPlace)
            isFinish = true;
    }
}
