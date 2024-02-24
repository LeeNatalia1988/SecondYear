public class Task_2 {
    public Task_2() {
    }

    public static void main(String[] args) {
        int[] array = new int[]{1, 2, 3, 4};
        Message(CheckArray(array, 6, 3));
        Message(CheckArray(array, 3, 5));
        Message(CheckArray((int[])null, 4, 3));
        Message(CheckArray(array, 3, 3));
    }

    public static int CheckArray(int[] array, int n, int m) {
        if (array == null) {
            return -3;
        } else if (array.length < n) {
            return -1;
        } else {
            for(int i = 0; i < array.length; ++i) {
                if (array[i] == m) {
                    return i;
                }
            }

            return -2;
        }
    }

    public static void Message(int v) {
        if (v == -1) {
            System.out.println("Длина массива меньше заданного");
        } else if (v == -2) {
            System.out.println("Искомый элемент не найден");
        } else if (v == -3) {
            System.out.println("Вместо массива пришел null");
        } else if (v >= 0) {
            System.out.println("Искомый элемент находится в индексе " + v);
        }

    }
}
