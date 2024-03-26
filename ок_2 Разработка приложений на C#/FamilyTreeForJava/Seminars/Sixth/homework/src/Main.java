import java.util.HashMap;

public class Main {
    public static void main(String[] args) {
        PhoneBook phoneBook = new PhoneBook();
        phoneBook.setContacts("Иван", "9218234641");
        phoneBook.setContacts("Настя", "9218234633");
        phoneBook.setContacts("Дмитрий", "9218234443");
        phoneBook.setContacts("Дмитрий", "9218234445");
        phoneBook.setContacts("Дмитрий", "9218234441");
        phoneBook.printPhoneBook();
    }
}