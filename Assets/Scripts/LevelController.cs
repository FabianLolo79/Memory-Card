using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{

    [SerializeField] private CardController _cardPrefab;

    private List<CardController> _cards = new List<CardController>();

    [SerializeField] private int _columns = 4;
    [SerializeField] private int _rows = 4;
    [SerializeField] private int _difficulty = 4;

    // Start is called before the first frame update
    void Start()
    {
        StarLevel();
    }

    public void StarLevel()
    {
        if (_difficulty > _cardPrefab.maxCardTypes)
        {
            Debug.Assert(false);
            _difficulty = Math.Min(_difficulty, _cardPrefab.maxCardTypes);
        }
        Debug.Assert((_rows * _columns) % 2 == 0);

        _cards.ForEach(c => Destroy(c.gameObject));
        _cards.Clear();

        List<int> allTypes = new List<int>();
        for (int i = 0; i < _cardPrefab.maxCardTypes; i++)
        {
            allTypes.Add(i);
        }

        List<int> gameTypes = new List<int>();
        for (int i = 0; i < _difficulty; i++)
        {
            int chooseType = allTypes[UnityEngine.Random.Range(0, allTypes.Count)];
            allTypes.Remove(chooseType);
            gameTypes.Add(chooseType);
        }
        
        List<int> chosenTypes = new List<int>();
        for (int i = 0; i < (_rows * _columns) / 2; i++)
        {
            int chooseType = gameTypes[UnityEngine.Random.Range(0, allTypes.Count)];
            chosenTypes.Add(chooseType);
            chosenTypes.Add(chooseType);
        }

        Vector3 offSet = new Vector3((_columns - 1) * _cardPrefab._cardSize, (_rows - 1) * _cardPrefab._cardSize, 0f) * 0.5f;

        for (int y = 0; y < _rows; y++)
        {
            for (int x = 0; x < _columns; x++)
            {
                Vector3 position = new Vector3(x * _cardPrefab._cardSize, y * _cardPrefab._cardSize, 0f);
                var card = Instantiate(_cardPrefab, position - offSet, Quaternion.identity);
                card.cardType = chosenTypes[UnityEngine.Random.Range(0, chosenTypes.Count)];
                chosenTypes.Remove(card.cardType);
                card.OnClicked.AddListener(OnCardClicked);
                _cards.Add(card);
            }
        } 
    }

    private void OnCardClicked(CardController card)
    {
        card.TestAnimation();
    }
}
