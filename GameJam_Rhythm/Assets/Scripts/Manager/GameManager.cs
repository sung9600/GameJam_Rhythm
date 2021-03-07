using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;


public class GameManager : MonoBehaviour
{
    public List<float> _InstantiateTimes;
    public List<float> _InstantiateTimes2;
    Animator animator;
    bool _doingPushUp; // true 시 pushup, false 시 squat
    public int currenthp = 6;
    public float _timeOffset = 2.5f;
    public float _StartTime;
    public int[] _NoteTotal;

    public GameObject transfer;

    public float _gameLength;
    public List<GameObject> Notes;
    public int[] idx;

    public GameObject[] _SpawnPos;
    public AudioSource _music;
    PoolManager _pool = new PoolManager();
    ResourceManager _resource = new ResourceManager();
    public static PoolManager Pool { get { return Instance._pool; } }
    public static ResourceManager Resource { get { return Instance._resource; } }
    public static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            return instance;
        }
    }
    private void Awake()
    {
        float _whichAnim = Random.Range(0f, 1f);
        transfer = GameObject.Find("ScoreTransfer");
        animator = GameObject.Find("Player").GetComponent<Animator>();
        if (_whichAnim < 0.5f)
        {
            animator.Play("Push_Up");
            _doingPushUp = true;
        }
        else
        {
            animator.Play("Squat");
            _doingPushUp = false;
        }
        _music = gameObject.GetComponent<AudioSource>();
        _gameLength = _music.clip.length;
        _SpawnPos = new GameObject[2];
        _SpawnPos[0] = GameObject.Find("NotePos");
        _SpawnPos[1] = GameObject.Find("NotePos2");
        if (instance == null)
        {
            instance = this;
        }
        ReadCsv("Notes.csv", _InstantiateTimes);
        ReadCsv("Notes2.csv", _InstantiateTimes2);
        _NoteTotal = new int[2];
        idx = new int[2];
        idx[0] = idx[1] = 0;
        _NoteTotal[0] = _InstantiateTimes.Count;
        _NoteTotal[1] = _InstantiateTimes2.Count;
        // foreach(float a in _perfectTimes){
        //     Debug.Log(a);
        // }
        StartCoroutine("SpawnNotes");
        StartCoroutine("SpawnNotes2");
    }
    private void Start()
    {
        _StartTime = Time.time;
        _music.Play();
        _music.loop = false;
        StartCoroutine("CheckEnd");
    }
    IEnumerator CheckEnd()
    {
        yield return null;
        while (true)
        {

            if (Time.time >= _StartTime + _gameLength)
            {
                ToEndScene(true);
            }
            yield return new WaitForEndOfFrame();
        }
    }

    IEnumerator SpawnNotes()
    {
        yield return null;
        while (true)
        {
            if (idx[0] == _NoteTotal[0])
                yield break;
            if (Time.time - _StartTime >= _InstantiateTimes[idx[0]] && idx[0] < _NoteTotal[0])
            {
                GameObject note = Instance._resource.Instantiate("Note", _SpawnPos[0].transform);

                Notes.Add(note);
                note.name = $"note{idx[0]}";
                idx[0]++;
            }
            yield return new WaitForEndOfFrame();
        }
    }
    IEnumerator SpawnNotes2()
    {
        yield return null;
        while (true)
        {
            if (idx[1] == _NoteTotal[1])
                yield break;
            if (Time.time - _StartTime >= _InstantiateTimes2[idx[1]] && idx[1] < _NoteTotal[1])
            {
                GameObject note = Instance._resource.Instantiate("Note", _SpawnPos[1].transform);

                Notes.Add(note);
                note.name = $"note2{idx[1]}";
                idx[1]++;
            }
            yield return new WaitForEndOfFrame();
        }
    }

    void ReadCsv(string filename, List<float> target)
    {
        StreamReader sr = new StreamReader($"{Application.dataPath}/Resources/csv/{filename}");
        bool _isEOF = false;
        while (!_isEOF)
        {
            string data = sr.ReadLine();
            if (data == null)
            {
                _isEOF = true;
                break;
            }
            var data_values = data.Split(',');
            target.Add(float.Parse(data_values[0]) - _timeOffset);
        }
        sr.Close();
    }

    public int[] sum = { 0, 0, 0 };// perfect good bad 순 카운팅
    public int _Score = 0;
    public int _combo = 0;
    public void Score()
    {
        if (_combo == 2)
        {
            currenthp = Mathf.Min(currenthp + 1, 6);
            InGameUI.changehp(currenthp);
        }
        _Score += _combo < 3 ? _combo++ : 3;
        //Debug.Log(_Score);
        // 여기에 스코어ui 바꾸는거 + 체력 
        InGameUI.getscore(_Score);
    }
    public void Perfect()
    {
        sum[0]++;
    }
    public void Good()
    {
        sum[1]++;
    }
    public void Bad()
    {
        _combo = 0;
        if (_doingPushUp)
        {
            animator.Play("Push_Up_Fail");
        }
        else
        {
            animator.Play("Squat_Fail");
        }
        currenthp--;
        if (currenthp <= 0)
        {
            ToEndScene(false);
        }
        InGameUI.changehp(currenthp);
        sum[2]++;
    }

    public void ToEndScene(bool success)
    {
        SceneManager.LoadScene(2);
        transfer.GetComponent<ScoreTransfer>().sum = sum;
        transfer.GetComponent<ScoreTransfer>().score = _Score;
        transfer.GetComponent<ScoreTransfer>().success = success;
    }
}
