package exam.view.command;

import exam.view.ConsoleUI;

public class AddAnimal extends Command{
    public AddAnimal(ConsoleUI consoleUI) {
        super("Добавить животное", consoleUI);
    }

    @Override
    public void execute() {
        super.getConsoleUI().addAnimal();
    }
}
