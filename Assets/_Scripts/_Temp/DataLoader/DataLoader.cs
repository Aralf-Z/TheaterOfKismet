
using SimpleJSON;
using System.Collections.Generic;
using UnityEngine;


public class DataLoader :MonoBehaviour{
	public static cfg.Tables tables;
	// Called when the node enters the scene tree for the first time.
	public void _Ready()
	{
		// GD.Print("-----------------");
		// tables = new cfg.Tables(LoadJson);
		// GD.Print(tables.TbItem.DataList.FirstOrDefault()?.ToString());
		// GD.Print(tables.TbProbs.DataList.FirstOrDefault()?.ToString());
		// GD.Print("-----------------");
	}

	private static JSONNode LoadJson(string file)
	{
		// using var fileJson = string.Empty;//Godot.FileAccess.Open($"res://TableJson/{file}.json", Godot.FileAccess.ModeFlags.Read);
		// var content = fileJson.GetAsText();
		// return JSON.Parse(content);
		return default;
	}

	public static List<cfg.Item> get_card_data(){
		return tables.TbItem.DataList;
	}

	public static List<cfg.Probs> get_probs_data(){
		return tables.TbProbs.DataList;
	}
}
