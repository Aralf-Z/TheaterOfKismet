using UnityEngine;
using System;

public partial class Setting 
{
	
	public Texture2D light,dark;
	bool is_hovered;
	// Called when the node enters the scene tree for the first time.
	// public void _Ready(){
	// 	Texture = light;
	// }
	//
	// // Called every frame. 'delta' is the elapsed time since the previous frame.
	// public void _Process(double delta){
	// 	is_hovered=MouseInput.get_mouse_input().is_mouse_on_setting();
	// 	if(is_hovered){
	// 		if(MouseInput.get_mouse_input().nn_press){
	// 			Texture=dark;
	// 		}else{
	// 			Texture=light;
	// 		}
	// 		Rotate(0.01f);
	// 	}else{
	// 		Texture=light;
	// 	}
	// }
}
