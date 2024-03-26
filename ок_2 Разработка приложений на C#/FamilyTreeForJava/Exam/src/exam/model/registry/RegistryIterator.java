package exam.model.registry;

import exam.model.animal.Animal;

import java.util.Iterator;
import java.util.List;

public class RegistryIterator<Animal> implements Iterator<Animal> {
    private int index;
    private List<Animal> animals;
    public RegistryIterator(List<Animal> animals) {
        this.animals = animals;
    }
    @Override
    public boolean hasNext() {
        return animals.size() > index;
    }

    @Override
    public Animal next() {
        return animals.get(index++);
    }
}
