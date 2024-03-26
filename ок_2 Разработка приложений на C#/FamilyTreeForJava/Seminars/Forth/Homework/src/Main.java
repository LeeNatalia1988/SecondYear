public class Main {
    public static void main(String[] args) {
        List linkedList = new List();

        linkedList.add(1);
        linkedList.add(2);
        linkedList.add(3);
        linkedList.add(4);

        linkedList.print();
        linkedList.revert();
        linkedList.print();
    }
}
