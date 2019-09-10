using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
	//carPrefabを入れる
	public GameObject carPrefab;
	//coinPrefabを入れる
	public GameObject coinPrefab;
	//cornPrefabを入れる
	public GameObject conePrefab;
	//スタート地点
	private int startPos = -160;
	//ゴール地点
	private int goalPos = 120;
	//アイテムを出すx方向の範囲
	private float posRange = 3.4f;
	//Maincameraのオブジェクト
	private GameObject MainCamera;
	//Unityちゃんのオブジェクト
	public GameObject unitychan;
	//フラグ管理
	bool pos;
	//unityちゃんの座標を入れておく変数
	Vector3 unitypos = new Vector3(1.0f, 2.0f, 3.0f);

	void Start()
	{
		//unityちゃんの初期座標を代入
		unitypos = unitychan.transform.position;
		pos = false;
		//アイテムを生成する
		ItemAdd();
	}


	// Update is called once per frame(1フレームごとに呼び出す)
	void Update()
	{

		//unityちゃんの座標をチェックし、アイテムを生成
		if (Checkpos() == true)
		{
			ItemAdd();

		}
		else
		{

		}

	}

	//unityちゃんの座標をチェック
	public bool Checkpos()
	{
		if (unitypos.z <= unitychan.transform.position.z - 15)
		{
			unitypos = unitychan.transform.position;
			pos = true;
			return pos;
		}
		else
		{
			pos = false;
			return pos;
		}
	}

	void ItemAdd()
	{
		if (unitypos.z <= goalPos-40)
		{
			//どのアイテムを出すのかをランダムに設定
			int num = Random.Range(1, 10);
			if (num <= 1)
			{
				//コーンをx軸方向に一直線に生成
				for (float j = -1; j <= 1; j += 0.4f)
				{
					GameObject cone = Instantiate(conePrefab) as GameObject;
					cone.transform.position = new Vector3(4 * j, cone.transform.position.y, unitypos.z + 40);
				}
			}
			else
			{

				//レーンごとにアイテムを生成
				for (int j = -1; j < 2; j++)
				{
					//アイテムの種類を決める
					int item = Random.Range(1, 11);
					//アイテムを置くZ座標のオフセットをランダムに設定
					int offsetZ = Random.Range(-5, 6);
					//60%コイン配置:30%車配置:10%何もなし
					if (1 <= item && item <= 6)
					{
						//コインを生成
						GameObject coin = Instantiate(coinPrefab) as GameObject;
						coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, unitypos.z + offsetZ + 40);
					}
					else if (7 <= item && item <= 9)
					{
						//車を生成
						GameObject car = Instantiate(carPrefab) as GameObject;
						car.transform.position = new Vector3(posRange * j, car.transform.position.y, unitypos.z + offsetZ + 40);
					}
				}
			}
		}
		else
		{
			
		}
	}
}