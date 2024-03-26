import java.util.Scanner;

public class List {
    Node head;
    Node tail;
    public Node find(int value){
        Node currentNode = head;
        while (currentNode != null){
            if (currentNode.value == value){
                return currentNode;
            }
            currentNode = currentNode.next;
        }
        return null;
    }

    public void print(){
        Node currentNode = head;
        while (currentNode != null) {
            System.out.println(currentNode.value);
            currentNode = currentNode.next;
        }
    }

    public void add(int value){
        Node node = new Node();
        node.value = value;
        if (head == null){
            head = node;
            tail = node;
        } else {
            tail.next = node;
            node.previous = tail;
            tail = node;
        }
    }

    public void revert () {
        Node currentNode = head;
        while (currentNode != null){
            Node next = currentNode.next;
            Node previous = currentNode.previous;
            currentNode.previous = next;
            currentNode.next = previous;
            if (previous == null){
                tail = currentNode;
            }
            if (next == null) {
                head = currentNode;
            }
            currentNode = next;

        }
    }
    public class Node {
        int value;
        Node next;
        Node previous;
    }
}
