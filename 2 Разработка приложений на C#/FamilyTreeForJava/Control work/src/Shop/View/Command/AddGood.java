package Shop.View.Command;

import Shop.View.ConsoleUI;

public class AddGood extends Command{

    public AddGood(ConsoleUI consoleUI) {
        super("Добавить товар в магазин", consoleUI);
    }

    @Override
    public void execute() {
        super.getConsoleUI().addGood();
    }
}
