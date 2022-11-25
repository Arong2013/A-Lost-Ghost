using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
	public LineRenderer lineRenderer;
	public EdgeCollider2D edgeCollider;
	public Rigidbody2D rigidBody;

	[HideInInspector] public List<Vector2> points = new List<Vector2>();
	[HideInInspector] public int pointsCount = 0;

	float pointsMinDistance = 0.1f;

	float circleColliderRadius;

	public void AddPoint(Vector2 newPoint)
	{
		if (pointsCount >= 1 && Vector2.Distance(newPoint, GetLastPoint()) < pointsMinDistance) // 가만히 있으면 그냥 끝내라
			return;

		points.Add(newPoint); // 라인렌더러의 포인트에 백터 더해주라
		pointsCount++; // 포인트 추가
		GameUI.instance.SliderV -= 2; // 슬라이더 감소


		CircleCollider2D circleCollider = this.gameObject.AddComponent<CircleCollider2D>();
		circleCollider.offset = newPoint;
		circleCollider.radius = circleColliderRadius; // 콜라이더 설정

		lineRenderer.positionCount = pointsCount;
		lineRenderer.SetPosition(pointsCount - 1, newPoint); // 라인 렌더러 백터값으로 그리기


		if (pointsCount > 1)
			edgeCollider.points = points.ToArray(); // 엣지콜라이더 설정
	}

	public Vector2 GetLastPoint()
	{
		return (Vector2)lineRenderer.GetPosition(pointsCount - 1); // 터치를 할때 마지막터치 포지션 설정
	}

	public void UsePhysics(bool usePhysics)
	{
		rigidBody.isKinematic = !usePhysics; // 중력종류 바꾸어 주기
	}

	public void SetLineColor(Gradient colorGradient)
	{
		lineRenderer.colorGradient = colorGradient; // 색  설정 
	}

	public void SetPointsMinDistance(float distance)
	{
		pointsMinDistance = distance; // 최소 길이
	}

	public void SetLineWidth(float width)
	{
		lineRenderer.startWidth = width;
		lineRenderer.endWidth = width;

		circleColliderRadius = width / 2f;

		edgeCollider.edgeRadius = circleColliderRadius; // 최소 두깨 정해주고 엣지롤라이더 두깨 설정 
	}

}
