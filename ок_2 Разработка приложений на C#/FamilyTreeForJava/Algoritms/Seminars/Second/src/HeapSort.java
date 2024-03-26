public class HeapSort {
    public static void main(String[] args) {
        int[] array = {4, 10, 3, 5, 1};
        HeapSort heapSort = new HeapSort();
        printArray(array);
        heapSort.sort(array);
        printArray(array);
    }
    public static void printArray(int[] array){
        for (int i = 0; i < array.length; i++)
            System.out.print(array[i] + " ");
        System.out.println();
    }
    public void sort(int[] array) {
        // Построение кучи (перегруппируем массив),
        // самый большой элемент будет на 0-ой позиции
        for (int i = array.length / 2 - 1; i >= 0; i--)
            heapify(array, array.length, i);

        // Один за другим извлекаем элементы из кучи
        for (int i = array.length - 1; i >= 0; i--) {
            // Перемещаем текущий корень в конец
            int temp = array[0];
            array[0] = array[i];
            array[i] = temp;

            // Вызываем процедуру heapify на уменьшенной куче,
            // чтобы вынести снова самый большой элемент на 0-ую позицию
            heapify(array, i, 0);
        }
    }

    private static void heapify(int[] array, int heapSize, int rootIndex) {
        int largest = rootIndex; // инициализируем наибольший элемент как корень
        int leftChild = 2 * rootIndex + 1; //левый = 2 * rootIndex + 1
        int rightChild = 2 * rootIndex + 1; //правый = 2 * rootIndex + 2

        // Если левый дочерний элемент больше корня
        if (leftChild < heapSize && array[leftChild] > array[largest])
            largest = leftChild;

        // Если правый дочерний элемент больше, чем самый большой элемент на данный момент
        if (rightChild < heapSize && array[leftChild] > array[largest])
            largest = rightChild;
        // Если самый большой элемент не корень
        if (largest != rootIndex) {
            int temp = array[rootIndex];
            array[rootIndex] = array[largest];
            array[largest] = temp;

            // Рекурсивно преобразуем в двоичную кучу затронутое поддерево
            heapify(array, heapSize, largest);
        }
    }
}