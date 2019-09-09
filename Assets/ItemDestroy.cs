using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>

/// </summary>
public class ItemDestroy: MonoBehaviour
{
	//Maincameraのオブジェクト
	private GameObject MainCamera;


	void Start(){
	
	//maincameraのオブジェクトを取得
	this.MainCamera = GameObject.Find("Main Camera");
}

	void Update()
	{
		if(MainCamera.transform.position.z > this.transform.position.z)
		{
			Destroy(this.gameObject);
		}

	}

    
}