package creational.singleton;

public class SimpleResource {
    private static SimpleResource simpleResource;
    private SimpleResource(){

    }

    public static SimpleResource getSimpleResource() {
        if (simpleResource == null) {
            simpleResource = new SimpleResource();
        }
        return simpleResource;
    }
}
