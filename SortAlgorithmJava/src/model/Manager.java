package model;

import java.lang.management.ManagementFactory;
import java.lang.management.MemoryMXBean;
import java.lang.management.MemoryUsage;
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

    public void MergeSortExperiment()
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
                    Runtime runtime = Runtime.getRuntime();
                    long usedMemoryBefore = runtime.totalMemory() - runtime.freeMemory();
                    st.MergeSort(array, 0, (array.length) - 1);
                    long usedMemoryAfter = runtime.totalMemory() - runtime.freeMemory();
                    long timeTwo = System.currentTimeMillis();
                    long consumed = usedMemoryAfter-usedMemoryBefore;
                    System.out.println("Total consumed Memory:" + consumed);
                    
                    long timeElapsed = timeTwo - timeOne;

                    String info = algorithm + "," + language + "," + j + "," + k + "," + timeElapsed;
                    data.add(info);
                    System.out.println("info " + info);
                }
            }
        }

        WriteData(data);
    }

    public void BubbleSortExperiment()
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
                    Runtime runtime = Runtime.getRuntime();
                    long usedMemoryBefore = runtime.totalMemory() - runtime.freeMemory();
                    st.BubbleSort(array);
                    long usedMemoryAfter = runtime.totalMemory() - runtime.freeMemory();
                    long timeTwo = System.currentTimeMillis();
                    
       
                    long consumed = usedMemoryAfter-usedMemoryBefore;
                    System.out.println("Total consumed Memory:" + consumed);
                    
                    long timeElapsed = timeTwo - timeOne; 
                    
                    String info = algorithm + "," + language + "," + j + "," + k + "," + timeElapsed;
                    data.add(info);
                    System.out.println("info " + info);                 
                }              
            }
        }

        WriteData(data);
    }

    public int[] GenerateArray(int lenght, int status){
        int size = lenghts.size();
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
    	
    }
}
