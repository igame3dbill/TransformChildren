using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;


[ExecuteInEditMode]
public class TransformChildren : MonoBehaviour
{
    public bool doTransform = false;
    public bool prefabHasTransform = false;
	public int columns;
	public int rowDepth;
    public Vector3 Direction = new Vector3(1, 0, 0);
    public Vector3 newPosition;
    public Vector3 sourcePosition;
    public Vector3 oldPosition;
	private int cols;
	private float oldDirX;
	private int oldRowDepth;
	private Vector3 oldSourcePosition;
#if UNITY_EDITOR
   
#endif
    void Awake()
    {
       sourcePosition =  gameObject.GetComponent<Transform>().position; 
    }
    public void TransformEach(){
        doTransform = false;
            prefabHasTransform = true;
        oldPosition = sourcePosition;
		  cols = 0;
		oldDirX = Direction.x;
		oldRowDepth = rowDepth;
		oldSourcePosition = new Vector3(sourcePosition.x,sourcePosition.y,sourcePosition.z);
     foreach (Transform child in transform)
            {
			
			
                     newPosition.x = oldPosition.x + Direction.x;
                     newPosition.y = oldPosition.y + Direction.y;
                     newPosition.z = oldPosition.z + Direction.z;
                    child.gameObject.transform.position = new Vector3( newPosition.x, newPosition.y, newPosition.z);
                    oldPosition = child.GetComponent<Transform>().position;
					cols = cols + 1;
					if (cols >= columns){
					cols = 0;
					oldPosition.x = oldSourcePosition.x;
					oldPosition.z = oldPosition.z + rowDepth;
					Direction.x = oldDirX;
					//rowDepth = rowDepth + oldRowDepth;
					}
            }
    }

    public void Update()
    {
        if (doTransform == true)
        {

            TransformEach();    
        }
    }
}