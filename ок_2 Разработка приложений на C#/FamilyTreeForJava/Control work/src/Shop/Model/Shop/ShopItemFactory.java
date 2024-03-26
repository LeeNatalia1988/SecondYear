package Shop.Model.Shop;

import Shop.Model.Shop.ShopItem;

import java.lang.reflect.Constructor;

public class ShopItemFactory {
    public static <T extends ShopItem> T createShopItem(Class<T> itemClass, String name) throws Exception {
        // Создаем экземпляр класса, используя переданный тип itemClass
        T item = itemClass.getDeclaredConstructor().newInstance();

        // Настройте созданный товар, например, установите его имя
        item.setName(name);

        return item;
    }
}