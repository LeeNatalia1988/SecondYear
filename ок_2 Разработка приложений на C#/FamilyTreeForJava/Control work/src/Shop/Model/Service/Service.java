package Shop.Model.Service;

import Shop.Model.Goods.Toy;
import Shop.Model.Shop.Shop;
import Shop.Model.Shop.ShopItem;
import Shop.Model.Writer.FileHandler;

import java.util.Scanner;

public class Service<E extends ShopItem> {

    private Shop<E> shop;
    private FileHandler<E> fileHandler;


    public Service() {
        this.shop = new Shop<>();
        this.fileHandler = new FileHandler<>();
    }

    public E getRandomGood() {
        return shop.getRandomGood();
    }

    public void addGood(Scanner scanner) {
        System.out.println("Введите тип игрушки");
        String name = scanner.nextLine();
        System.out.println("Введите шанс выпада игрушки в формате XX.XX");
        String rate = scanner.nextLine();
        shop.addGoods(new E(name), Double.parseDouble(rate));
    }

    public void writeFile(){
        fileHandler.writeFile(shop.getOutGoods());
    }

    public String getInfo(){
        StringBuilder sb = new StringBuilder();
        sb.append("В магазине ");
        sb.append(shop.getGoodsId());
        sb.append(" товаров: \n");

        for (E good: shop){
            sb.append(good);
            sb.append("\n");
        }
        return sb.toString();
    }
}
