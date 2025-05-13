using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaycastSelector : MonoBehaviour
{
    public TextMeshProUGUI hintText; //Текст на экране
    
    private Grabbable heldObject;
    void Update()
    {
        // Выполняем луч от камеры игрока
        Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        
        // Проверяем столкновение с объектами сцены
        bool isObjectHit = Physics.Raycast(ray, out hitInfo);
        
        // Если объект имеет компонент InteractableHelper, выводим имя объекта
        if (isObjectHit && hitInfo.transform.GetComponent<InteractableHelper>())
        {
            var helper = hitInfo.transform.GetComponent<InteractableHelper>();
            hintText.text = helper.objectName;

            // Взаимодействие по нажатию E
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Проверяем тип объекта
                if (hitInfo.transform.GetComponent<Grabbable>() != null)
                {
                    HandleGrabbable(hitInfo.transform.GetComponent<Grabbable>());
                }
                else if (hitInfo.transform.GetComponent<Socket>() != null)
                {
                    HandleSocket(hitInfo.transform.GetComponent<Socket>());
                }
                else if (hitInfo.transform.GetComponent<Interactable>() != null)
                {
                    hitInfo.transform.GetComponent<Interactable>().Interact();
                }
                else if (hitInfo.transform.GetComponent<Key>() != null)
                {
                    hitInfo.transform.GetComponent<Key>().Interact();
                }
            }
        }
        else
        {
            // Очищаем текст, если взгляд направлен мимо интерактивных объектов
            hintText.text = "";
        }
    }
    private void HandleGrabbable(Grabbable grabbable)
    {
        if (heldObject == null)
        {
            heldObject = grabbable;
            grabbable.Grab(transform);
        } else {
            heldObject.Drop();
            heldObject = null;
        }
    }
    
    private void HandleSocket(Socket socket)
    {
        if (heldObject != null)
        {
            socket.TryInsert(heldObject);
            heldObject = null;
        }
    }
}
