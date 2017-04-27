using UnityEngine;
using System.Collections;

public class PlayerIcon : MonoBehaviour {

    private Transform playerIcon;

	// Use this for initialization
	void Start () {
        playerIcon = Minimap._instance.GetPlayerIcon();
	}
	
	// Update is called once per frame
	void Update () {
        float y = transform.eulerAngles.y;
        playerIcon.localEulerAngles = new Vector3(0, 0, -y);
	}
}
