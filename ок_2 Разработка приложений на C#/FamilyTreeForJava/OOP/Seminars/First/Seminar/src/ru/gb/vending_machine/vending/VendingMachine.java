package ru.gb.vending_machine.vending;

import ru.gb.vending_machine.product.Product;

import java.util.ArrayList;
import java.util.List;

public class VendingMachine{
    private List<Product> productList;
    public VendingMachine(){
        productList = new ArrayList<>();
    }
    public void addProduct(Product product){
        productList.add(product);
    }
    public Product findProductByName(String name){
        for (Product product: productList){
            if (product.getName().equalsIgnoreCase(name)){
                return product;
            }
        }
        return null;
    }
    public String getProductsInfo(){
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.append("список продуктов: \n");
        for (Product product: productList){
            stringBuilder.append(product);
            stringBuilder.append("\n");
        }
        return stringBuilder.toString();
    }
}
