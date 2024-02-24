package Shop.Model.Shop;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;
import java.util.Random;


public class Shop<E extends ShopItem> implements Iterable<E>, Serializable {
    private List<DropRate<E>> goodsDropRate;
    private List<E> goods;

    private List<E> outGoods;

    private Random random;

    public Shop() {
        this.goodsDropRate = new ArrayList<>();
        this.goods = new ArrayList<>();
        this.outGoods = new ArrayList<>();
        this.random = new Random();
    }

    private long goodsId;

    public long getGoodsId() {
        return goodsId;
    }

    public void createGood(String name){
        try {
            ShopItem item = ShopItemFactory.createShopItem(ShopItem.class, "Заяц");
            // Теперь у вас есть экземпляр ConcreteShopItem с именем "Заяц"
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
    public void addGoods(E good, double num) {
        goodsDropRate.add(new DropRate<>(good, num));
        goods.add(good);
        good.setId(goodsId++);
    }

    public void deleteGoodById(long id) {
        DropRate<E> foundDropRate = null;
        for (DropRate<E> goodDropRate : goodsDropRate) {
            if (getGoodById(id).getId() == id) {
                foundDropRate = goodDropRate;
                break;
            }
        }
        if (foundDropRate != null) {
            goodsDropRate.remove(foundDropRate);
            goods.remove(foundDropRate.getGood());
        }
    }

    public void setOutGoods(E good) {
        this.outGoods.add(good);
    }

    public List<E> getOutGoods() {
        return outGoods;
    }


    public E getRandomGood() {
        double randomNumber = random.nextDouble() * 100.0;
        double cumulativePercentage = 0.0;
        for (DropRate<E> goodDropRate : goodsDropRate) {
            cumulativePercentage += goodDropRate.getDropRate();
            if (randomNumber <= cumulativePercentage) {
                setOutGoods(goodDropRate.getGood());
                return goodDropRate.getGood();
            }
        }
        return null;
    }

    public E getGoodById(long id) {
        for (E good : goods) {
            if (good.getId() == id) {
                return good;
            }
        }
        return null;
    }

    public void changeDropRate(long id, double newRate) {
        for (DropRate<E> goodDropRate : goodsDropRate) {
            if (getGoodById(id).getId() == id) {
                goodDropRate.changeDropRate(newRate);
                break;
            }
        }
    }

    @Override
    public Iterator<E> iterator() {
        return new ShopIterator(goodsDropRate);
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("В магазине ");
        sb.append(goods.size());
        sb.append(" шт.: \n");
        for (DropRate goodDropRate : goodsDropRate) {
            sb.append(goodDropRate.getGood().toString());
            sb.append(" шанс выпадения равен ");
            sb.append(goodDropRate.getDropRate());
            sb.append("%\n");
        }

        return sb.toString();
    }
}
