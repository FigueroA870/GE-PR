using UnityEngine;
using UnityEngine.Events;

public class TriggerWithTagAndButton: MonoBehaviour
{
	public string tagToCheck = "Player";
	public UnityEvent onTriggerOnEvent;
	public UnityEvent onTriggerOffEvent;
	public bool playerIsInside = false;
	public bool triggered = false;
	public KeyCode triggerKey = KeyCode.R;

	private void Update()
	{
		if (playerIsInside && Input.GetKeyDown(triggerKey))
		{
			if (!triggered)
			{
				triggered = true;
				// You can do here things you want to trigger
				onTriggerOnEvent.Invoke();
			}
			else
			{ 
				triggered = false;
				// You can do here things you want to trigger
				onTriggerOffEvent.Invoke();
			}
		}
	}


	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag(tagToCheck))
		{
			playerIsInside = true;			
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag(tagToCheck))
		{
			Debug.Log($"{tagToCheck} left");
			playerIsInside = false;
		}
	}
}
