using System;
using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR    
public class CardImporterer : EditorWindow
{
    private string longString = "Paste your cards here";
    [MenuItem("Caotic Witches/Card Importer")]
    public static void ShowWindow()
    {
        GetWindow<CardImporterer>("Card Importer");
    }

    private void OnGUI()
    {
        GUILayout.Label("Import Cards", EditorStyles.boldLabel);

        // place to paste  text
        longString = GUILayout.TextArea(longString, GUILayout.Width(400), GUILayout.Height(100));

        // button to import
        if (GUILayout.Button("Import"))
        {
            ImportCards();
        }
    }

    private void ImportCards()
    {
        // create a CardList object
        // parse the text
        // add the cards to the CardList
        // save the CardList to a file
        // display a message to the user
        // that the cards were imported and ammoount of cards imported
        // save the scriptable object to Decks folder


        CardList cardList = new CardList();

        // get the text from the text area


        // split the text into , separated lines
        string[] cards = longString.Split(",");

        // for each card in the cards array
        foreach (string card in cards)
        {
            Debug.Log(card);
            // create a new card
            Card newCard = new Card(card);

            if (newCard != null)
            {
                cardList.AddCard(newCard);
            }
        }

        // save the card list to a file

        if (cards.Length == 0)
        {
            Debug.LogError("No cards were imported");

            foreach (Card card in cardList.cards)
            {
                Debug.Log(card.name);
            }

            return;
        }

        string DeckName = DateTime.Now.ToString("yyyyMMddHHmmss");
        string path = "Assets/_ChaoticWitches/Decks/" + DeckName + ".asset";

        AssetDatabase.CreateAsset(cardList, path);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }
}

#endif