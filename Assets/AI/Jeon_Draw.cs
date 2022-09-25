using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Tilemaps;
using System.Linq;

public class Jeon_Draw : MonoBehaviour
{
    #region Singleton

    public static Jeon_Draw instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != this)
            Destroy(gameObject); instance = this;
    }
    #endregion
    public enum Touching
    {
        Down,        
        Up,
    }
    public enum What
    {
        Draw,
        Remove,
    }
    [SerializeField] private Line LinePrefabs;
	public Touching touching;
	public What what;


	public GameObject linePrefab;
	public LayerMask cantDrawOverLayer;
	int cantDrawOverLayerIndex;



	[Space(30f)]
	public Gradient lineColor;
	public float linePointsMinDistance;
	public float lineWidth;

	Line currentLine;

	Camera cam;

	void Start()
	{
		cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawOver");
	}
	// Begin Draw ----------------------------------------------
	public void BeginDraw()
	{
		currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();

		//Set line properties
		currentLine.UsePhysics(false);
		currentLine.SetLineColor(lineColor);
		currentLine.SetPointsMinDistance(linePointsMinDistance);
		currentLine.SetLineWidth(lineWidth);

	}
	// Draw ----------------------------------------------------
	public void Draw()
	{
		if (currentLine != null)
        {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			//Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )
			RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer);

			if (hit)
				EndDraw();
			else
				currentLine.AddPoint(mousePosition);
		}
		
	}
	// End Draw ------------------------------------------------
	public void EndDraw()
	{
		if (currentLine != null)
		{
			if (currentLine.pointsCount < 2)
			{
				//If line has one point
				Destroy(currentLine.gameObject);
			}
			else
			{
				//Add the line to "CantDrawOver" layer
				currentLine.gameObject.layer = cantDrawOverLayerIndex;

				//Activate Physics on the line
				currentLine.UsePhysics(true);

				currentLine = null;
			}
		}
		GameUI.instance.TouchUI.SetActive(false);
	}
}
