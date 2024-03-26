package Shop.Model.Goods;

import Shop.Model.Shop.ShopItem;

import java.io.Serializable;

public class Toy implements ShopItem, Serializable {
    private String name;
    private long id;


    public Toy(String name) {
        this.name = name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public void setId(long goodId) {
        this.id = goodId;
    }

    @Override
    public long getId() {
        return this.id;
    }

    @Override
    public String toString() {
        return name;
    }
}
