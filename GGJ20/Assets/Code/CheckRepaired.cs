using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckRepaired : MonoBehaviour {

	public GameObject crossout;
	public Sprite repaired;
	private SpriteRenderer spriteRenderer;

	[SerializeField]
	AudioSource audio = null;
    
	// Start is called before the first frame update
	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public void Repair() {
		spriteRenderer.sprite = repaired;
		if(crossout != null)
		{
			crossout.SetActive(true);
		}
		if(audio != null)
		{
			audio.Stop();
		}
	}
	
}