package Shop.View.Command;

import Shop.View.ConsoleUI;

public class GetRandomGood extends Command{

    public GetRandomGood(ConsoleUI consoleUI) {
        super("Попробовать выиграть игрушку", consoleUI);
    }

    @Override
    public void execute() {
        super.getConsoleUI().getRandomGood();
    }
}
