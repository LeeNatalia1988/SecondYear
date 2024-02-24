package Shop.Presenter;

import Shop.Model.Service.Service;
import Shop.Model.Shop.ShopItem;
import Shop.View.View;

import java.util.Scanner;

public class Presenter {
    private Service service;
    private View view;

    public Presenter(View view) {
        this.view = view;
        this.service = new Service();
    }
    public void addGood(Scanner scanner){
        service.addGood(scanner);
    }

    public ShopItem getRandomGood(){
        return service.getRandomGood();
    }

    public void writeFile(){
        service.writeFile();
    }
}
