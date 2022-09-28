using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // Lista com os componentes das letras do teclado
    public List<Button> keyboardCharacterButtons = new List<Button>();

    // Todos os caracteres do teclado, da fileira de cima para a de baixo
    private string characterNames = "QWERTYUIOPASDFGHJKLZXCVBNM";

    // Referencia ao gameController
    public GameController gameController;

    // Start is called before the first frame update
    void Start()
    {
        SetupButtons();
    }

    void SetupButtons()
    {
        // De cima para baixo, atribui o texto da lista ao texto das teclas
        for (int i = 0; i < keyboardCharacterButtons.Count; i++)
        {
            // Usamos o GetChild e depois o GetComponent, nao eficiente do pomnto de vista da performace.
            // Evite usar dentro do Update()

            keyboardCharacterButtons[i].transform.GetChild(0).GetComponent<Text>().text = characterNames[i].ToString();
        }

        // Ao se clicar em um botao, roda a nossa funcao ClickCharacter e joga o caractere como output pro Console.
        foreach (var keyboardButton in keyboardCharacterButtons)
        {
            string letter = keyboardButton.transform.GetChild(0).GetComponent<Text>().text;
            keyboardButton.GetComponent<Button>().onClick.AddListener(() => ClickCharacter(letter));
        }
    }

    void ClickCharacter(string letter)
    {

        Debug.Log(letter);

        gameController.AddLetterToWordBox(letter);

    }

    public Image GetKeyboardImage(string letter)
    {
        // Letras no teclado estão em letras maiusculas, isso garante que as que submetidas e checadas estejam iguais
        letter = letter.ToUpper();

        // Go through every key and return the one with the correct letter
        foreach (var keyboardLetter in keyboardCharacterButtons)
        {
            if (keyboardLetter.transform.GetChild(0).GetComponent<Text>().text == letter)
            {
                return keyboardLetter.transform.GetComponent<Image>();
            }
        }
        Debug.Log("This letter does not exist on this keyboard.");
        
        return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}