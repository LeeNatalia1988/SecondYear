package Tasks;

public class Task_3 {
    public Task_3() {
    }

    public static void main(String[] args) {
        int[][] array = new int[][]{{1, 0, 0, 1}, {1, 0, 1, 0}, {1, 1, 0, 0}, {1, 1, 0, 1}};
        System.out.println(sumArray(array));
    }

    public static int sumArray(int[][] array) {
        int sum = 0;

        for(int i = 0; i < array.length; ++i) {
            if (array.length != array[i].length) {
                throw new RuntimeException("Массив не квадратный, " + array.length + "х" + array[i].length);
            }

            for(int j = 0; j < array.length; ++j) {
                if (array[i][j] != 0 && array[i][j] != 1) {
                    throw new RuntimeException("Значение в массиве не равно 0 или 1, индекс " + i + ":" + j);
                }

                sum += array[i][j];
            }
        }

        return sum;
    }
}
