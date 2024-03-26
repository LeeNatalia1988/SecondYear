package exam.model.animal;

import exam.model.registry.RegistryItem;

import java.io.Serializable;
import java.time.LocalDate;
import java.util.ArrayList;
import java.util.List;

public abstract class PackAnimal implements Animal, RegistryItem, Serializable {
    private String name;
    private LocalDate age;
    private long Id;
    private List<String> commands = new ArrayList<>();
    private LocalDate birthday;
    public String CargoTransfer(){
        return "Начал нести груз";
    }
    public String Journey(){
        return "Отправился в путешествие";
    }
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }
    public void setCommands(String command) {
        List<String> commandArray = List.of(command.split(", "));
        this.commands.addAll(commandArray);
    }

    public List<String> getCommands(long Id) {
        return commands;
    }

    public void setBirthday(LocalDate birthday) {
        this.birthday = birthday;
    }

    public LocalDate getBirthday() {
        return birthday;
    }

    public LocalDate getAge() {
        return age;
    }

    public long getId() {
        return Id;
    }

    public void setId(long id) {
        Id = id;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Id: " + this.Id + ", имя: " + getName() + ", дата рождения: " + getBirthday() + ", команды: " );
        String result = String.join(", ", commands);
        sb.append(result);
        return sb.toString();
    }
}
