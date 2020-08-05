using UnityEngine;
using UnityEngine.UI;

public class Cobra : MonoBehaviour {

	enum Direction{
		UP,DOWN,LEFT,RIGHT
	}
	Direction direction;
	public Fila tail;
	int point;
	public GameObject[] Head;
	Vector2 posToMove;
	[SerializeField] Vector2 horizontalRange;
	[SerializeField] Vector2 verticalRange;
	[SerializeField] float frameRate = 0.2f;
	[SerializeField] GameObject Food;
	[SerializeField] GameObject tailPrefab;
	[SerializeField] Text points;
	public bool ate;
	public bool hitWall;
	void Start () {
		Dado sentinel = new Dado(Head[0]);
		tail = new Fila(sentinel);
		Vector2 pos = Head[0].transform.position;
		pos.x+=0.16f;
		GameObject pos1 = Instantiate(tailPrefab,pos,Quaternion.identity);
		Dado auxiliary1 = new Dado(pos1);
		pos.x+=0.16f;
		GameObject pos2 = Instantiate(tailPrefab,pos,Quaternion.identity);
		Dado auxiliary2 = new Dado(pos2);	
		tail.Enqueue(auxiliary1);
		tail.Enqueue(auxiliary2);
		InvokeRepeating("Move",frameRate,frameRate);
	}
	void Update () {
		if(Input.GetKeyDown(KeyCode.UpArrow))
			direction = Direction.UP;
		else if(Input.GetKeyDown(KeyCode.DownArrow))
			direction = Direction.DOWN;
		else if(Input.GetKeyDown(KeyCode.LeftArrow))
			direction = Direction.LEFT;
		else if(Input.GetKeyDown(KeyCode.RightArrow))
			direction = Direction.RIGHT;
		
		IncreaseSpeed(frameRate,point);
		points.text = "HIGHSCORE : " + point.ToString();
		
	}

	void Move(){
		Vector3 position = Vector3.zero;
		if(direction==Direction.UP){
			Dado bodyToMove = tail.Dequeue();
			bodyToMove.pixel.transform.position = tail.last.dado.pixel.transform.position + Vector3.up * 0.16f;
			tail.Enqueue(bodyToMove);
		}
		else if(direction==Direction.DOWN){
			Dado bodyToMove = tail.Dequeue();
			bodyToMove.pixel.transform.position = tail.last.dado.pixel.transform.position + Vector3.down * 0.16f;
			tail.Enqueue(bodyToMove);
		}
		else if(direction==Direction.LEFT){
			Dado bodyToMove = tail.Dequeue();
			bodyToMove.pixel.transform.position = tail.last.dado.pixel.transform.position + Vector3.left * 0.16f;
			tail.Enqueue(bodyToMove);
		}
		else if(direction==Direction.RIGHT){
			Dado bodyToMove = tail.Dequeue();
			bodyToMove.pixel.transform.position = tail.last.dado.pixel.transform.position + Vector3.right * 0.16f;
			tail.Enqueue(bodyToMove);
		}	
	}
	public void Death(bool _dead){
		if(_dead){
			Debug.Log("Matar o Player");
			UnityEngine.SceneManagement.SceneManager.LoadScene(0);
			hitWall = false;
		}
		
		
	}
	public void Ate(bool ate){
			if(ate){
			InstantiatatingFood();
			RespawnFood(Food);
			IncreasePoints();
			ate = false;
			}
		}
		public void InstantiatatingFood(){
		Dado foodToAdd = new Dado((Instantiate(tailPrefab,tail.last.dado.pixel.transform.position, Quaternion.identity)));
			tail.Enqueue(foodToAdd);
			Debug.Log("ADICIONOU A LISTA RABO");
	}

	public void RespawnFood(GameObject _food){
		_food.transform.position = new Vector2(Random.Range(horizontalRange.x,horizontalRange.y), Random.Range(verticalRange.x,verticalRange.y));
	}
	public void IncreaseSpeed(float _speed,int _points){
		if(_points>3)
			_speed = 0.15f;
		else if (_points>8)
			_speed = 0.12f;
		else if (_points>8)
			_speed = 0.1f;
		else if (_points>8)
			_speed = 0.01f;
		else
			_speed = 0.2f;

		
	}

	public void ResetGame(){
		UnityEngine.SceneManagement.SceneManager.LoadScene(0);
	}

	public void IncreasePoints(){
		point +=10;
		points.text = point.ToString();
	}

}
