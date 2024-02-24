package exam.model.registry;

import exam.model.animal.Animal;
import exam.model.data.AnimalType;

public class AnimalFactory {
    public static RegistryItem getAnimal(String animalType) throws Exception {
        return AnimalType.valueOf(animalType.toUpperCase()).createInstance();
    }
}
