package Shop.Model.Writer;

import java.io.*;
import java.util.List;

public class FileHandler<T> {
    public void writeFile(List<T> array) {
        try (BufferedWriter bw = new BufferedWriter(new FileWriter("shop.out"))){
            for (T item : array)
                bw.write(item.toString());
        } catch (IOException ex) {
            System.err.println(ex.getMessage());
        }
    }
}