using UnityEngine;

public class DestroyByDelay : MonoBehaviour
{
	// Time in seconds before the GameObject is destroyed
	public float delayDuration = 5.0f;

	void Start()
	{
		// Destroy the GameObject after the specified delay
		Destroy(gameObject, delayDuration);
	}
}