using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swiping : MonoBehaviour
{
	public static bool SwipeLeft, SwipeRight, SwipeUp, SwipeDown, tap;
	private Vector2 StartTouch, SwipeDelta;
	private bool Draging = false;

	private void Update()
	{
		tap = SwipeLeft = SwipeRight = SwipeUp = SwipeDown = false;
		#region Standalone Inputs
		if (Input.GetMouseButtonDown(0))
		{
			tap = true;
			Draging = true;
			StartTouch = Input.mousePosition;
		}
		if (Input.GetMouseButtonUp(0))
		{
			Draging = false;
			Reset();
		}

		#endregion
		#region Mobile Inputs

		if (Input.touches.Length > 0)

		{
			if (Input.touches[0].phase == TouchPhase.Began)
			{
				tap = true;
				Draging = true;
				StartTouch = Input.touches[0].position;
			}
			else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
			{
				Draging = false;
				Reset();
			}
		}
		#endregion

		SwipeDelta = Vector2.zero;
		if (Draging)
		{
			if (Input.touches.Length < 0)
			{
				SwipeDelta = Input.touches[0].position - StartTouch;
			}
			else if (Input.GetMouseButton(0))
			{
				SwipeDelta = (Vector2)Input.mousePosition - StartTouch;
			}
		}

		if (SwipeDelta.magnitude > 100)
		{
			float x = SwipeDelta.x;
			float y = SwipeDelta.y;
			if (Mathf.Abs(x) > Mathf.Abs(y))
			{
				if (x > 0) //horizontal
				{
					SwipeRight = true;
				}
				else
				{
					SwipeLeft = true;
				}
			}
			else
			{
				if (y > 0)  //vertical
				{
					SwipeUp = true;
				}
				else
				{
					SwipeDown = true;
				}
			}
			Reset();

		}
	}

	private void Reset()
	{
		StartTouch = SwipeDelta = Vector2.zero;
		Draging = false;
	}
}

