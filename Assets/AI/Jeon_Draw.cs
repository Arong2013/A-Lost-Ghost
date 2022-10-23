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
            currentLine = Instantiate(linePrefab, this.transform).GetComponent<Line>();//������ ������ Cur�� ����

            currentLine.UsePhysics(false);//�׸��� �����Ҷ��� ���� ȿ��X
            currentLine.SetLineColor(lineColor);//���� ������ ������
            currentLine.SetPointsMinDistance(linePointsMinDistance);//��ġ ������ �ּ� ����
            currentLine.SetLineWidth(lineWidth);//�α� �ּ� �α�
        }
		else if(what == What.Remove)
        {
			Vector2 vector2 = Input.mousePosition;
			vector2 = cam.ScreenToWorldPoint(vector2);
			Collider2D hit = Physics2D.OverlapBox(vector2, new Vector2(2,2), 0,layer); 
			if (hit)
				Destroy(hit.transform.gameObject); // ���Ŷ�� �Ǿ� ������ ��ġ�Ѱ� �ݶ��̴� ã��
		}
		
	}
	public void Draw()
	{
		if (currentLine != null)
        {
			Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

			RaycastHit2D hit = Physics2D.CircleCast(mousePosition, lineWidth / 1f, Vector2.zero, 1f, cantDrawOverLayer);

			if (hit)
				EndDraw(); // ���࿡ �׸��� �ִ� ���� �÷��̾�� ������ ������ ���߱�
			else
				currentLine.AddPoint(mousePosition); // �׸���
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
				currentLine.UsePhysics(true); // ������ �߷¼���
				currentLine = null; 
			}
		}
		GameUI.instance.TouchUI.SetActive(false);
	}
}
