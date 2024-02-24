package Tasks;

public class Task_4 {
    public Task_4() {
    }

    public static void main(String[] args) {
        String[][] array1 = new String[][]{{"1", "32a", "3", "4", "5", "6"}, {"1", "2", "3", "4", "5", "6"}, {"1", "2", "3", "4", "5", "6"}};
        System.out.println(sum2d(array1));
    }

    public static int sum2d(String[][] arr) {
        int sum = 0;

        for(int i = 0; i < arr.length; ++i) {
            for(int j = 0; j < arr[i].length; ++j) {
                try {
                    int val = Integer.parseInt(arr[i][j]);
                    sum += val;
                } catch (NumberFormatException var5) {
                    System.out.println("Некорректные данные на индексе -> " + i + ":" + j + ", значение -> " + arr[i][j]);
                }
            }
        }

        return sum;
    }
}
