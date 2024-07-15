using UnityEngine;
using System;
using System.Diagnostics;
using TheaterOfKismet;
using UnityEditor.Experimental.GraphView;
using UnityEngine.UIElements;

public partial class MouseInput : Node{

	
	public string mouse_on_node_name,last_on_node_name;
	public Vector2 mouse_pos,mouse_v;
	public bool is_mouse_press,n_press,nn_press;
	public bool is_abled=true;

	public float time_until_last_press=0;

	private Vector2 last_mouse_pos;

	public static MouseInput instance;

	public MouseInput(){
		instance=this;
	}
	// Called when the node enters the scene tree for the first time.
	public void _Ready(){
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void _Process(double delta){
		if(is_abled){
			calc_mouse((float)delta);
			calc_mouse_on_node();
		}else{
			reset_mouse();
		}
	}

	public void _Input(InputEvent @event){
		// if(!is_abled)return;
		// if (@event is InputEventMouseButton eventMouseButton){
		// 	if (eventMouseButton.ButtonIndex == MouseButton.Left){
		// 		if(eventMouseButton.Pressed){
		// 			nn_press=true;
		// 			if(!check_ui_pressed()){
		// 				n_press=true;
		// 			}
		// 		}else{
		// 			nn_press=false;
		// 			n_press=false;
		// 		}
		// 		// if(eventMouseButton.Pressed&&(sprite.GetRect()).HasPoint(ToLocal(GetGlobalMousePosition()))){
		// 		// 	_dragging = true;
		// 		// }else{
		// 		// 	_dragging = false;
		// 		// }
		// 	}
		// }
	}
	public bool is_mouse_on_setting(){
		// Sprite2D bottom_b=//UI.get_ui().get_setting();
		// if(bottom_b.GetRect().HasPoint(bottom_b.ToLocal(mouse_pos))){
		// 	return true;
		// }
		// return false;

		return default;
	}

	bool check_ui_pressed(){
		// Sprite2D bottom_b=//UI.get_ui().get_setting();
		// if(bottom_b.GetRect().HasPoint(bottom_b.ToLocal(mouse_pos))){
		// 	CardEvent nevent=new CardEvent();
		// 	nevent.event_type=CardEvent.Type.Settings;
		// 	this.GetSystem<GameStateSystem>().add_card_event(nevent);
		// 	Debug.Log("Settings");
		// 	return true;
		// }
		return false;
	}

	private void calc_mouse(float delta){
		// mouse_pos=GetViewport().GetMousePosition();
		// mouse_v=(mouse_pos-last_mouse_pos)/delta;
		// last_mouse_pos=mouse_pos;
		//
		// is_mouse_press=n_press;
		// if(is_mouse_press){
		// 	time_until_last_press=0;
		// }else{
		// 	time_until_last_press+=delta;
		// }
	}

	private void calc_mouse_on_node(){
		if(is_mouse_press)return;
		mouse_on_node_name="";

		// foreach(Node node in Main.get_main().GetChildren()){
		// 	if(node is CardMove card){
		// 		
		// 		if(card.can_drag==1&&card.GetRect().HasPoint(card.ToLocal(mouse_pos))){
		// 			if(Main.get_main().GetNodeOrNull(mouse_on_node_name) is null){
		// 				mouse_on_node_name=card.Name;
		// 			}else if((Main.get_main().GetNode(mouse_on_node_name) as Sprite2D).ZIndex<card.ZIndex){
		// 				mouse_on_node_name=card.Name;
		// 			}
		// 		}
		// 	}
		// }

		if(is_mouse_press){
			last_on_node_name=mouse_on_node_name;
		}
	}

	void reset_mouse(){
		mouse_on_node_name="";
		last_on_node_name="";
		is_mouse_press=false;
		time_until_last_press=0;
		n_press=false;
	}

	public static MouseInput get_mouse_input(){
		return instance;
	}
}
