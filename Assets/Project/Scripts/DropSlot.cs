using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace OctanGames
{
	[RequireComponent(typeof(RectTransform))]
	public class DropSlot : MonoBehaviour, IDropHandler
	{
		[SerializeField] private int _id;
		[SerializeField] private UnityEvent _itemDropped;

		private RectTransform _rectTransform;

		public event UnityAction ItemDropped
		{
			add => _itemDropped.AddListener(value);
			remove => _itemDropped.RemoveListener(value);
		}

		private void Awake()
		{
			_rectTransform = GetComponent<RectTransform>();
		}

		public void OnDrop(PointerEventData eventData)
		{
			if (eventData.pointerDrag != null)
			{
				var item = eventData.pointerDrag.GetComponent<DragAndDropItem>();

				if (item.Id == _id)
				{
					var rectTransform = eventData.pointerDrag.GetComponent<RectTransform>();
					AttachItem(rectTransform);
					item.isDroped = true;
					item.enabled = false;

					_itemDropped.Invoke();
				}
				else
				{
					item.ResetPosition();
				}
			}
		}

		private void AttachItem(RectTransform rectTransform)
		{
			rectTransform.SetParent(_rectTransform);
			rectTransform.anchoredPosition = Vector2.zero;
			rectTransform.anchorMin = Vector2.one / 2f;
			rectTransform.anchorMax = Vector2.one / 2f;
		}
	}
}
