using UnityEngine;

public class Fila{

    public int Count = 0;
    public Element first,last;
    /// <summary>
    /// Constructor da fila 
    /// </summary>
    /// <param name="_dado">
    /// Elemento que irá compor o Sentinela
    /// </param>
     public Fila(Dado _dado){
        Element sentinel = new Element(_dado);        
        first = sentinel;
        last = sentinel;
    }

    /// <summary>
    /// Adicionar algum dado a fila já existente
    /// 
    /// </summary>
    /// <param name="_dado">
    /// Dado que está sendo adicionado a fila
    /// </param>
    public void Enqueue(Dado _dado){
        Element newElemen = new Element(_dado);
        last.next = newElemen;
        last = newElemen;
        newElemen.next = null;  
        Count++;    
    }

    public Dado Dequeue(){
        if(Empty()){            
            Debug.LogWarning("Fila está vazia");
            return null;
        }
        else{
            Element removeAux = first;
            first = removeAux.next;
            removeAux.next = null;
            if(removeAux == last)
                last = first;
            return removeAux.dado;
        }
    }

    public void Print(){
        for (int i = 0; i < Count; i++){
            if(Empty()){
                Debug.LogWarning("Fila estava vazia.");
                break;
            }
            else{    
                Element aux = first.next;
                aux = aux.next;
                if (aux.next == null)
                    break;
            }
        }
    }

    /// <summary>
    /// Checka se a fila está vazia e retorna o valor desta checkagem
    /// </summary>
    /// <returns>
    /// Valor da checkagem da fila true or false
    /// </returns>
    public bool Empty(){
        if(first==last){
            Debug.LogWarning("Lista esta vazia");
            return true;
        }
        else
            return false;
    }
}