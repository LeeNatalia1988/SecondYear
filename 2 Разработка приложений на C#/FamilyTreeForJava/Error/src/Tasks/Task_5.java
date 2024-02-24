package Tasks;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Objects;

public class Task_5 {
    public Task_5() {
    }

    public static List<String[]> readFile(String path) {
        List<String[]> list = new ArrayList();

        try {
            BufferedReader br = new BufferedReader(new FileReader(path));
            String line = "";

            while((line = br.readLine()) != null) {
                String[] tmp = line.split("=");
                if (!Objects.equals(tmp[1], "?") && !isNumeric(tmp[1])) {
                    throw new RuntimeException("После равно не знак вопроса и не число: " + line);
                }

                list.add(tmp);
            }
        } catch (IOException var5) {
            System.out.println(var5.getMessage());
        }

        return list;
    }

    public static boolean isNumeric(String num) {
        try {
            Integer.parseInt(num);
            return true;
        } catch (Exception var2) {
            return false;
        }
    }

    public static void main(String[] args) {
        String path = "D:\\Java\\Geekbrains\\Error\\First\\Seminar\\src\\Tasks\\name.txt";
        String path1 = "D:\\Java\\Geekbrains\\Error\\First\\Seminar\\src\\Tasks\\name1.txt";
        List<String[]> list = readFile(path);
        changeData(list);
        writeFile(list, path1);
    }

    public static void changeData(List<String[]> array) {
        Iterator var1 = array.iterator();

        String[] item;
        while(var1.hasNext()) {
            item = (String[])var1.next();
            if (Objects.equals(item[1], "?")) {
                item[1] = Integer.toString(item[0].length());
            }
        }

        var1 = array.iterator();

        while(var1.hasNext()) {
            item = (String[])var1.next();
            System.out.println(item[0] + "->" + item[1]);
        }

    }

    public static void writeFile(List<String[]> array, String path) {
        try {
            BufferedWriter bw = new BufferedWriter(new FileWriter(path));
            Iterator var3 = array.iterator();

            while(var3.hasNext()) {
                String[] item = (String[])var3.next();
                bw.write(item[0] + "=" + item[1]);
                bw.newLine();
            }

            bw.close();
        } catch (IOException var5) {
            System.out.println(var5.getMessage());
        }

    }
}
