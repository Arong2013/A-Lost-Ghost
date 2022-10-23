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

	[SerializeField]
	private LayerMask layer;

	[SerializeField]
	GameObject linePrefab;

	[SerializeField]
	LayerMask cantDrawOverLayer;
	int cantDrawOverLayerIndex;


	[SerializeField]
	[Space(30f)]
	Gradient lineColor;

	[SerializeField]
	float linePointsMinDistance, lineWidth;

	Line currentLine;
    [SerializeField]
    private Camera cam;

	void Start()
	{
		cantDrawOverLayerIndex = LayerMask.NameToLayer("CantDrawOver");
	}

	public void BeginDraw()
	{
		if(what == What.Draw)
		{
            currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();//생성된 라인을 Cur에 지정

            currentLine.UsePhysics(false);//그리기 시작할때는 물리 효과X
            currentLine.SetLineColor(lineColor);//라인 렌더러 색지정
            currentLine.SetPointsMinDistance(linePointsMinDistance);//터치 했을때 최소 길이
            currentLine.SetLineWidth(lineWidth);//두깨 최소 두깨
        }
		else if(what == What.Remove)
        {
			Vector2 vector2 = Input.mousePosition;
			vector2 = cam.ScreenToWorldPoint(vector2);
			Collider2D hit = Physics2D.OverlapBox(vector2, new Vector2(2,2), 0,layer); 
			if (hit)
				Destroy(hit.transform.gameObject); // 제거라고 되어 있을때 터치한곳 콜라이더 찾기
		}
		
	}
	public void Draw()
	{
		if (currentLine != null)
        {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 1f, Vector2.zero, 1f, cantDrawOverLayer);

			if (hit)
				EndDraw(); // 만약에 그리고 있는 곳이 플레이어랑 만나면 강제로 멈추기
			else
				currentLine.AddPoint(mousePosition); // 그리기
		}
		
	}
	public void EndDraw()
	{
		if (currentLine != null)
		{
			if (currentLine.pointsCount < 2)
			{
				Destroy(currentLine.gameObject);
			}
			else
			{
				currentLine.gameObject.layer = cantDrawOverLayerIndex;
				currentLine.UsePhysics(true); // 끝나면 중력설정
				currentLine = null; 
			}
		}
		GameUI.instance.TouchUI.SetActive(false);
	}
}
