package Tasks;

import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.IOException;

public class Task_11 {
    public static void main(String[] args) {
        try {
            doSomething();
        } catch (IOException e) {
            System.out.println(e.getMessage());
        }
    }

    public static void doSomething() throws IOException {
        try (FileReader fileReader = new FileReader("Text")) {
            System.out.println("Read");
        };
    }
}
