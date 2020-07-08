using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]

public class SceneLoader : MonoBehaviour
{
    [SerializeField]
    AudioSource _AudioPlayer;
    [Range(0,1)]
    public 	float Volume = .3f;
    // public GameObject AudioPlayer;
    public 	string _FadeDebug;
    // public Object _Scene;
    public 	string SceneName;
    public 	float Factor = 5;
    public 	Texture2D FadeTexture;
    		float Distance2Point;
    		float fade = 1;

	public Camera GameCamera;
	public void SetGameCamera(Camera cam)
	{
		GameCamera = cam;
	}

	// Use this for initialization
    void OnEnable()
    {
        _AudioPlayer = FindObjectOfType<AudioSource>();
        // _AudioPlayer = AudioPlayer.GetComponent<AudioSource>();
        fade = 1;
        SetupOverlayEffect();
        //  if(_Scene)
        //  SceneName = _Scene.name;
    }

	Fade FadeEffect;
    void SetupOverlayEffect()
    {
		if (GameCamera)
        {
			FadeEffect = GameCamera.GetComponent<Fade>();
            if (FadeEffect == null)
            {
				FadeEffect = GameCamera.gameObject.AddComponent<Fade>();
                FadeEffect._Color.a = 0;
            }
        }
    }

    void Fade()
    {
        if (FadeEffect)
        {
            fade = Mathf.Lerp(fade, 0, .1f);
            FadeEffect._Color.a = Mathf.Clamp01(2 * fade);
            if (_AudioPlayer)
                _AudioPlayer.volume = (1 - fade) * Volume;
        }
        else
        {
            SetupOverlayEffect();
            //Debug.LogError("Overlay effect not set");
        }
    }

    public float TriggerDistance = 1;
    void Update()
    {
		if (/*Camera.current*/GameCamera)
        {
			Distance2Point = Vector3.Distance(this.transform.position, GameCamera.transform.position) * Factor;
            Distance2Point = 1 - Mathf.Clamp01(Distance2Point);
            _FadeDebug = Distance2Point.ToString();
            fade += Distance2Point;
        }

        if (Application.isPlaying && Distance2Point > TriggerDistance || Input.GetKeyDown(KeyCode.Q))
        {
            SceneManager.LoadScene(SceneName, LoadSceneMode.Single);
        }

        if(Application.isPlaying)
	        Fade();
    }
}
