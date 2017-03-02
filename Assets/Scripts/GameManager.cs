using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
	public void Start(){
		PlayerPrefs.SetInt ("lastScene", SceneManager.GetActiveScene ().buildIndex);
	}

	public void Update(){
		if (Input.GetKeyDown(KeyCode.Escape)){
			
			//TO-DO PAUSE SCENE and pause menu

			}
		}

	public void StartGame(){
		LoadScene("Tutorial");
}
	public void QuitGame(){
		//If we are running in a standalone build of the game
		#if UNITY_STANDALONE
		//Quit the application
		Application.Quit();
		#endif

		//If we are running in the editor
		#if UNITY_EDITOR
		//Stop playing the scene
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
	}
	public void RetryGame(){
//		Debug.Log("last scene " + PlayerPrefs.GetString("last"));
//		Debug.Log ("Scene name: " + SceneManager.GetActiveScene ().name);
		SceneManager.LoadScene (PlayerPrefs.GetString ("last"));
	}
	public void BackToMenu(){
		SceneManager.LoadScene ("Start");
	}
	public void LoadScene(string name){
		PlayerPrefs.SetInt ("lastScene", SceneManager.GetActiveScene ().buildIndex + 1);
		PlayerPrefs.SetString ("last", SceneManager.GetActiveScene ().name);
//		Debug.Log("last scene " + PlayerPrefs.GetString("last"));
//		Debug.Log ("Scene name: " + SceneManager.GetActiveScene ().name);
		SceneManager.LoadScene (name);
	}
	public void LoadScene(int levelIndex){
		PlayerPrefs.SetInt ("lastScene", SceneManager.GetActiveScene ().buildIndex + 1);
		PlayerPrefs.SetString ("last", SceneManager.GetActiveScene ().name);
		SceneManager.LoadScene (levelIndex);
	}
	public void OnDisable(){
		PlayerPrefs.SetInt ("lastScene", SceneManager.GetActiveScene ().buildIndex);
		//Debug.Log ("current scene" + PlayerPrefs.GetInt ("LastScene"));
	}
	public void LoadNextLevel(){
		//To-DO load next build Index
		LoadScene (PlayerPrefs.GetInt("lastScene")+1);
	}
}
