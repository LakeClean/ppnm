
public class genlist<T>{
	public T[] data; // Creating array with the name data
	public int size => data.Length; // defining the size keyword
	public T this[int i] => data[i]; // using this keyword to declare indexers
	public genlist(){data = new T[0];} 

	public void add(T item){
		T[] newdata = new T[size+1]; // create new list +1 length
		System.Array.Copy(data,newdata,size); //copy old list to new
		newdata[size]=item;// item is added to the new list
		data=newdata; // old list is overwritten and garbage collected later. Though it is unknown when.
	}//add

	public void remove(int i){
		T[] newdata = new T[size-1];
		for(int j=0; j<size;j++){
			if(i != j){
				newdata[j] = data[i];
			}
		}
		data = newdata;
	}//remove


}//genlist
