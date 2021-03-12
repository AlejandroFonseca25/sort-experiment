package model;

import java.io.BufferedWriter;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.Random;

public class Manager {
    private HashMap<Integer, Integer> lenghts;
    private Algorithms st;

    public Manager()
    {
        st = new Algorithms();
        lenghts = new HashMap<Integer, Integer>();
        lenghts.put(1, 100);
        lenghts.put(2, 1000);
        lenghts.put(3, 10000);       
        
    }

    public ArrayList<String>  MergeSortExperiment()
    {
        ArrayList<String> data = new ArrayList<String>();

        int language = 1;
        int algorithm = 2;

        for (int j = 1; j < 4; j++)// i is the arrayLeght
        {
            for (int k = 1; k < 4; k++) //k is the arrayState
            {
                int[] array = GenerateArray(j, k);

                for (int i = 0; i < 100; i++)
                {
                    long timeOne = System.currentTimeMillis();
                    st.MergeSort(array, 0, (array.length) - 1);
                    long timeTwo = System.currentTimeMillis();
                       
                    long timeElapsed = timeTwo - timeOne;

                    String info = algorithm + "," + language + "," + j + "," + k + "," + timeElapsed;
                    data.add(info);
                }
            }
        }

        return data;
    }

    public ArrayList<String>  BubbleSortExperiment()
    {
    	 ArrayList<String> data = new ArrayList<String>();

        int language = 1;
        int algorithm = 1;

        for (int j = 1; j < 4; j++)// i is the array Size (10^2, 10^3, 10^4)
        {
            for (int k = 1; k < 4; k++) //k is the array State(random,descendent,ascendent)
            {
                int[] array = GenerateArray(j, k);

                for (int i = 0; i < 100; i++)
                {
                    long timeOne = System.currentTimeMillis();
                    st.BubbleSort(array);
                    long timeTwo = System.currentTimeMillis();
       
                    
                    long timeElapsed = timeTwo - timeOne; 
                    
                    String info = algorithm + "," + language + "," + j + "," + k + "," + timeElapsed;
                    data.add(info);        
                }              
            }
        }

        return data;
    }

    public int[] GenerateArray(int lenght, int status){
        int size = lenghts.get(lenght);
        int[] array = new int[size];
        Random random = new Random();

        int max = Integer.MAX_VALUE;
        int min = 0;

        switch (status)
        {
            case 2:
                // orden descendiente
                for(int i = 0; i < size; i++)
                {
                    array[i] = size - i;
                }
                break;
            case 3:
                //orden ascendente;
                for (int i = 0; i < size; i++)
                {
                    array[i] = i + 1; 
                }
                break;
            default:
                //aleatorio
                for (int i = 0; i < size; i++)
                {
                    array[i] = (random.nextInt() * (min - max)) + min;
                }
                break;
        }
        
        return array;
    }

    public void WriteData(ArrayList<String> data){
    	try {
			BufferedWriter bw=new BufferedWriter(new FileWriter("data/Output.csv"));
			for(String n:data){
				bw.write(n+"\n");
			}
			bw.close();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
    	 	
    }
}
