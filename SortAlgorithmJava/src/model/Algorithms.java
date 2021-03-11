package model;

public class Algorithms {

    public Algorithms() { }
    
    private void Merge(int[] list, int p, int q, int r)
    {
        int n1 = q - p + 1;
        int n2 = r - q;

        int[] left = new int[n1];
        int[] right = new int[n2];

        for (int z = 0; z < n1; z++)
        {
            left[z] = list[p + z];
        }

        for (int w = 0; w < n2; w++)
        {
            right[w] = list[q + w + 1];
        }

        int i = 0;
        int j = 0;
        int k = p;

        while (i < n1 && j < n2)
        {
            if (left[i] < right[j])
            {
                list[k] = left[i];
                i++;
            }
            else
            {
                list[k] = right[j];
                j++;
            }
            k++;
        }

        while (i < n1)
        {
            list[k] = left[i];
            i++;
            k++;
        }

        while (j < n2)
        {
            list[k] = right[j];
            j++;
            k++;
        }


    }

    public void MergeSort(int[] list, int p, int r)
    {
        if (p < r)
        {
            int q = (p + r) / 2;
            MergeSort(list, p, q);
            MergeSort(list, q + 1, r);
            Merge(list, p, q, r);
        }
    }

    public void BubbleSort(int[] list)
    {
        for (int i = 0; i < list.length - 1; i++)
        {
            for (int j = 0; j < list.length - i - 1; j++)
            {
                if (list[j] > list[j + 1])
                {
                    int temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
    }
}
