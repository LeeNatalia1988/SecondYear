package exam.view;

import exam.model.animal.Animal;
import exam.model.registry.RegistryItem;
import exam.presenter.Presenter;

import java.io.IOException;
import java.util.Scanner;

public class ConsoleUI implements View{
    private boolean work;
    private MainMenu menu;
    private Scanner scanner;
    private Presenter presenter;
    public ConsoleUI() {
        work = true;
        menu = new MainMenu(this);
        presenter = new Presenter(this);
        scanner = new Scanner(System.in);
    }

    @Override
    public void start() throws IOException, ClassNotFoundException {
        System.out.println("Привет! Я помогу тебе добавить животных в реестр!");
        while (work) {
            System.out.println(menu.menu());
            String choice = scanner.nextLine();
            int choiceInt = Integer.parseInt(choice);
            menu.execute(choiceInt);
        }
    }
    public void finish() {
        scanner.close();
        work = false;
    }
    public void sortByBirthday(){
        presenter.sortByBirthday();
    }
    public void addAnimal() {
        RegistryItem animal = presenter.createAnimal(scanner);
        presenter.addAnimal(animal);
    }
    public void setCommands(){
        System.out.println("Введите Id животного");
        String choice = scanner.nextLine();
        long choiceInt = Integer.parseInt(choice);
        System.out.println("Введите команды(у) через запятую");
        String cmd = scanner.nextLine();
        presenter.setCommands(choiceInt, cmd);
    }
    public String getCommands(){
        System.out.println("Введите Id животного");
        String choice = scanner.nextLine();
        long choiceInt = Integer.parseInt(choice);
        return presenter.getCommand(choiceInt);
    }
    public void getInfo(){
        presenter.getInfo();
    }
    @Override
    public void printAnswer(String answer) {
        System.out.println(answer);
    }
    public void save() throws IOException {
        presenter.save();
    }
    public void load() throws IOException, ClassNotFoundException {
        presenter.load();
    }
}
