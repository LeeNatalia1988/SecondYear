package Tasks.Task_15.Service;

import Tasks.Task_15.Exceptions.DataException;
import Tasks.Task_15.Exceptions.GenderException;
import Tasks.Task_15.Exceptions.MyParseException;
import Tasks.Task_15.Exceptions.TypeException;

import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Date;
import java.util.Objects;
import java.util.Scanner;

import static Tasks.Task_15.Handler.FileHandler.readCheckData;
import static Tasks.Task_15.Handler.FileHandler.writeData;


public class UserData {

    public UserData() {
        initializeComponent();
    }

    public void initializeComponent(){
        String input = scanner();
        if (checkInputLength(input)) {
            String[] data = checkInput(input);
            String formatData = formatData(data);
            if (readCheckData(data[0], formatData)) {
                writeData(formatData, data[0]);
            }
        }
    }
    public String formatData(String[] array) {
        StringBuilder sb = new StringBuilder();
        for (String s : array) {
            sb.append("<").append(s).append(">");
        }
        return sb.toString();
    }
    public String scanner() {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Введите через пробел: Фамилия Имя Отчество Дата рождения Номер телефона Пол");
        return scanner.nextLine();
    }
    public boolean checkInputLength(String data) {
        String[] array = data.split(" ");
        try {
            if (array.length != 6) {
                throw new DataException(array.length);
            }
        } catch (DataException ex) {
            System.err.println(ex.getMessage());
            return false;
        }
        return true;
    }
    public String[] checkInput(String data) {
        String[] array = data.split(" ");
        try {
            for (int i = 0; i < 2; i++)
                validateLetterOnly(array[i]);
        } catch (TypeException ex) {
            System.err.println(ex.getMessage());
        }
        try {
            SimpleDateFormat dateFormat = new SimpleDateFormat("dd.MM.yyyy");
            dateFormat.setLenient(false);
            Date parsedDate = dateFormat.parse(array[3]);
        } catch (ParseException e) {
            try {
                throw new MyParseException("Дата рождения должна быть в формате dd.MM.yyyy: " + array[3]);
            } catch (MyParseException ex){
                System.err.println(ex.getMessage());
            }
        }
        try {
            Long.parseLong(array[4]);
        } catch (Exception e) {
            try {
                throw new MyParseException("Неверный тип данных номера телефона: " + array[4]);
            } catch (MyParseException ex){
                System.err.println(ex.getMessage());
            }
        }
        try {
            if (!Objects.equals(array[5], "f") && !Objects.equals(array[5], "m")) {
                throw new GenderException(array[5]);
            }
        } catch (GenderException ex) {
            System.err.println(ex.getMessage());
        }
        return array;
    }
    public void validateLetterOnly(String data) {
        char[] charArray = data.toCharArray();
        for (char c: charArray) {
            if (!Character.isLetter(c)) {
                throw new TypeException(data);
            }
        }
    }
}
