using UnityEngine;

public class Lista{
    public Element first,last;
    public int Count = 0;

    /// <summary>
    /// Constructor da Lista
    /// </summary>
    /// <param name="_dado">
    /// Elemento que será tratado como sentinela
    /// </param>
    public Lista(Dado _dado){
        Element sentinel = new Element(_dado);        
        first = sentinel;
        last = sentinel;
    }

    
    /// <summary>
    /// Método que adiciona um elemento a ultima posição da lista
    /// </summary>
    /// <param name="_dado">
    /// Elemento que estará sendo adicionado a Lista
    /// </param>

    public void Add(Dado _dado){
        Element newElem = new Element(_dado);
        last.next = newElem;
        last = newElem;last.next = null;
        Count++;
    }
    public Vector2 GetLastPosition(){
        Vector2 lastOnePosition = new Vector2(last.dado.pixel.transform.position.x+0.2f,last.dado.pixel.transform.position.y);
        return lastOnePosition;
    }
    public Vector2 TheFirstOneBeforeLast(){
        Element TheFirstOneBeforeTheLast = first;
        if(first == last){
            return Vector2.zero;
        }
        while(TheFirstOneBeforeTheLast == last){
            TheFirstOneBeforeTheLast = TheFirstOneBeforeTheLast.next;
        }
        return (Vector2)TheFirstOneBeforeTheLast.dado.pixel.transform.position;
        
    }

    public GameObject GetPositionIndex(int _index){
        if(_index == 0)
        {   return null;    }
        int i = 0;
        Element auxiliary = first.next;
        while(i !=_index){
            auxiliary = auxiliary.next;
            if(auxiliary.next == null){
                return null;
            }
        }
        return auxiliary.dado.pixel;
    }
}