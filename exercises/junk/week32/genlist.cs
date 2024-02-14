public class genlist<T>{

public T[] data;
public T this[int i] => data[i];
public genlist(){data = new T[0];}
public int size => data.Length;


public void add (T item) {
    T[] newdata = new T[data.Length+1];
    for(int i=0; i<data.Length;i+=1)newdata[i]=data[i];
    newdata[data.Length]=item;
    data=newdata; 
    }

}

