package Tasks;
/*
Напишите метод, на вход которого подаётся двумерный строковый массив размером 4х4.
При подаче массива другого размера необходимо бросить исключение MyArraySizeException.
Далее метод должен пройтись по всем элементам массива, преобразовать в int и просуммировать.
Если в каком-то элементе массива преобразование не удалось
(например, в ячейке лежит символ или текст вместо числа),
должно быть брошено исключение MyArrayDataException с детализацией,
в какой именно ячейке лежат неверные данные.
В методе main() вызвать полученный метод,
обработать возможные исключения MyArraySizeException и MyArrayDataException и вывести результат расчета
(сумму элементов, при условии что подали на вход корректный массив).
*/

class Main {
    public static void main(String[] args)  {
        main4();
    }
    public static void main4() {
        String[][] array = {{"1", "2", "3", "4"},
                {"1", "2", "3", "4"},
                {"1", "2", "3", "4"},
                {"1", "2", "3", "4"}};


        String[][] array1 = {{"1", "2", "3", "4"},
                {"1", "2", "3", "4"},
                {"1", "2", "3", "4"},
                {"1", "2", "3", "4"},
                {"1", "2", "3", "4"}};

        String[][] array2 = {{"1", "2", "3", "4"},
                {"1", "2", "3", "4"},
                {"1", "2", "3", "4"},
                {"1", "2", "ihhi", "4"}};
        System.out.println(Task_14.checkArray(array));
        try {
            System.out.println(Task_14.checkArray(array1));
        }catch (MyArrayDataException | MyArraySizeException e){
            System.out.println(e.getMessage());
        }
        try {
            System.out.println(Task_14.checkArray(array2));
        }catch (MyArrayDataException | MyArraySizeException e){
            System.out.println(e.getMessage());
        }
    }
}

public class Task_14 {
    public static int checkArray(String[][] array){
        if(array.length != 4 || array[0].length !=4 ) throw new MyArraySizeException(array.length, array[0].length);
        int sum = 0;
        for (String[] arr:array) {
            for (String i:arr) {
                try {
                    sum += Integer.parseInt(i);
                }catch (NumberFormatException e){
                    throw new MyArrayDataException();
                }

            }
        }
        return sum;
    }
}
class MyArraySizeException extends RuntimeException{
    public MyArraySizeException(int row, int colum) {
        super("Массив должен быть 4х4,размеры вашего массив -> " + row + "x" + colum );
    }

    public MyArraySizeException() {
        super("Массив должен быть 4х4");
    }
}
class MyArrayDataException extends NumberFormatException{
    public MyArrayDataException() {
        super("В каком-то элементе массива преобразование не удалось");
    }

    public MyArrayDataException(int i, int j) {
        super("Преобразование не удалось, индексы ->" + i + ":" + j);
    }
}