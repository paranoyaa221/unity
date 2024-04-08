using UnityEngine;

public class MoveObjectOnRandomNumber : MonoBehaviour
{
    public Transform objectToMove;

    // Список точек, к которым нужно перемещать объект
    public Transform[] movePoints;

    void Start()
    {
        StartCoroutine(MoveOnRandomNumber());
    }

    System.Collections.IEnumerator MoveOnRandomNumber()
    {
        while (true)
        {
            // Генерировать случайное число от 1 до 10
            int randomNumber = Random.Range(1, 11);

            // Если число равно 5, переместить объект к одной из точек
            if (randomNumber == 5)
            {
                // Выбрать случайную точку из списка
                int randomIndex = Random.Range(0, movePoints.Length);
                Transform destination = movePoints[randomIndex];

                // Переместить объект к выбранной точке
                objectToMove.position = destination.position;

                yield return new WaitForSeconds(1f); // 1 секунда
            }

            yield return null;
        }
    }
}
