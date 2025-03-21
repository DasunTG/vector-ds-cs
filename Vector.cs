using System;
using System.Collections.Generic;
using System.Text;

namespace Vector
{
    public class Vector<T>
    {
        // This constant determines the default number of elements in a newly created vector.
        // It is also used to extended the capacity of the existing vector
        private const int DEFAULT_CAPACITY = 10;

        // This array represents the internal data structure wrapped by the vector class.
        // In fact, all the elements are to be stored in this private  array. 
        // You will just write extra functionality (methods) to make the work with the array more convenient for the user.
        private T[] data;

        // This property represents the number of elements in the vector
        public int Count { get; private set; } = 0;

        // This property represents the maximum number of elements (capacity) in the vector
        public int Capacity
        {
            get { return data.Length; }
        }

        // This is an overloaded constructor
        public Vector(int capacity)
        {
            data = new T[capacity];
        }

        // This is the implementation of the default constructor
        public Vector() : this(DEFAULT_CAPACITY) { }

        // An Indexer is a special type of property that allows a class or structure to be accessed the same way as array for its internal collection. 
        // For example, introducing the following indexer you may address an element of the vector as vector[i] or vector[0] or ...
        public T this[int index]
        {
            get
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                return data[index];
            }
            set
            {
                if (index >= Count || index < 0) throw new IndexOutOfRangeException();
                data[index] = value;
            }
        }

        // This private method allows extension of the existing capacity of the vector by another 'extraCapacity' elements.
        // The new capacity is equal to the existing one plus 'extraCapacity'.
        // It copies the elements of 'data' (the existing array) to 'newData' (the new array), and then makes data pointing to 'newData'.
        private void ExtendData(int extraCapacity)
        {
            T[] newData = new T[Capacity + extraCapacity];
            for (int i = 0; i < Count; i++) newData[i] = data[i];
            data = newData;
        }

        // This method adds a new element to the existing array.
        // If the internal array is out of capacity, its capacity is first extended to fit the new element.
        public void Add(T element)
        {
            if (Count == Capacity)
            {
                // First this checks whether the capacity is zero, if it is, it will set the capacity to 1
                // Otherwise, it will double the capacity
                resize(Capacity == 0 ? 1 : Capacity * 2);
            }


            // Add the new element to the end of the array    
            data[Count] = element;

            // Increment the count
            Count++;
        }

        // This method searches for the specified object and returns the zero‐based index of the first occurrence within the entire data structure.
        // This method performs a linear search; therefore, this method is an O(n) runtime complexity operation.
        // If occurrence is not found, then the method returns –1.
        // Note that Equals is the proper method to compare two objects for equality, you must not use operator '=' for this purpose.
        public int IndexOf(T element)
        {
            for (var i = 0; i < Count; i++)
            {
                // Check if the element is equal to the current element
                if (data[i].Equals(element)) return i;
            }

            // If the element is not found, return -1
            return -1;
        }

        // TODO: Your task is to implement all the remaining methods.
        // Read the instruction carefully, study the code examples from above as they should help you to write the rest of the code.
        public void Insert(int index, T element)
        {
            if (index < 0 || index > Count) throw new IndexOutOfRangeException("Index must be between 0 and Count inclusive");

            // Ensure capacity doubles only when necessary
            if (Count == Capacity)
            {
                // Double the capacity
                // If the count is 0, set the capacity to 1
                // Otherwise, double the capacity
                T[] newData = new T[Capacity * 2]; // Double the capacity
108             for (int i = 0; i < Count; i++)
109                 newData[i] = data[i];
110
111             data = newData;    
            }

            // Shift elements to the right
            for (int i = Count; i > index; i--)
            {
                data[i] = data[i - 1];
            }

            // Insert the new element
            data[index] = element;

            // Increment the count
            Count++;
        }

        private void resize(int newCapacity)
        {
            // Ensure that we are only doubling the capacity and not applying other values
            if (newCapacity <= Capacity) return; 

            // Create a new array with the new capacity (doubled capacity)
            T[] newData = new T[newCapacity];

            // Copy existing elements
            for (int i = 0; i < Count; i++)
            {
                newData[i] = data[i];
            }

            // Update the data array to point to the new array
            data = newData;
        }

        public void Clear()  
        {   
            // Set the count to 0
            // So this simply clears the logical view of the array
            Count=0; 
            for(int i =0;i<data.Length;i++)
152         data[i]=default;
            
        }

        public bool Contains(T element)
        {
            // This uses the IndexOf method to check if the element is in the array
            // If the element is in the array, the IndexOf method will return the index of the element
            if(IndexOf(element) != -1)return true;

            return false;

        }

        public bool Remove(T element)
        {
            // This method removes the first occurrence of the element in the array
           int index= IndexOf(element);

           // If the element is not in the array, return false
           if(index== -1) return false;

            // Remove the element at the index
           RemoveAt(index);
           return true;
        }


        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            throw new IndexOutOfRangeException("index is out of range");

            // Shift elements to the left
            for(int i=index; i<Count-1; i++) data[i]=data[i+1];

            // Decrement the count
            Count--;
        }

        public override string ToString()
        {
            // You should replace this plug by your code.
            string result = "";

            // Loop through the elements in the array and append them to the result string
            result = result + "[";
            for(int i = 0 ; i < Count; i++){
                result = result + data[i];
            }
            result = result + "]";
            return result;
            
            
        }

    }
}
