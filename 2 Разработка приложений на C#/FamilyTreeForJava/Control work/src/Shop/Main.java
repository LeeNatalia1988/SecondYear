package Shop;

import Shop.View.ConsoleUI;
import Shop.View.View;

public class Main {
    public static void main(String[] args) {
        View view = new ConsoleUI();
        view.start();
    }
}
