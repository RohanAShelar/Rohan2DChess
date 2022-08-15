using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject Controller;

    GameObject reference = null;

    int MatrixX;
    int MatrixY;

    public bool attack = false;

    public void Start()
    {
        if(attack)
        {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouceUp()
    {
        Controller = GameObject.FindGameObjectWithTag("GameController");

        if(attack)
        {
            GameObject cp = Controller.GetComponent<Game>().GetPosition(MatrixX, MatrixY);

            if (cp.name == "white_king")
                Controller.GetComponent<Game>().Winner("black");
            if (cp.name == "black_king")
                Controller.GetComponent<Game>().Winner("white");

            Destroy(cp);
        }

        Controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<ChessMan>().GetXBoard(), reference.GetComponent<ChessMan>().GetYBoard());

        reference.GetComponent<ChessMan>().SetXBoard(MatrixX);
        reference.GetComponent<ChessMan>().SetYBoard(MatrixY);
        reference.GetComponent<ChessMan>().SetCoords();

        Controller.GetComponent<Game>().SetPosition(reference);

        Controller.GetComponent<Game>().NextTurn();

        reference.GetComponent<ChessMan>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y)
    {
        MatrixX = x;
        MatrixY = y;
    }

    public void SetReference(GameObject obj)
    {
        reference = obj;
    }

    public GameObject GetReference()
    {
        return reference;
    }
}
