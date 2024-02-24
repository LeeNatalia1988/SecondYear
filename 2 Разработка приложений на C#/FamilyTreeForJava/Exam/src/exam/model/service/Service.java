package exam.model.service;

import exam.model.animal.Animal;
import exam.model.animal.AnimalComparatorByBirthday;
import exam.model.registry.Registry;
import exam.model.registry.RegistryItem;
import exam.model.writer.FileHandler;

import java.io.IOException;
import java.util.Scanner;

public class Service {

    private Registry registry;
    private FileHandler<Registry> fileHandler;

    public Service() {
        this.registry = new Registry();
        this.fileHandler = new FileHandler<Registry>();
    }
    public RegistryItem createAnimal(Scanner scanner){
        return registry.createAnimal(scanner);
    }
    public String addAnimal(RegistryItem animal){
        return registry.addAnimal(animal);
    }

    public String getInfo(){
        return registry.toString();
    }
    public void sortByBirthday(){
        registry.sortByBirthday();
    }
    public String getCommands(long Id){
        return registry.getCommands(Id);
    }

    public void setCommands(Long Id, String command) {
        registry.setCommands(Id, command);
    }
    public void save() throws IOException {
        fileHandler.save(registry);
    }
    public void load() throws IOException, ClassNotFoundException {
        registry = fileHandler.load();

    }
}
