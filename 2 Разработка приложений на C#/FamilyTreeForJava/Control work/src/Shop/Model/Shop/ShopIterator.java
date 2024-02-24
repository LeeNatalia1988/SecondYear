package Shop.Model.Shop;

import java.util.Iterator;
import java.util.List;

public class ShopIterator<E extends ShopItem> implements Iterator<E> {
    private int index;
    private List<E> rates;

    public ShopIterator(List<E> rates) {
        this.rates = rates;
    }

    @Override
    public boolean hasNext() {
        return rates.size() > index;
    }

    @Override
    public E next() {
        return rates.get(index++);
    }
}
