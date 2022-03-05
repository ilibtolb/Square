using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Drag : MonoBehaviour
{
    private bool click;
    public Camera cam;
    private Vector2 startPos;
    public Text circleCount;
    public Canvas UIGame;
    public Canvas endGame;
    private bool game = true;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.gameObject.SetActive(false);
        circleCount.text = (int.Parse(circleCount.text) + 1).ToString();
    }

    private void Update()
    {
        if (click)
        {
            Vector3 mouseScreen = Input.mousePosition;
            Vector2 mouseGame = new Vector2(cam.ScreenToWorldPoint(mouseScreen).x, cam.ScreenToWorldPoint(mouseScreen).y);

            this.transform.localPosition = mouseGame - startPos;
        }

        if(int.Parse(circleCount.text) == 5)
        {
            game = false;
            UIGame.gameObject.SetActive(false);
            endGame.gameObject.SetActive(true);
            this.gameObject.SetActive(false);
        }

    }

    private void OnMouseDown()
    {
        if (game)
        {
            if (Input.GetMouseButton(0))
            {
                Vector3 mouseScreen = Input.mousePosition;
                Vector2 mouseGame = new Vector2(cam.ScreenToWorldPoint(mouseScreen).x, cam.ScreenToWorldPoint(mouseScreen).y);

                startPos = mouseGame - new Vector2(this.transform.localPosition.x, this.transform.localPosition.y);

                click = true;
            }
        }
    }

    private void OnMouseUp()
    {
        click = false;
    }

}
