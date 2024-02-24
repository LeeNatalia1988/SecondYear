package exam.model.data;

import exam.model.animal.*;
import exam.model.registry.RegistryItem;

public enum AnimalType {
    CAMEL(Camel.class),
    CAT(Cat.class),
    DOG(Dog.class),
    DONKEY(Donkey.class),
    HAMSTER(Hamster.class),
    HORSE(Horse.class);

    private final Class<? extends RegistryItem> animalClass;
    AnimalType(Class<? extends RegistryItem> animalClass) {
        this.animalClass = animalClass;
    }
    public RegistryItem createInstance() throws Exception {
        return animalClass.getDeclaredConstructor().newInstance();
    }
}
