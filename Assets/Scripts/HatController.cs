using UnityEngine;
using System.Collections;
public class HatController : MonoBehaviour {
	//实例化的对象.
	public GameObject effect;
	private Vector3 rawPosition;
	private Vector3 hatPosition;
	private float maxWidth;
	// Use this for initialization
	void Start () {
		//将屏幕的宽度转换成世界坐标.
		Vector3 screenPos = new Vector3(Screen.width,0,0);
		Vector3 moveWidth=Camera.main.ScreenToWorldPoint(screenPos);
		//计算帽子的宽度.
		float hatWidth=GetComponent<Renderer>().bounds.extents.x;
		//获得帽子的初始位置.
		hatPosition=transform.position;
		//计算帽子的移动宽度.
		maxWidth=moveWidth.x-hatWidth;

	}

	// Update is called once per physics timestep
	void FixedUpdate () {
		//将鼠标的屏幕位置转换成世界坐标.
		rawPosition=Camera.main.ScreenToWorldPoint(Input.mousePosition);
		//设置帽子将要移动的位置,帽子移动范围控制.
		hatPosition= new Vector3(rawPosition.x,hatPosition.y,0);
		hatPosition.x=Mathf.Clamp(hatPosition.x,-maxWidth,maxWidth);
		//帽子移动.
		GetComponent<Rigidbody2D>().MovePosition(hatPosition);
	}
	//有碰撞体进入触发器时触发.
	void OnTriggerEnter2D(Collider2D col){
		GameObject neweffect=(GameObject)Instantiate(effect,transform.position,effect.transform.rotation);
		neweffect.transform.parent=transform;
		Destroy(col.gameObject);
		Destroy(neweffect,1.0f);

	}

}

