import java.math.BigInteger;

public class Main {
    public static void main(String[] args) {

        Node n1 = new Node(5);
        Node n2 = new Node(2);
        Node n3 = new Node(3);
        Node n4 = new Node(9);
        Node n5 = new Node(7);

        n1.next = n2;
        n2.next = n3;
        n3.next = n4;
//        n5.next = n1;

        System.out.println(n1.value);
        System.out.println(n1.next.value);
        System.out.println(n1.next.next.value);
        System.out.println(n1.next.next.next.value);
//        System.out.println(n1.next.next.next.next.value);

//        Node currentNode = n1;
//        while (currentNode != null) {
//            System.out.println(currentNode.value + " ");
//            currentNode = currentNode.next;
//        }
//        int n = 5;
//        int [] array = new int[] {1, 2, 3, 4, 5, 6, 7, 5, 5, 5};
//        House my;
//        my = new House();
//        House their = new House();
//        my.street = "Komsomolskaya 14a";
//        my.floorCount = 3;
//        my.color = Color.White;
//        my.height = 10;
//
//
//
//        their.street = "null";
//        their.color = Color.Green;
//        their.floorCount = 1;
//        their.height = 4;
//
//        my.burn();
//        System.out.println(my.color);

//        System.out.println(find(array, n));
//        System.out.print(fibbonachiRec(5, 0 ,1));
    }


//    public static int fibbonachiRec(int n, int left, int right){
//        if (n==0)
//            return right;
//        return fibbonachiRec(n-1, right, left+right);
//    }
//    public static int fibbonachiLine(int n) {
//        int left = 0;
//        int right = 1;
//        if (n<3)
//            if (n==2)
//                return 1;
//            else if(n==1)
//                return 0;
//            else return -1;
//        for (int i = 0; i < n; i++) {
//            right = left + right;
//            left = right - left;
//        }
//        return right;
//    }
//    public static int find(int[] array, int value) {
//        for (int i = 0; i < array.length; i++)
//            if (array[i] == value)
//                return i;
//        return -1;
//        }

//    public static void bubbleSort(int[] array) {
//        boolean isSorted = false;
//        int length = array.length;
//        for (int k = 0; k < array.length - 1 && !isSorted; k++) {
//            isSorted = true;
//            for (int i = 0; i < length - 1; i++)
//                if (array[i] > array[i+1]) {
//                    int temp = array[i];
//                    array[i] = array[i + 1];
//                    array[i + 1] = temp;
//                    isSorted = false;
//                }
//            length--;
//        }
}