using UnityEngine;

public class Element{

    public Dado dado;
    public Element next;
    
    public Element(Dado _dado){
        this.dado = _dado;
        next = null;
    }
}