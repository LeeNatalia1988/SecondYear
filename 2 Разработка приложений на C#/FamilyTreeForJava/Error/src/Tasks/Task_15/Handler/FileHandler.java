package Tasks.Task_15.Handler;

import java.io.*;

public class FileHandler {
    public static void writeData(String data, String path) {
        try {
            File file = new File(path);
            FileWriter fileWriter = new FileWriter(file, true);
            BufferedWriter bw = new BufferedWriter(fileWriter);
            if (file.length() > 0)
                bw.newLine();
            // Записываем данные в файл
            bw.write(data);
            bw.close();
            System.out.println("Данные успешно добавлены в файл.");
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
    public static boolean readCheckData(String path, String data) {
        try {
            File file = new File(path);
            FileReader fileReader = new FileReader(file);
            BufferedReader bufferedReader = new BufferedReader(fileReader);

            String line;
            while ((line = bufferedReader.readLine()) != null) {
                if (line.equals(data)) {
                    System.out.println("Пользователь уже есть в списке");
                    return false;
                }
            }
            bufferedReader.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return true;
    }
}
