package Shop.Model.Shop;

import java.io.Serializable;

public class DropRate<E> implements Serializable {
    private E toy;
    private double goodDropRate;

    public DropRate(E toy, double goodDropRate) {
        this.toy = toy;
        this.goodDropRate = goodDropRate;
    }

    public E getGood() {
        return toy;
    }
    public double changeDropRate(double num){
        goodDropRate = num;
        return goodDropRate;
    }

    public double getDropRate() {
        return goodDropRate;
    }
}
