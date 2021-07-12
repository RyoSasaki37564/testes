using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//CameraのProjectionはOrthographicに。

public class DropsTouch : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
	Rigidbody2D m_rb = default;

	void Start()
	{
		m_rb = GetComponent<Rigidbody2D>();
	}

	void IBeginDragHandler.OnBeginDrag(PointerEventData eventData)
    {
		m_rb.isKinematic = true; //ドロップのリジッドボディに可動性を付与(挙動を安定させる)
    }

	public void OnDrag(PointerEventData data)
	{
		if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
		{
			if (GameManager.gameSetFlag)
			{
				if (GameManager.turnFlag)
				{
					Vector2 TargetPos = Camera.main.ScreenToWorldPoint(data.position);
					
					transform.position = TargetPos;
				}
			}
		}
	}

	void IEndDragHandler.OnEndDrag(PointerEventData eventData)
    {
		m_rb.isKinematic = false; //ドロップの可動性を除去
	}
}

//PointerEventData.positionでドラッグ中のPointer（タッチ位置、マウスカーソルの位置）のポジションを取得できるので、
//それをオブジェクトのtransform.positionに代入してます。ただし、PointerEventData.positionはスクリーン座標系なので、
//ワールド座標系のtransform.positionに代入するには同じワールド座標系に変換する必要があります。
//また、PointerEventData.positionはVector2なので、こちらで代入するZ位置を指定した方がいいです。
//じゃないと、思わぬ値が代入されるかもしれないです。本記事では0を代入してます。

//すでに2Dに変更済み。