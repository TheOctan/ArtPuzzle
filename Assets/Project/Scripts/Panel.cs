using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace OctanGames
{
	public class Panel : MonoBehaviour
	{
		[SerializeField] private List<DropSlot> _slots;
		[SerializeField] private UnityEvent _panelCompleted;

		private int _countCompletedSlots;

		private void Start()
		{
			if (_slots != null)
			{
				for (int i = 0; i < _slots.Count; i++)
				{
					_slots[i].ItemDropped += OnItemDrop;
				}
			}
		}

		public void OnItemDrop()
		{
			_countCompletedSlots++;

			if (_countCompletedSlots == _slots.Count)
			{
				_panelCompleted.Invoke();
			}
		}
	}
}
