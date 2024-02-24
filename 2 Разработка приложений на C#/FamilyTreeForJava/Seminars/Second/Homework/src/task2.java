import java.io.FileWriter;
import java.io.IOException;

public class task2 {
    public static void main(String[] args) {
        int[] array = {5, 2, 8, 12, 1};

        try {
            FileWriter logFile = new FileWriter("sort_log.txt");
            logFile.write("Исходный массив: " + arrayToString(array) + "\n");

            boolean sorted = false;
            int n = array.length;

            while (!sorted) {
                sorted = true;

                for (int i = 0; i < n - 1; i++) {
                    if (array[i] > array[i + 1]) {
                        int temp = array[i];
                        array[i] = array[i + 1];
                        array[i + 1] = temp;
                        sorted = false;
                    }
                }

                logFile.write("Промежуточный результат: " + arrayToString(array) + "\n");
            }

            logFile.write("Отсортированный массив: " + arrayToString(array) + "\n");
            logFile.close();
            System.out.println("Сортировка завершена. Результаты записаны в лог-файл.");
        } catch (IOException e) {
            System.out.println("Ошибка при записи в лог-файл: " + e.getMessage());
        }
    }

    private static String arrayToString(int[] array) {
        StringBuilder sb = new StringBuilder();
        sb.append("[");
        for (int i = 0; i < array.length; i++) {
            sb.append(array[i]);
            if (i < array.length - 1) {
                sb.append(", ");
            }
        }
        sb.append("]");
        return sb.toString();
    }
}
