using UnityEngine;
using System.Collections;

[System.Serializable]
public class itemScript{

	public string itemName;
	public int itemID;
	public string itemDesc;
	public Texture2D itemIcon;
	public int itemPower;
	public int itemSpeed;
	public ItemType itemType;

	public enum ItemType{
		Agua,
		Eletrico,
		Vento
	}

	public itemScript(string name, int id, string desc, int power, int speed, ItemType type )
	{
		itemName = name;
		itemID = id;
		itemDesc = desc;
		itemIcon = Resources.Load<Texture2D> ("icones inventario/" + name); 
		itemPower = power;
		itemSpeed = speed;
		itemType = type;
	}

	public itemScript(){
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
