package exam.model.registry;

import exam.model.animal.Animal;
import exam.model.animal.AnimalComparatorByBirthday;
import exam.model.animal.PackAnimal;

import java.io.Serializable;
import java.time.LocalDate;
import java.time.format.DateTimeFormatter;
import java.util.*;
import java.util.function.Consumer;

public class Registry implements Iterable<RegistryItem>, Serializable {
    private long animalId;
    private String name;
    private ArrayList<RegistryItem> animals;

    public Registry() {
        this.animals = new ArrayList<>();
    }

    public RegistryItem getAnimalById(long id) {
        for (RegistryItem animal : animals) {
            if (animal.getId() == id) {
                return animal;
            }
        }
        return null;
    }

    public RegistryItem createAnimal(Scanner scanner) {
        System.out.println("Введите тип животного:");
        try {
        String animalType = scanner.nextLine();
        RegistryItem animal_item = AnimalFactory.getAnimal(animalType);
        System.out.println("Введите имя животного");
        String name = scanner.nextLine();
        System.out.println("Введите дату рождения животного в формате ДД_ММ_ГГ");
        DateTimeFormatter formatter = DateTimeFormatter.ofPattern("dd_MM_yyyy");
        LocalDate birthday = LocalDate.parse(scanner.nextLine(), formatter);
        System.out.println("Введите команды (если есть)");
        String command = scanner.nextLine();
        animal_item.setName(name);
        animal_item.setBirthday(birthday);
        animal_item.setCommands(command);
        return animal_item;
        } catch (Exception e) {
            e.printStackTrace();
        }
        return null;
    }
    public String addAnimal(RegistryItem animal) {
        if (!animals.contains(animal)) {
            animals.add(animal);
            animal.setId(animalId++);
        }
        return "Животное добавлено в реестр!";
    }
    public void setCommands(Long Id, String command) {
        RegistryItem animal = getAnimalById(Id);
        animal.setCommands(command);
    }
    public String getCommands(long Id) {
        RegistryItem animal = getAnimalById(Id);
        List<String> command = animal.getCommands(Id);
        return String.join(", ", command);
    }
    public void sortByBirthday(){
        animals.sort(new AnimalComparatorByBirthday());
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("В реестре ");
        sb.append(animals.size());
        sb.append(" объект(ов): \n");
        for (RegistryItem animal: animals) {
            sb.append(animal);
            sb.append("\n");
        }
        return sb.toString();
    }

    @Override
    public Iterator<RegistryItem> iterator() {
        return new RegistryIterator<>(animals);
    }
}
