package ui;	
import java.util.ArrayList;

import model.*;

public class Main {
	
	public static void main (String[] args) {
		Manager manager = new Manager();
		ArrayList<String> mList = manager.MergeSortExperiment();
		ArrayList<String> bList = manager.BubbleSortExperiment();
		mList.addAll(bList);
		manager.WriteData(mList);		
	}
}
