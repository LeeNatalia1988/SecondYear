import java.util.ArrayList;
import java.util.Collection;
import java.util.HashMap;
import java.util.List;

public class PhoneBook {
    private HashMap<String, List<String>> contacts;
    public PhoneBook(){
        contacts = new HashMap<>();
    }
    public void setContacts(String name, String phoneNumber) {
        List<String> phoneNumbers = contacts.getOrDefault(name, new ArrayList<>());
        phoneNumbers.add(phoneNumber);
        phoneNumbers.sort(null);
        contacts.put(name, phoneNumbers);
    }
    public List<String> getPhoneNumbers(String name){
        return contacts.getOrDefault(name, new ArrayList<>());
    }
    public void printPhoneBook(){
        for(String name: contacts.keySet()){
            List<String> phoneNumbers = contacts.get(name);
            System.out.println(name + ": " + phoneNumbers);
        }
    }
}
