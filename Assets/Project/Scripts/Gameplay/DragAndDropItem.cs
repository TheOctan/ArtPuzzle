using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace OctanGames
{
	[RequireComponent(typeof(RectTransform), typeof(CanvasGroup))]
	public class DragAndDropItem : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
	{
		[SerializeField] private Canvas _rootCanvas;
		[SerializeField] private int _id;

		private RectTransform _rectTransform;
		private CanvasGroup _canvasGroup;
		private Transform _defaultParent;

		private int _siblingIndex;

		public bool isDroped { get; set; }
		public int Id => _id;

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
			_canvasGroup = GetComponent<CanvasGroup>();

			_defaultParent = transform.parent;
			_siblingIndex = transform.GetSiblingIndex();
		}
		public void OnBeginDrag(PointerEventData eventData)
		{
			_rectTransform.SetParent(_rootCanvas.transform);
			_canvasGroup.blocksRaycasts = false;
		}

		public void OnDrag(PointerEventData eventData)
		{
			_rectTransform.anchoredPosition += eventData.delta / _rootCanvas.scaleFactor;
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			if (!isDroped)
			{
				ResetPosition();
			}
			_canvasGroup.blocksRaycasts = true;
		}

		public void ResetPosition()
		{
			_rectTransform.SetParent(_defaultParent);
			_rectTransform.SetSiblingIndex(_siblingIndex);
		}
	}
}
