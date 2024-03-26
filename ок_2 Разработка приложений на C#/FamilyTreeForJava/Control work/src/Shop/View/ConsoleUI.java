package Shop.View;

import Shop.Presenter.Presenter;

import java.util.Scanner;

public class ConsoleUI implements View{
    private Presenter presenter;
    private Scanner scanner;
    private MainMenu menu;
    private boolean work;

    public ConsoleUI() {
        this.work = true;
        this.menu = new MainMenu(this);
        this.presenter = new Presenter(this);
        this.scanner = new Scanner(System.in);
    }

    @Override
    public void start() {
        System.out.println("Удача лежит за сильнейшими");
        while (work) {
            System.out.println(menu.menu());
            String choice = scanner.nextLine();
            try {
                int choiceInt = Integer.parseInt(choice);
                menu.execute(choiceInt);
            } catch (NumberFormatException ex) {
                System.out.println("Пожалуйста, введите целое число");
            } catch (IndexOutOfBoundsException ex) {
                System.out.println("Пожалуйста, введите число от 1 до 4");
            }


        }
    }
    public void finish(){
        scanner.close();
        work = false;
    }
    public void writeFile(){
        presenter.writeFile();
    }
    public void addGood() {
        presenter.addGood(scanner);
    }

    public void getRandomGood(){
        String result = presenter.getRandomGood().toString();
        printAnswer("Вы выиграли: " + result);
    }
    @Override
    public void printAnswer(String answer) {
        System.out.println(answer);
    }
}
