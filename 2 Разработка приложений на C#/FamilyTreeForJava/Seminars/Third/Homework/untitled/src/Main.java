import java.util.ArrayList;
import java.util.List;
import java.util.Random;

public class Main {
    public static void main(String[] args) {
        List<Integer> randomNumbers = generateRandomNumberList(10, 0, 11);
        printNumbers(randomNumbers);
//        List<Integer> evenNumbers = getEven(randomNumbers);
//        printNumbers(randomNumbers);
        getMinNumbers(randomNumbers);
        getMaxNumbers(randomNumbers);
        calculateAverage(randomNumbers);
    }

    public static List<Integer> generateRandomNumberList(int size, int min, int max){
        List<Integer> randomNumberList = new ArrayList<>();
        Random random = new Random();

        for (int i = 0; i < size; i++) {
            int randomNumber = random.nextInt(min, max);
            randomNumberList.add(randomNumber);
        }
        return randomNumberList;
    }
    public static List<Integer> getEven(List<Integer> numbers){
        for (int i = numbers.size() - 1; i >= 0; i--) {
            if (numbers.get(i) % 2 == 0)
                numbers.remove(i);
        }
        return numbers;
    }
    public static void printNumbers(List<Integer> numbers){
        for (int x: numbers){
            System.out.print(x + " ");
        }
        System.out.println();
    }
    public static void getMinNumbers(List<Integer> numbers){
        Integer min = numbers.get(0);
        for (int i = 1; i < numbers.size(); i++) {
            if (numbers.get(i) < min)
                min = numbers.get(i);
        }
        System.out.println(min);;
    }
    public static void getMaxNumbers(List<Integer> numbers){
        Integer max = numbers.get(0);
        for (int i = 1; i < numbers.size(); i++) {
            if (numbers.get(i) > max)
                max = numbers.get(i);
        }
        System.out.println(max);;
    }
    public static void calculateAverage(List<Integer> numbers){
        int average = 0;
        for (int x: numbers)
            average += x;
        double value = (double) average /numbers.size();
        System.out.println(value);
    }
}
