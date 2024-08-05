using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine;
using UnityEngine.Events;

public class CardController : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabs;

    public int maxCardTypes => _prefabs.Count;
    public float _cardSize = 2f;
    public int cardType = -1;
    public UnityEvent<CardController> OnClicked;

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        if(cardType < 0)
        {
            cardType = UnityEngine.Random.Range(0, _prefabs.Count);
        }

        Instantiate(_prefabs[cardType], transform.position, quaternion.identity, transform);
    }

    //Dispara el evento del click del mouse
    private void OnMouseUpAsButton()
    {
        OnClicked.Invoke(this);
    }

    public void TestAnimation()
    {
        IEnumerator AnimationCoroutine()
        {
            Reveal();
            yield return new WaitForSeconds(2);
            Hide();
        }

        StartCoroutine(AnimationCoroutine());
    }

    // controla la animación para revelar la carta
    public void Reveal()
    {
        _animator.SetBool("revealed", true);
    }
    
    //controla la animación para esconder la carta
    public void Hide()
    {
        _animator.SetBool("revealed", false);
    }
}
